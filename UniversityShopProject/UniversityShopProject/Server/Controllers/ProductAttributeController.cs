using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityShopProject.Shared.ViewModels.Product;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;
using UniversityShopProjectServices.Service;

namespace UniversityShopProject.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductAttributeController : ControllerBase
    {
        public IMapper _mapper;
        UniversityShopProjectContext db = new();
        ProductAttributeService _productAttributeService;
        public ProductAttributeController(IMapper mapper)
        {
            _productAttributeService = new ProductAttributeService(db);
            _mapper = mapper;
        }
        [HttpGet("GetPA/{Id}")]
        public ActionResult GetProductAttribute(int Id)
        {
            List<ProductAttribute> list =_productAttributeService.GetAll().FindAll(t=>t.ProductId == Id);
            if(list!=null)
            {
                var listViewModel = _mapper.Map<List<ProductAttribute>, List<ProductAttributeViewModel>>(list);
                return Ok(listViewModel);
            }
            return NotFound("ویژگی یافت نشد");
        }
        [HttpPost("AddAttribute")]
        public ActionResult AddAttribute([FromBody]ProductAttributeViewModel productAttributeViewModel)
        {
            try
            {
                ProductAttribute productAttribute = new ProductAttribute();
                productAttribute = _mapper.Map<ProductAttributeViewModel,ProductAttribute>(productAttributeViewModel);
                _productAttributeService.Add(productAttribute);
                _productAttributeService.Save();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "انجام نشد");
            }
        }

        [HttpPost("DeleteAtt")]
        public ActionResult DeleteAtt([FromBody]int id)
        {
            try
            {
                _productAttributeService.Delete(id);
                _productAttributeService.Save();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "انجام نشد");
            }
        }
    }
}
