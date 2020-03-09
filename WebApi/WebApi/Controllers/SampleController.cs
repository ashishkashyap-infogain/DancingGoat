using Business.Repository;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("Sample")]
    public class SampleController : ApiController
    {
        private readonly ISampleRespository _sampleRespository;
        public SampleController(ISampleRespository sampleRespository)
        {
            _sampleRespository = sampleRespository;
        }

        //private readonly ISampleRespository sampleRespository = new SampleRespository();

        //public SampleController()
        //{
        //    _sampleRespository = sampleRespository;
        //}
        [Route("Get")]
        public string Get()
        {
            return _sampleRespository.GetSampleString();
        }
        [Authorize(Roles = "Designer")]
        [Route("GetDesignerData")]
        public string GetDesignerData()
        {
            return _sampleRespository.GetSampleString();
        }

        [Authorize(Roles = "Seller")]
        [Route("GetSellerData")]
        public string GetSellerData()
        {
            return _sampleRespository.GetSampleString();
        }

        [Authorize]
        [Route("GetAuthrorizeData")]
        public string GetAuthrorizeData()
        {
            return _sampleRespository.GetSampleString();
        }

    }

}
