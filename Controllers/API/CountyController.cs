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
    public class CountyController : Controller
    {
        private readonly ICountyService _countyService;

        public CountyController(ICountyService countyService)
        {
            this._countyService = countyService;
        }

        [HttpGet]
        public IActionResult GetCounties()
        {
            try
            {
                var counties = _countyService.GetAllCounties().Select(county => new
                {
                    Name = county.Name
                }).ToList();

                return Json(new { counties = counties });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
