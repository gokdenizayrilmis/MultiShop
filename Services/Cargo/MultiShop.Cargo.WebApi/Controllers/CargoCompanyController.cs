using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concreate;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _cargoCompanyService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany()
        {

            return Ok();
        }

        [HttpDelete]
        public IActionResult RemoveCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Kargo Şirketi Başarıyla Silindi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var value = _cargoCompanyService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(CargoCompany cargoCompany)
        {
            _cargoCompanyService.TUpdate(cargoCompany);
            return Ok("Kargo Şirketi Başarıyla Güncellendi!");
        }

    }
}
