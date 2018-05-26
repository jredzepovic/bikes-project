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
    public class AdvertController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IAdvertService _advertService;

        public AdvertController(IAuthService authService,
            IUserService userService,
            IAdvertService advertService)
        {
            this._authService = authService;
            this._userService = userService;
            this._advertService = advertService;
        }

        [HttpPost("[action]"), Authorize]
        public IActionResult AddAdvert([FromBody]AddAdvertModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (model.Name == null || model.TireSize == null || model.Condition == null
                || model.Color == null || model.Description == null)
            {
                return BadRequest();
            }

            var user = _userService.GetUserByID(Int32.Parse(HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value));

            try
            {
                _advertService.AddAdvert(model, user);

                return Json(new { success = "true" });
            }
            catch (Exception)
            {
                return Json(new { success = "false" });
            }
        }

        [HttpGet("[action]")]
        public IActionResult Details(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            try
            {
                var bike = _advertService.GetBikeDetails(id);
                if (bike != null)
                {
                    return Json(new
                    {
                        success = "true",
                        bike = new
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
                            additionalEquipment = bike.AdditionalEquipment.Select(eq => new
                            {
                                id = eq.Id,
                                name = eq.Name,
                                description = eq.Description,
                                amount = eq.Amount
                            }).ToList(),
                            type = bike.IdBikeTypeNavigation.Name,
                            condition = bike.IdBikeConditionNavigation.Name,
                            county = bike.IdCountyNavigation.Name,
                            advertTypes = bike.BikeAdvertType.Select(type => new
                            {
                                name = type.IdAdvertTypeNavigation.Name
                            }),
                            user = new
                            {
                                id = bike.IdUserNavigation.Id,
                                name = bike.IdUserNavigation.FirstName + " " + bike.IdUserNavigation.LastName,
                                email = bike.IdUserNavigation.Email,
                                phone = bike.IdUserNavigation.Phone.Trim(),
                                cellPhone = bike.IdUserNavigation.CellPhone.Trim()
                            }
                        }
                    });
                }
                else
                {
                    return Json(new { success = "false" });
                }

            }
            catch (Exception)
            {
                return Json(new { success = "false" });
            }
        }

        [HttpPost("[action]")]
        public IActionResult DeleteAdvert([FromQuery]int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            //var user = _userService.GetUserByID(Int32.Parse(HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value));

            try
            {
                var advert = _advertService.GetBikeDetails(id);

                /*if (advert.IdUserNavigation.Id == user.Id)
                {
                    _advertService.DeleteBike(id);

                    return Json(new { success = "true" });
                }*/

                _advertService.DeleteBike(id);

                return Json(new { success = "true" });
            }
            catch (Exception)
            {
                return Json(new { success = "false" });
            }
        }

        [HttpPost("[action]")]
        public IActionResult EditAdvert([FromBody]AddAdvertModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (model.Name == null || model.TireSize == null || model.Condition == null
                || model.Color == null || model.Description == null)
            {
                return BadRequest();
            }

            try
            {
                _advertService.EditAdvert(model);

                return Json(new { success = "true" });
            }
            catch (Exception)
            {
                return Json(new { success = "false" });
            }
        }

        [HttpGet("[action]")]
        public IActionResult GetAllAdverts()
        {
            try
            {
                return Json(new { data = _advertService.GetAllAdverts() });
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
