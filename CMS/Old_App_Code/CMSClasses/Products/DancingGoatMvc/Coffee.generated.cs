//--------------------------------------------------------------------------------------------------
// <auto-generated>
//
//     This code was generated by code generator tool.
//
//     To customize the code use your own partial class. For more info about how to use and customize
//     the generated code see the documentation at http://docs.kentico.com.
//
// </auto-generated>
//--------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using CMS;
using CMS.Base;
using CMS.Helpers;
using CMS.DataEngine;
using CMS.DocumentEngine.Types.DancingGoatMvc;
using CMS.DocumentEngine;
using CMS.Ecommerce;

[assembly: RegisterDocumentType(Coffee.CLASS_NAME, typeof(Coffee))]

namespace CMS.DocumentEngine.Types.DancingGoatMvc
{
	/// <summary>
	/// Represents a content item of type Coffee.
	/// </summary>
	public partial class Coffee : SKUTreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "DancingGoatMvc.Coffee";


		/// <summary>
		/// The instance of the class that provides extended API for working with Coffee fields.
		/// </summary>
		private readonly CoffeeFields mFields;


		/// <summary>
		/// The instance of the class that provides extended API for working with SKU fields.
		/// </summary>
		private readonly ProductFields mProduct;

		#endregion


		#region "Properties"

		/// <summary>
		/// CoffeeID.
		/// </summary>
		[DatabaseIDField]
		public int CoffeeID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("CoffeeID"), 0);
			}
			set
			{
				SetValue("CoffeeID", value);
			}
		}


		/// <summary>
		/// Farm.
		/// </summary>
		[DatabaseField]
		public string CoffeeFarm
		{
			get
			{
				return ValidationHelper.GetString(GetValue("CoffeeFarm"), @"");
			}
			set
			{
				SetValue("CoffeeFarm", value);
			}
		}


		/// <summary>
		/// Country.
		/// </summary>
		[DatabaseField]
		public string CoffeeCountry
		{
			get
			{
				return ValidationHelper.GetString(GetValue("CoffeeCountry"), @"USA");
			}
			set
			{
				SetValue("CoffeeCountry", value);
			}
		}


		/// <summary>
		/// Variety.
		/// </summary>
		[DatabaseField]
		public string CoffeeVariety
		{
			get
			{
				return ValidationHelper.GetString(GetValue("CoffeeVariety"), @"");
			}
			set
			{
				SetValue("CoffeeVariety", value);
			}
		}


		/// <summary>
		/// Processing.
		/// </summary>
		[DatabaseField]
		public string CoffeeProcessing
		{
			get
			{
				return ValidationHelper.GetString(GetValue("CoffeeProcessing"), @"");
			}
			set
			{
				SetValue("CoffeeProcessing", value);
			}
		}


		/// <summary>
		/// Altitude.
		/// </summary>
		[DatabaseField]
		public int CoffeeAltitude
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("CoffeeAltitude"), 0);
			}
			set
			{
				SetValue("CoffeeAltitude", value);
			}
		}


		/// <summary>
		/// Decaf.
		/// </summary>
		[DatabaseField]
		public bool CoffeeIsDecaf
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("CoffeeIsDecaf"), false);
			}
			set
			{
				SetValue("CoffeeIsDecaf", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with Coffee fields.
		/// </summary>
		[RegisterProperty]
		public CoffeeFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with SKU fields.
		/// </summary>
        [RegisterProperty]
		public ProductFields Product
		{
			get
			{
				return mProduct;
			}
		}


		/// <summary>
		/// Provides extended API for working with Coffee fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class CoffeeFields : AbstractHierarchicalObject<CoffeeFields>
		{
			/// <summary>
			/// The content item of type Coffee that is a target of the extended API.
			/// </summary>
			private readonly Coffee mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="CoffeeFields" /> class with the specified content item of type Coffee.
			/// </summary>
			/// <param name="instance">The content item of type Coffee that is a target of the extended API.</param>
			public CoffeeFields(Coffee instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// CoffeeID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.CoffeeID;
				}
				set
				{
					mInstance.CoffeeID = value;
				}
			}


			/// <summary>
			/// Farm.
			/// </summary>
			public string Farm
			{
				get
				{
					return mInstance.CoffeeFarm;
				}
				set
				{
					mInstance.CoffeeFarm = value;
				}
			}


			/// <summary>
			/// Country.
			/// </summary>
			public string Country
			{
				get
				{
					return mInstance.CoffeeCountry;
				}
				set
				{
					mInstance.CoffeeCountry = value;
				}
			}


			/// <summary>
			/// Variety.
			/// </summary>
			public string Variety
			{
				get
				{
					return mInstance.CoffeeVariety;
				}
				set
				{
					mInstance.CoffeeVariety = value;
				}
			}


			/// <summary>
			/// Processing.
			/// </summary>
			public string Processing
			{
				get
				{
					return mInstance.CoffeeProcessing;
				}
				set
				{
					mInstance.CoffeeProcessing = value;
				}
			}


			/// <summary>
			/// Altitude.
			/// </summary>
			public int Altitude
			{
				get
				{
					return mInstance.CoffeeAltitude;
				}
				set
				{
					mInstance.CoffeeAltitude = value;
				}
			}


			/// <summary>
			/// Decaf.
			/// </summary>
			public bool IsDecaf
			{
				get
				{
					return mInstance.CoffeeIsDecaf;
				}
				set
				{
					mInstance.CoffeeIsDecaf = value;
				}
			}
		}


		/// <summary>
		/// Provides extended API for working with SKU fields.
		/// </summary>
        [RegisterAllProperties]
		public class ProductFields : AbstractHierarchicalObject<ProductFields>
		{
		    /// <summary>
			/// The content item of type <see cref="Coffee" /> that is a target of the extended API.
			/// </summary>
			private readonly Coffee mInstance;


			/// <summary>
			/// The <see cref="PublicStatusInfo" /> object related to product based on value of <see cref="SKUInfo.SKUPublicStatusID" /> column. 
			/// </summary>
			private PublicStatusInfo mPublicStatus = null;


			/// <summary>
			/// The <see cref="ManufacturerInfo" /> object related to product based on value of <see cref="SKUInfo.SKUManufacturerID" /> column. 
			/// </summary>
			private ManufacturerInfo mManufacturer = null;


			/// <summary>
			/// The <see cref="DepartmentInfo" /> object related to product based on value of <see cref="SKUInfo.SKUDepartmentID" /> column. 
			/// </summary>
			private DepartmentInfo mDepartment = null;


			/// <summary>
			/// The <see cref="SupplierInfo" /> object related to product based on value of <see cref="SKUInfo.SKUSupplierID" /> column. 
			/// </summary>
			private SupplierInfo mSupplier = null;


			/// <summary>
			/// The <see cref="TaxClassInfo" /> object related to product based on value of <see cref="SKUInfo.SKUTaxClassID" /> column. 
			/// </summary>
			private TaxClassInfo mTaxClass = null;


			/// <summary>
			/// The <see cref="BrandInfo" /> object related to product based on value of <see cref="SKUInfo.SKUBrandID" /> column. 
			/// </summary>
			private BrandInfo mBrand = null;


			/// <summary>
			/// The <see cref="CollectionInfo" /> object related to product based on value of <see cref="SKUInfo.SKUCollectionID" /> column. 
			/// </summary>
			private CollectionInfo mCollection = null;


			/// <summary>
			/// The shortcut to <see cref="SKUInfo" /> object which is a target of this extended API.
			/// </summary>
			private SKUInfo SKU
			{
				get 
				{
					return mInstance.SKU;
				}
			}

						
			/// <summary>
			/// Initializes a new instance of the <see cref="ProductFields" /> class with SKU related fields of type <see cref="Coffee" /> .
			/// </summary>
			/// <param name="instance">The content item of type Coffee that is a target of the extended API.</param>
			public ProductFields(Coffee instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// SKUID.
			/// </summary>
			public int ID
			{
				get
				{
					return (SKU != null) ? SKU.SKUID : 0;
				}
				set
				{
					if (SKU != null)
					{
						SKU.SKUID = value;
					}
				}
			}


			/// <summary>
			/// Allows you to specify the product identifier. You can use this number or string, for example, in your accounting records.
			/// </summary>
			public string SKUNumber
			{
				get
				{
					return (SKU != null) ? SKU.SKUNumber : @"";
				}
				set
				{
					if (SKU != null)
					{
						SKU.SKUNumber = value;
					}
				}
			}


			/// <summary>
			/// Package weight.
			/// </summary>
			public double Weight
			{
				get
				{
					return (SKU != null) ? SKU.SKUWeight : 0;
				}
				set
				{
					if (SKU != null)
					{
						SKU.SKUWeight = value;
					}
				}
			}


			/// <summary>
			/// Package height.
			/// </summary>
			public double Height
			{
				get
				{
					return (SKU != null) ? SKU.SKUHeight : 0;
				}
				set
				{
					if (SKU != null)
					{
						SKU.SKUHeight = value;
					}
				}
			}


			/// <summary>
			/// Package width.
			/// </summary>
			public double Width
			{
				get
				{
					return (SKU != null) ? SKU.SKUWidth : 0;
				}
				set
				{
					if (SKU != null)
					{
						SKU.SKUWidth = value;
					}
				}
			}


			/// <summary>
			/// Package depth.
			/// </summary>
			public double Depth
			{
				get
				{
					return (SKU != null) ? SKU.SKUDepth : 0;
				}
				set
				{
					if (SKU != null)
					{
						SKU.SKUDepth = value;
					}
				}
			}


			/// <summary>
			/// Gets <see cref="PublicStatusInfo" /> object based on value of <see cref="SKUInfo.SKUPublicStatusID" /> column. 
			/// </summary>
			public PublicStatusInfo PublicStatus
			{	
				get
				{
					if (SKU == null)
					{
						return null;
					}

					var id = SKU.SKUPublicStatusID;

				    if ((mPublicStatus == null) && (id > 0))
				    {
                        mPublicStatus = PublicStatusInfoProvider.GetPublicStatusInfo(id);
				    }

				    return mPublicStatus;
				}
			}


			/// <summary>
			/// Gets <see cref="ManufacturerInfo" /> object based on value of <see cref="SKUInfo.SKUManufacturerID" /> column. 
			/// </summary>
			public ManufacturerInfo Manufacturer
			{	
				get
				{
					if (SKU == null)
					{
						return null;
					}

					var id = SKU.SKUManufacturerID;

				    if ((mManufacturer == null) && (id > 0))
				    {
                        mManufacturer = ManufacturerInfoProvider.GetManufacturerInfo(id);
				    }

				    return mManufacturer;
				}
			}


			/// <summary>
			/// Gets <see cref="DepartmentInfo" /> object based on value of <see cref="SKUInfo.SKUDepartmentID" /> column. 
			/// </summary>
			public DepartmentInfo Department
			{	
				get
				{
					if (SKU == null)
					{
						return null;
					}

				    var id = SKU.SKUDepartmentID;

				    if ((mDepartment == null) && (id > 0))
				    {
				        mDepartment = DepartmentInfoProvider.GetDepartmentInfo(id);
                    }

					return mDepartment;
				}
			}


			/// <summary>
			/// Gets <see cref="SupplierInfo" /> object based on value of <see cref="SKUInfo.SKUSupplierID" /> column. 
			/// </summary>
			public SupplierInfo Supplier
			{	
				get
				{
					if (SKU == null)
					{
						return null;
					}

					var id = SKU.SKUSupplierID;

				    if ((mSupplier == null) && (id > 0))
				    {
                        mSupplier = SupplierInfoProvider.GetSupplierInfo(id);
                    }

				    return mSupplier;
				}
			}


			/// <summary>
			/// Gets <see cref="TaxClassInfo" /> object based on value of <see cref="SKUInfo.SKUTaxClassID" /> column. 
			/// </summary>
			public TaxClassInfo TaxClass
			{	
				get
				{
					if (SKU == null)
					{
						return null;
					}

					var id = SKU.SKUTaxClassID;

				    if ((mTaxClass == null) && (id > 0))
				    {
						mTaxClass = TaxClassInfoProvider.GetTaxClassInfo(id);
				    }
				    
				    return mTaxClass;
				}
			}


			/// <summary>
			/// Gets <see cref="BrandInfo" /> object based on value of <see cref="SKUInfo.SKUBrandID" /> column. 
			/// </summary>
			public BrandInfo Brand
			{	
				get
				{
					if (SKU == null)
					{
						return null;
					}

					var id = SKU.SKUBrandID;

					if ((mBrand == null) && (id > 0))
					{
						mBrand = BrandInfoProvider.GetBrandInfo(id);
					}

					return mBrand;
				}
			}


			/// <summary>
			/// Gets <see cref="CollectionInfo" /> object based on value of <see cref="SKUInfo.SKUCollectionID" /> column. 
			/// </summary>
			public CollectionInfo Collection
			{	
				get
				{
					if (SKU == null)
					{
						return null;
					}

					var id = SKU.SKUCollectionID;

					if ((mCollection == null) && (id > 0))
					{
						mCollection = CollectionInfoProvider.GetCollectionInfo(id);
					}

					return mCollection;
				}
			}


			/// <summary>
			/// Localized name of product.
			/// </summary>
			public string Name
			{
				get
				{
					return mInstance.DocumentSKUName;
				}
				set
				{
					mInstance.DocumentSKUName = value;
				}
			}


			/// <summary>
			/// Localized description of product.
			/// </summary>
			public string Description
			{
				get
				{
					return mInstance.DocumentSKUDescription;
				}
				set
				{
					mInstance.DocumentSKUDescription = value;
				}
			}


			/// <summary>
			/// Localized short description of product.
			/// </summary>
			public string ShortDescription
			{
				get
				{
					return mInstance.DocumentSKUShortDescription;
				}
				set
				{
					mInstance.DocumentSKUShortDescription = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="Coffee" /> class.
		/// </summary>
		public Coffee() : base(CLASS_NAME)
		{
			mFields = new CoffeeFields(this);
			mProduct = new ProductFields(this);
		}

		#endregion
	}
}