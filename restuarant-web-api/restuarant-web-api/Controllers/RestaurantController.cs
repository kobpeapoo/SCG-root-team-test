using Microsoft.AspNetCore.Mvc;
using restaurant_web_api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restuarant_web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _service;
        public RestaurantController(IRestaurantService service)
        {
            this._service = service;
        }
        [HttpGet("{areaName}")]
        public async Task<IActionResult> GetRestuarant(string areaName)
        {
            try
            {
                //Call Get data
                var result = await _service.GetRestaurant(areaName);
                if (result.results.Count == 0)
                {
                    //Return No content if data not found
                    return NoContent();
                }
                //Return data
                return Ok(new JsonResult(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
