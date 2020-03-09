using CMS.DocumentEngine.Types.DancingGoatMvc;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CafeController : ApiController
    {
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
}
