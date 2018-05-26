using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUserService _userService;

        public UserController(IAuthService authService,
            IUserService userService)
        {
            this._authService = authService;
            this._userService = userService;
        }

        [HttpGet("[action]"), Authorize]
        public IActionResult Profile()
        {
            var user = _userService.GetUserByID(Int32.Parse(HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value));
            return Json(new
            {
                id = user.Id,
                name = user.FirstName + " " + user.LastName,
                oib = user.Oib,
                phone = user.Phone.Trim(),
                cellPhone = user.CellPhone.Trim(),
                email = user.Email,
                address = user.Address,
                county = user.IdCountyNavigation.Name,
                adverts = user.Bike.Select(bike => new
                {
                    id = bike.Id,
                    name = bike.Name,
                    tireSize = bike.TireSize,
                    speeds = bike.Speeds,
                    weight = bike.Weight,
                    color = bike.Color,
                    publishDate = bike.PublishDate,
                    description = bike.Description,
                    image = bike.Image,
                    price = bike.Price,
                    county = bike.IdCountyNavigation.Name,
                    condition = bike.IdBikeConditionNavigation.Name,
                    type = bike.IdBikeTypeNavigation.Name,
                    additionalEquipment = bike.AdditionalEquipment.Select(addEq => new
                    {
                        id = addEq.Id,
                        name = addEq.Name,
                        description = addEq.Description,
                        amount = addEq.Amount
                    }).ToList(),
                    advertType = bike.BikeAdvertType.Select(adType => new
                    {
                        name = adType.IdAdvertTypeNavigation.Name
                    }).ToList()
                }).ToList()
            });
        }

        [HttpGet("[action]"), Authorize]
        public IActionResult GetUserID()
        {
            var user = _userService.GetUserByID(Int32.Parse(HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value));

            return Json(new { id = user.Id });
        }
    }
}
