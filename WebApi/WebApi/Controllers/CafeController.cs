using Business.Dto.ClassSchema;
using Business.Services.Context;
using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DancingGoatMvc;
using CMS.OnlineForms;
using DocumentFormat.OpenXml.CustomXmlSchemaReferences;
using LiquidTechnologies.GeneratedLx.Ns;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Xml;
using System.Xml.Serialization;
using WebApi.Config;
using WebApi.Models;
namespace WebApi.Controllers
{
    public class CafeController : ApiController
    {
        private ISiteContextService SiteContext { get; }

        private readonly string[] _coreColumns =
        {
            // Defines initial columns returned for optimization. If not set, all columns are returned.
            "NodeGUID", "DocumentID", "NodeID"
        };
        [Route("getallcafe")]
        public List<Cafe> GetAllCafe()
        {
            //QueryDataParameters parameters = new QueryDataParameters
            //{
            //    { "@ClassName", Cafe.CLASS_NAME }
            //};

            //DataSet ds = ConnectionHelper.ExecuteQuery("Proc_CMS_Class_GetXmlSchema", parameters, QueryTypeEnum.StoredProcedure);
            //if (ds != null)
            //{
            //    string str = ds.Tables[0].Rows[0]["ClassXmlSchema"].ToString();
            //    XmlDocument xmlDoc = new XmlDocument();
            //    xmlDoc.LoadXml(str);
            //    string jsonString = JsonConvert.SerializeXmlNode(xmlDoc);
            //    //XmlSerializer serializer = new XmlSerializer(typeof(NewDataSetElm));
            //    //using (StringReader reader = new StringReader(str))
            //    //{
            //    //    NewDataSetElm ex = (NewDataSetElm)(serializer.Deserialize(reader));
            //    //}
            //    // ClassSchemaDto classSchemaDto=
            //    var data = DocumentHelper.GetDocuments("DancingGoatMvc.Cafe").ToList();
            //   // List<Cafe> cafes = CafeProvider.GetCafes().ToList();
            //    return null;
            //}
            return null;
            //var data = DocumentHelper.GetDocuments("DancingGoatMvc.CafeID").ToList();
            //return data;
        }

        [Route("bizform")]
        public BizFormInfo GetBizForm()
        {
            BizFormInfo bizFormInfo = BizFormInfoProvider.GetBizFormInfo("DancingGoatMvcContactUsNew", AppConfig.SiteName);
            return bizFormInfo;
        }

        [Route("Cafe")]
        public List<CafeModel> GetCafe()
        {
            List<CafeModel> cafe = GetBaseCafesQuery().ToList();
            return cafe;
        }
        private List<CafeModel> GetBaseCafesQuery()
        {

            return CafeProvider.GetCafes()
                .OrderBy("NodeOrder")
                .AsEnumerable()
                .Select(x =>
                {
                    return new CafeModel()
                    {
                        CafeID = x.CafeID,
                        CafeName = x.CafeName,
                        CafeIsCompanyCafe = x.CafeIsCompanyCafe,
                        CafeStreet = x.CafeStreet,
                        CafeCity = x.CafeCity,
                        CafeCountry = x.CafeCountry,
                        CafeZipCode = x.CafeZipCode,
                        CafePhone = x.CafePhone,
                        CafeAdditionalNotes = x.CafeAdditionalNotes
                    };
                })
                .ToList();
        }

    }

    public class ResponseData<T> : DocumentQuery<Cafe>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<Cafe> Data { get; set; }
    }


}
