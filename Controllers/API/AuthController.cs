using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using bikes_project.Data;
using bikes_project.ViewModels;
using bikes_project.Services;

namespace bikes_project.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService,
            IUserService userService)
        {
            this._authService = authService;
            this._userService = userService;
        }

        [HttpPost("[action]")]
        public IActionResult Register([FromBody] UserRegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false });
            }

            try
            {
                this._authService.RegisterUser(model);

                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

        [HttpPost("[action]")]
        public IActionResult Authenticate([FromBody] UserLoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false });
            }

            try
            {
                var token = _authService.AuthenticateUser(model);

                if (token != null)
                {
                    var user = _userService.GetUserByEmail(model.Email);
                    return Json(new { success = true, token = token, user = user.FirstName + " " + user.LastName });
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }
    }
}
