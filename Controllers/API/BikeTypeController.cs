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
    public class BikeTypeController : Controller
    {
        private readonly IBikeTypeService _bikeTypeService;

        public BikeTypeController(IBikeTypeService bikeTypeService)
        {
            this._bikeTypeService = bikeTypeService;
        }

        [HttpGet]
        public IActionResult GetBikeTypes()
        {
            try
            {
                var bikeTypes = _bikeTypeService.GetAllBikeTypes().Select(bikeType => new
                {
                    name = bikeType.Name
                }).ToList();

                return Json(new { bikeTypes = bikeTypes });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
