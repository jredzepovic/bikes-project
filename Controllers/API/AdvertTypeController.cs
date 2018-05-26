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
    public class AdvertTypeController : Controller
    {
        private readonly IAdvertTypeService _advertTypeService;

        public AdvertTypeController(IAdvertTypeService advertTypeService)
        {
            this._advertTypeService = advertTypeService;
        }

        [HttpGet]
        public IActionResult GetAdvertTypes()
        {
            try
            {
                var advertTypes = _advertTypeService.GetAllAdvertTypes().Select(advertType => new
                {
                    name = advertType.Name
                }).ToList();

                return Json(new { advertTypes = advertTypes });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
