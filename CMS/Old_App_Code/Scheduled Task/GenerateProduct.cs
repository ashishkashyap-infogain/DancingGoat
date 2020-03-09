using CMS.DocumentEngine;
using CMS.Ecommerce;
using CMS.EventLog;
using CMS.Helpers;
using CMS.Localization;
using CMS.Membership;
using CMS.Scheduler;
using CMS.SiteProvider;
using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace CMSApp.Old_App_Code.Scheduled_Task
{
    public class GenerateProduct : ITask
    {
        /// <summary>
        /// Executes the task.
        /// </summary>
        /// <param name="ti">Info object representing the scheduled task</param>
        public string Execute(TaskInfo ti)
        {
            string details = "Custom scheduled task executed. Task data: " + ti.TaskData;

            //UpdateProduct();
            //UpdateProductPage();
            //DeleteDuplicateProduct();

            ReadCSV(ti.TaskData);
            // Logs the execution of the task in the event log
            EventLogProvider.LogInformation("CustomTask", "Execute", details);

            // Returns a null value to indicate that the task executed successfully
            // Return an error message string with details in cases where the execution fails
            return null;
        }

        private void UpdateProductPage()
        {
            List<SKUInfo> products = SKUInfoProvider.GetSKUs()
                .WhereNotEmpty("SKUImagePath")
                .ToList();
            foreach(var product in products)
            {
                TreeProvider tree = new TreeProvider(MembershipContext.AuthenticatedUser);
                if (product.SKUName != "")
                {

                    // Gets the product page
                    TreeNode node = tree.SelectNodes()
                        .WhereEquals("DocumentName", product.SKUName)
                        .Type("DancingGoatMvc.Car")
                        .OnCurrentSite()
                        .CombineWithDefaultCulture()
                        .TopN(1)
                        .FirstOrDefault();

                    if (node != null)
                    {
                        node.SetValue("SKUImagePath", product.SKUImagePath);
                        node.Update();
                    }
                }
            }
        }

        private void UpdateProduct()
        {

            List<SKUInfo> products = SKUInfoProvider.GetSKUs()
                .Where(x => x.SKUImagePath.Equals(string.Empty))
                // .Where(x=>x.ClassName.Equals("DancingGoatMvc.Car"))
                .Take(200)
                .ToList();

            foreach (SKUInfo product in products)
            {
                product.SKUImagePath = "~/getmetafile/aa104796-7e18-4103-9f98-8b3e402b46a1/5a5218ca2f93c7a8d5137f99.aspx";
                product.Update();
            }

            products = SKUInfoProvider.GetSKUs()
               .Where(x => x.SKUImagePath.Equals(string.Empty))
               // .Where(x => x.ClassName.Equals("DancingGoatMvc.Car"))
               .Take(200)
               .ToList();

            foreach (SKUInfo product in products)
            {
                product.SKUImagePath = "~/getmetafile/76d4cfe5-281f-4232-b270-37979935ad6c/ethiopia.aspx";
                product.Update();
            }
            products = SKUInfoProvider.GetSKUs()
              .Where(x => x.SKUImagePath.Equals(string.Empty))
              //.Where(x => x.ClassName.Equals("DancingGoatMvc.Car"))
              .Take(200)
              .ToList();

            foreach (SKUInfo product in products)
            {
                product.SKUImagePath = "~/getmetafile/83ad494a-e810-4c9c-8206-9df2b78097fb/guatemala.aspx";
                product.Update();
            }
            products = SKUInfoProvider.GetSKUs()
              .Where(x => x.SKUImagePath.Equals(string.Empty))
              //.Where(x => x.ClassName.Equals("DancingGoatMvc.Car"))
              .Take(200)
              .ToList();

            foreach (SKUInfo product in products)
            {
                product.SKUImagePath = "~/getmetafile/0256c922-4dae-4058-a616-44ae0b2f5a66/kenya.aspx";
                product.Update();
            }
            products = SKUInfoProvider.GetSKUs()
              .Where(x => x.SKUImagePath.Equals(string.Empty))
             // .Where(x => x.ClassName.Equals("DancingGoatMvc.Car"))
              .Take(200)
              .ToList();

            foreach (SKUInfo product in products)
            {
                product.SKUImagePath = "~/getmetafile/efdb1722-d9c4-40c8-8f82-4aa50164d283/istock-157528129.aspx";
                product.Update();
            }
        }

        private void DeleteDuplicateProduct()
        {
            List<SKUInfo> products = SKUInfoProvider.GetSKUs().ToList();

            List<string> skuName = new List<string>();
            foreach (SKUInfo product in products)
            {
                if (skuName.Contains(product.SKUName))
                {
                    DeleteProductPage(product);
                }
                else
                {
                    skuName.Add(product.SKUName);
                }
            }


        }

        private void DeleteProductPage(SKUInfo product)
        {
            // Gets a TreeProvider instance
            TreeProvider tree = new TreeProvider(MembershipContext.AuthenticatedUser);
            if (product.SKUName != "")
            {

                // Gets the product page
                TreeNode node = tree.SelectNodes()
                    .WhereEquals("DocumentName", product.SKUName)
                    .Type("DancingGoatMvc.Car")
                    .OnCurrentSite()
                    .CombineWithDefaultCulture()
                    .TopN(1)
                    .FirstOrDefault();

                if (node != null)
                {
                    // Deletes the product page
                    DocumentHelper.DeleteDocument(node, tree, true, true);
                }
            }
        }

        private void ReadCSV(string taskData)
        {
            try
            {
                DataTable csvTable = new DataTable();
                using (CsvReader csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(@"D:\Dancing Goat\CMS\App_Data\Products\MOCK_DATA.csv")), true))
                {
                    csvTable.Load(csvReader);
                }
                foreach (DataRow product in csvTable.Rows)
                {
                    CreateProduct(taskData, product);
                }
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException("ReadCSV", ex.StackTrace, ex);
            }
        }

        private void CreateProduct(string productType, DataRow product)
        {
            try
            {
                string productName = ValidationHelper.GetString(product["Name"], string.Empty);

                // Gets a department
                DepartmentInfo department = DepartmentInfoProvider.GetDepartmentInfo(productType + "s", SiteContext.CurrentSiteName);

                // Creates a new product object
                SKUInfo newProduct = new SKUInfo
                {
                    // Sets the product properties
                    SKUName = productName,
                    SKUNumber = productName,
                    SKUPrice = ValidationHelper.GetDecimal(product["Price"], decimal.Zero),
                    SKUEnabled = true
                };
                if (department != null)
                {
                    newProduct.SKUDepartmentID = department.DepartmentID;
                }
                newProduct.SKUSiteID = SiteContext.CurrentSiteID;

                // Saves the product to the database
                // Note: Only creates the SKU object. You also need to create a connected product page to add the product to the site.
                SKUInfoProvider.SetSKUInfo(newProduct);

                // Gets a TreeProvider instance
                TreeProvider tree = new TreeProvider(MembershipContext.AuthenticatedUser);

                // Gets the parent page
                TreeNode parent = tree.SelectNodes("DancingGoatMvc.ProductSection")
                    .Path("/Products/" + productType + "s")
                    .OnCurrentSite()
                    .FirstOrDefault();

                if ((parent != null) && (newProduct != null))
                {
                    // Creates a new product page of the 'CMS.Product' type
                    SKUTreeNode node = (SKUTreeNode)TreeNode.New("DancingGoatMvc." + productType, tree);

                    // Sets the product page properties
                    node.DocumentSKUName = productName;
                    node.DocumentCulture = LocalizationContext.PreferredCultureCode;

                    // Sets a value for a field of the given product page type
                    //node.SetValue("CoffeeFarm", "Farm 1");
                    //node.SetValue("CoffeeCountry", "India");
                    //node.SetValue("CoffeeVariety", "Criolla, Caturra");
                    //node.SetValue("CoffeeProcessing", "Washed");
                    //node.SetValue("CoffeeAltitude", 4110);

                    node.SetValue("Company", ValidationHelper.GetString(product["Company"], string.Empty));
                    node.SetValue("ModelYear", ValidationHelper.GetString(product["ModelYear"], string.Empty));

                    // Assigns the product to the page
                    node.NodeSKUID = newProduct.SKUID;

                    node.DocumentName = productName;

                    // Saves the product page to the database
                    node.Insert(parent);
                }
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException("CreateProduct", ex.StackTrace, ex);
            }
        }
    }
}