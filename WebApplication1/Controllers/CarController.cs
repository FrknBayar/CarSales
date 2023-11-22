using Entities.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Abstract;
using Services.Abstract;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IGenericService<CarSales> _service;
        public CarController(IGenericService<CarSales> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllInfos()
        {
            var cars = _service.GetAll();
            return Ok(cars);
        }

        [HttpPost]
        public IActionResult AddCar([FromBody] CarSales car)
        {
            _service.Add(car);
            return Ok(car);
        }
    }
}
