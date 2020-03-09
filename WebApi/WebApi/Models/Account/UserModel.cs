using System;

namespace WebApi.Models.Account
{
    public class UserModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Enabled { get; set; }
        public Guid UserGUID { get; set; }
    }
}