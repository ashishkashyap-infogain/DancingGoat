using System.Collections.Generic;
using System.Net;

namespace DancingGoat.Areas.Api.Models
{
    public class Response<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }
    }
}