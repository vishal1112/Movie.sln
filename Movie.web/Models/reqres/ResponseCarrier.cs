using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie.web.Models.reqres
{
    public class ResponseCarrier
    {
        public ResponseCarrier()
        {
            Status = true;
            ErrorMessage = string.Empty;
        }
        public bool Status { get; set; }

        public object PayLoad { get; set; }

        public string ErrorMessage { get; set; }
    }
}