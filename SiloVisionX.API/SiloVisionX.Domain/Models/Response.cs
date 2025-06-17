using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Domain.Models
{
    public class Response<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }
        public bool IsSuccess { get; set; }


    }
}
