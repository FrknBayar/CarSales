using Car.Services.Abstract;
using Car.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Car.API.Controllers
{
    [Route("api/cars")]
    [ApiController]
    [Authorize]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPatch]
        public async Task<IActionResult> AddOrUpdate([FromBody] CarRequestModel carRequestModel)
        {
            return Ok(await _carService.CreateOrUpdateCarAsync(carRequestModel));
        }
    }
}
