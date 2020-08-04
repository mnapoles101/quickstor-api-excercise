using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quickstore_API.Models
{
    public class SuccessResponse : BaseResponse
    {
        public SuccessResponse()
        {
            this.IsSuccessful = true;
        }
    }
}