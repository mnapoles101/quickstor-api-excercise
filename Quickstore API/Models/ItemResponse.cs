using Quickstore_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quickstore_API.Models
{
    public class ItemResponse<T> : SuccessResponse, IItemResponse
    {
        public T Item { get; set; }

        object IItemResponse.Item { get { return this.Item; } }
    }
}