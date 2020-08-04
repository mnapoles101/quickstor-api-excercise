using Quickstore_API.Interfaces;
using Quickstore_API.Interfaces.Security;
using Quickstore_API.Requests;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Quickstore_API.Services
{
    public class UserServices : IUserService
    {
        private IAuthenticationService<int> _authenticationService;
        private IDataProvider _dataProvider;

        public UserServices(IAuthenticationService<int> authSerice, IDataProvider dataProvider)
        {
            _authenticationService = authSerice;
            _dataProvider = dataProvider;
        }

        public int Create(UserAddRequest userModel)
        {
           

            int userId = 0;
          


            string procName = "[dbo].[Users_Insert]";

            _dataProvider.ExecuteNonQuery(procName, inputParamMapper: delegate (SqlParameterCollection col)
            {
               
                col.AddWithValue("@RoleId", userModel.RoleId);
                col.AddWithValue("@CompanyName", userModel.CompanyName);
                col.AddWithValue("@PhoneNumber", userModel.PhoneNumber);
                col.AddWithValue("@ZipCode", userModel.ZipCode);


                SqlParameter idOut = new SqlParameter("@Id", SqlDbType.Int);
                idOut.Direction = ParameterDirection.Output;
                col.Add(idOut);
            },
            returnParameters: delegate (SqlParameterCollection returnCollection)
            {

                object oId = returnCollection["@Id"].Value;
                Int32.TryParse(oId.ToString(), out userId);

            }
            );


            return userId;
        }

        
    }
}