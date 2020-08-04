using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quickstore_API.Interfaces.Security
{
    public interface IIdentityProvider<T>
    {
        T GetCurrentUserId();
    }
}