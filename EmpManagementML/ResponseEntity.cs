using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EmpManagementML
{
    public class ResponseEntity
    {
        public HttpStatusCode code;
        public string message;
        public object result;

        public ResponseEntity(HttpStatusCode code, string message, object result)
        {
            this.code = code;
            this.message = message;
            this.result = result;
        }
    }
}
