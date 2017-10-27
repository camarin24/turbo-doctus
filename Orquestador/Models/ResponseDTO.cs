using System;
using System.Collections.Generic;
using System.Linq;

namespace Orquestador.Models
{
    public class Response<T>
    {

        public Response()
        {
            this.Header = new Header()
            {
                Code = 200,
                Message = ""
            };
        }

        public Header Header { get; set; }
        public T Data { get; set; }
    }
}