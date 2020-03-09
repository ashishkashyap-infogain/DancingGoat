using System;
using System.Collections.Generic;
using System.Net;

namespace DancingGoat.Areas.Api.Dto
{
    public class UserDto
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public bool enabled { get; set; }
        public Guid userGUID { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }

    }
    public class UserRegister
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

    }

    public class UserData
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }

    }

    public class ApiResponse<T>
    {
        public HttpStatusCode statusCode { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public UserDto data { get; set; }
    }

}