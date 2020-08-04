using Quickstore_API.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quickstore_API.Interfaces
{
    public interface IUserService
    {
        int Create(UserAddRequest userModel);

    }
}