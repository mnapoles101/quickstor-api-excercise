using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Quickstor_Excercise.Controllers;

namespace Quickstore.Controllers
{
    // POST api/Account/Register
    [HttpPost]
    [AllowAnonymous]
    [Route("Register")]
    public async Task<IHttpActionResult> Register(UserModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = new ApplicationUser() { UserName = model.CompanyName, PhoneNumber = model.PhoneNumber, ZipCode = model.ZipCode };

        //set the IsDeleted property to false


        IdentityResult result = await UserManager.CreateAsync(user, model.CompanyName);

        int sCode = 200;
        BaseResponse response = null;

        try
        {

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
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

}

