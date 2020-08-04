using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quickstore_API.Interfaces
{
    public interface IItemResponse
    {
        bool IsSuccessful { get; set; }

        string TransactionId { get; set; }

        object Item { get; }
    }
}