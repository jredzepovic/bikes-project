using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using bikes_project.Data;
using bikes_project.ViewModels;
using bikes_project.Services;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace bikes_project.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IAuthService _authService;

        public UserController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpGet("[action]"), Authorize]
        public IActionResult Profile()
        {
            return Json(new { email = HttpContext.User.Claims.Where(c => c.Type == ClaimValueTypes.Email).FirstOrDefault().Value });
        }
    }
}
