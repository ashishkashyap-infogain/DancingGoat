using Business.DependencyInjection;

namespace Business.Repository
{
    //[Injectable]
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IRepository _employeeRepository;

        public EmployeeManager(IRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public string GetAllEmployes()
        {
            return "GetAllEmployees";
        }
    }
}
