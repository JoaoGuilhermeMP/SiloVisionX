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
        HttpStatusCode StatusCode { get; set; }
        string Message { get; set; }
        List<T> Data { get; set; }
        bool IsSuccess { get; set; }


    }
}
