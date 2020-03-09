using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Response<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }
    }

    public class UserDetails<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public Task<T> User { get; set; }
    }

    public class ResponseMessage
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    internal class RegisterUserResponse<T> : IdentityResult
    {
        public HttpStatusCode StatusCode { get; set; }
        public new bool Success { get; set; }
        public string Message { get; set; }
        public IdentityResult User { get; set; }
    }
}