using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quickstore_API.Enums;
using Quickstore_API.Interfaces;
using Quickstore_API.Interfaces.Security;
using Quickstore_API.Models;
using Quickstore_API.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace Quickstore_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsersAPIController : BaseApiController
    {
      
        private IUserService _userService = null;
        private IAuthenticationService<int> _authService = null;
        private IUserTokensService _userTokensService = null;

        public UsersAPIController(IUserService service
                                , ILogger<UsersAPIController> logger
                                , IUserTokensService userTokensService
                                , IAuthenticationService<int> authService) : base(logger)
        {
            _userService = service;
            _authService = authService;
            _userTokensService = userTokensService;

        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<ItemResponse<int?>> Register(UserAddRequest model)
        {
            int sCode = 200;
            BaseResponse response = null;
            int id;
            try
            {

                id = _userService.Create(model);

                if (id <= 0)
                {
                    sCode = 404;
                    response = new ErrorResponse("user not found");
                }
                else
                {
                    string token = Guid.NewGuid().ToString();
                    _userTokensService.Insert(token, id, TokenType.NewUser);
                    response = new ItemResponse<int?>() { Item = id };
                }

            }
            catch (Exception ex)
            {
                sCode = 500;
                base.Logger.LogError(ex.ToString());
                response = new ErrorResponse($"Generic Errors: { ex.Message }");
            }


            return StatusCode(sCode, response);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<ItemResponse<int?>> WeatherData(float latitude, float longitude)
        {
            int sCode = 200;
            BaseResponse response = null;
          
            try
            {

                

              
              

            }
            catch (Exception ex)
            {
                sCode = 500;
                base.Logger.LogError(ex.ToString());
                response = new ErrorResponse($"Generic Errors: { ex.Message }");
            }


            return StatusCode(sCode, response);
        }
    }
}
