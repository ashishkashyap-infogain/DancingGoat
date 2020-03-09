using CMS.DataEngine;
using CMS.DocumentEngine.Types.DancingGoatMvc;
using DancingGoat.Areas.Api.Dto;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace DancingGoat.Areas.Api.Controllers
{
    public class CafeController : ApiController
    {
        //     public List<>
        [Route("api/cafe1")]
        public List<CafeDto> GetCafe()
        {
            //CreateProduct();

            List<CafeDto> cafe = GetBaseCafesQuery().ToList();
            return cafe;
        }

        private List<CafeDto> GetBaseCafesQuery()
        {

            //DataSet dataSet = new DataQuery("DancingGoatMvc.Cafe.GetAllCafe")
            //                     .Execute();
            //DataSet dataSet1 = ConnectionHelper.ExecuteQuery("Proc_Custom_GetAllUsers", null, QueryTypeEnum.StoredProcedure);

            return CafeProvider.GetCafes()
                .OrderBy("NodeOrder")
                .AsEnumerable()
                .Select(x =>
                {
                    return new CafeDto()
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
}
