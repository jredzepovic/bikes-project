using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using bikes_project.Data;
using bikes_project.ViewModels;
using bikes_project.Models;
using bikes_project.Services;
using System.Security.Claims;

namespace bikes_project.Controllers
{
    [Route("api/[controller]")]
    public class AdditionalEquipmentController : Controller
    {
        private readonly IAdditionalEquipmentService _additionalEquipmentService;
        private readonly IUserService _userService;

        public AdditionalEquipmentController(IAdditionalEquipmentService additionalEquipmentService,
            IUserService userService)
        {
            this._additionalEquipmentService = additionalEquipmentService;
            this._userService = userService;
        }

        [HttpPost("[action]")]
        public IActionResult DeleteAdditionalEquipment([FromQuery]int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            //var user = _userService.GetUserByID(Int32.Parse(HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value));

            try
            {
                var addEq = _additionalEquipmentService.GetDetails(id);

                /*if (addEq.IdBikeNavigation.IdUserNavigation.Id == user.Id)
                {
                    _additionalEquipmentService.DeleteAdditionalEquipment(id);

                    return Json(new { success = "true" });
                }

                return Json(new { success = "false" });*/
                _additionalEquipmentService.DeleteAdditionalEquipment(id);

                return Json(new { success = "true" });
            }
            catch (Exception)
            {
                return Json(new { success = "false" });
            }
        }

        [HttpGet("[action]")]
        public IActionResult Details([FromQuery]int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            try
            {
                var addEq = _additionalEquipmentService.GetDetails(id);

                return Json(new
                {
                    success = true,
                    data = new
                    {
                        name = addEq.Name,
                        description = addEq.Description,
                        amount = addEq.Amount
                    }
                });
            }
            catch (Exception)
            {
                return Json(new { success = "false" });
            }
        }

        [HttpPost("[action]")]
        public IActionResult EditAdditionalEquipment([FromBody]AdditionalEquipmentModel eq)
        {
            if (eq == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _additionalEquipmentService.Edit(eq);
                return Json(new { succes = "true" });
            }
            catch (Exception)
            {
                return Json(new { success = "false" });
            }
        }
    }
}
