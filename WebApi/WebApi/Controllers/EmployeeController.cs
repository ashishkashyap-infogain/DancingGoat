using Business.Repository;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        [Route("Employees")]
        [AllowAnonymous]
        public IHttpActionResult GetEmployees()
        {
            string employeeData = _employeeManager.GetAllEmployes();
            return Ok(employeeData);
        }
    }
}
