using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bikes_project.Data;
using bikes_project.ViewModels;
using bikes_project.Models;
using bikes_project.Services;

namespace bikes_project.Controllers
{
    [Route("api/[controller]")]
    public class BikeConditionController : Controller
    {
        private readonly IBikeConditionService _bikeConditionService;

        public BikeConditionController(IBikeConditionService bikeConditionService)
        {
            this._bikeConditionService = bikeConditionService;
        }

        [HttpGet]
        public IActionResult GetBikeConditions()
        {
            try
            {
                var bikeConditions = _bikeConditionService.GetAllBikeConditions().Select(bikeCondition => new
                {
                    name = bikeCondition.Name
                }).ToList();

                return Json(new { bikeConditions = bikeConditions });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
