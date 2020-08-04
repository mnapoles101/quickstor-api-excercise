using Quickstore_API.Enums;
using Quickstore_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quickstore_API.Interfaces
{
    public interface IUserTokensService
    {
        void Insert(string token, int userId, TokenType tokenType);

        UserToken SelectByToken(string token);

        UserToken SelectByUserId(int userId);
        void DeleteToken(string token, int userId);
        void Delete(string token);
    }
}