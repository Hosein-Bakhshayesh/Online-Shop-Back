using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityShopProject.Shared.ViewModels.User;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;
using UniversityShopProjectServices.Service;

namespace UniversityShopProject.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        public IMapper _mapper { get; set; }
        UniversityShopProjectContext db = new();
        AddressService _addressService;
        CityService _cityService;
        ProvinceService _provinceService;

        public AddressController(IMapper mapper)
        {
            _mapper = mapper;
            _addressService = new AddressService(db);
            _cityService = new CityService(db);
            _provinceService = new ProvinceService(db);
        }

        [HttpGet("Addresses/{userId}")]
        public ActionResult Addresses(int userId)
        {
            List<AddressesViewModel> addressesViewModel = _mapper.Map<List<Address>, List<AddressesViewModel>>(_addressService.GetAll().FindAll(t => t.UserId == userId));
            foreach (var item in addressesViewModel)
            {
                item.cityName = _cityService.GetEntity(item.CityId).Name;
            }
            return Ok(addressesViewModel);
        }

        [HttpGet("GetProvince")]
        public ActionResult GetProvince()
        {
            List<Province> provinces = _provinceService.GetAll();
            return Ok(provinces);
        }

        [HttpGet("GetCity")]
        public ActionResult GetCity()
        {
            List<City> Cities = _cityService.GetAll();
            return Ok(Cities);
        }

        [HttpGet("City/{id}")]
        public ActionResult GetCity(int id)
        {
            List<City> Cities = _cityService.GetAll().FindAll(t => t.ProvinceId == id);
            return Ok(Cities);
        }

        [HttpPost("AddAddress")]
        public ActionResult AddAddress(AddressesViewModel addressesViewModel)
        {
            if (addressesViewModel != null)
            {
                Address address = new Address();
                address = _mapper.Map<AddressesViewModel, Address>(addressesViewModel);
                _addressService.Add(address);
                _addressService.Save();
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("DeleteAddress/{Id}")]
        public ActionResult DeleteAddress(int Id)
        {
            try
            {
                _addressService.Delete(Id);
                _addressService.Save();
                return Ok(true);
            }
            catch
            {
                return Ok(false);
            }

        }

    }
}
