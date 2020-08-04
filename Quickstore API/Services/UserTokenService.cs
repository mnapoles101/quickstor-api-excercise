using Quickstore_API.Enums;
using Quickstore_API.Interfaces;
using Quickstore_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quickstore_API.Services
{
    public class UserTokensService : IUserTokensService
    {
        private IDataProvider _data;

        public UserTokensService(IDataProvider data)
        {
            _data = data;
        }


        public void Insert(string token, int userId, TokenType tokenType)
        {

            string procName = "[dbo].[UserTokens_Insert]";
            _data.ExecuteNonQuery(procName,
               inputParamMapper: delegate (SqlParameterCollection col)
               {
                   col.AddWithValue("@Token", token);
                   col.AddWithValue("@UserId", userId);
                   col.AddWithValue("@TokenType", tokenType);
               },
               returnParameters: null);
        }



        public UserToken SelectByToken(string token)
        {
            string procName = "[dbo].[UserTokens_SelectByToken]";
            UserToken userToken = null;
            _data.ExecuteCmd(procName,
                inputParamMapper: delegate (SqlParameterCollection col)
                {
                    col.AddWithValue("@Token", token);
                },
                singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    int index;
                    MapUserToken(reader, out userToken, out index);
                });
            return userToken;
        }

        public UserToken SelectByUserId(int userId)
        {
            string procName = "[dbo].[UserTokens_SelectByUserId]";
            UserToken userToken = null;
            _data.ExecuteCmd(procName,
                inputParamMapper: delegate (SqlParameterCollection col)
                {
                    col.AddWithValue("@UserId", userId);
                },
                singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    int index;
                    MapUserToken(reader, out userToken, out index);
                });
            return userToken;
        }

        public void DeleteToken(string token, int userId)
        {
            string procName = "[UserTokens_Select_UpdateUserStatus_DeleteToken]";
            _data.ExecuteNonQuery(procName,
                inputParamMapper: delegate (SqlParameterCollection col)
                {
                    col.AddWithValue("@Token", token);
                    col.AddWithValue("@UserId", userId);
                },
                returnParameters: null);
        }

        public void Delete(string token)
        {
            string procName = "[dbo].[UserTokens_DeleteByToken]";
            _data.ExecuteNonQuery(procName,
                inputParamMapper: delegate (SqlParameterCollection col)
                {
                    col.AddWithValue("@Token", token);
                },
                returnParameters: null);
        }

        private static UserToken MapUserToken(IDataReader reader, out UserToken userToken, out int index)
        {
            userToken = new UserToken();
            index = 0;
            userToken.Token = reader.GetSafeString(index++);
            userToken.UserId = reader.GetSafeInt32(index++);
            userToken.TokenType = reader.GetSafeInt32(index++);
            return userToken;
        }
    }
}