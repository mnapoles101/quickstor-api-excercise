using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quickstore_API.Interfaces
{
    public interface IUserAuthData
    {
        int Id { get; }
        string Email { get; }
        IEnumerable<string> Roles { get; }
        //object TenantId { get; }
    }
}