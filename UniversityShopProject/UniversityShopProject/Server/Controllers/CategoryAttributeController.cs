using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityShopProject.Shared.ViewModels;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;
using UniversityShopProjectServices.Service;

namespace UniversityShopProject.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryAttributeController : ControllerBase
    {
        public IMapper _mapper { get; set; }
        UniversityShopProjectContext db = new();
        CategoryAttributeService _CategoryAttributeService;

        public CategoryAttributeController(IMapper mapper)
        {
            _mapper = mapper;
            _CategoryAttributeService = new CategoryAttributeService(db);
        }

        [HttpGet("List/{id}")]
        public ActionResult GetAllAttribute(int id)
        {
            List<CategoryAttribute> attribute = _CategoryAttributeService.GetAll().FindAll(t=> t.CategoryId == id);
            List<CategoryAttributeViewModel> categoryAttribute = _mapper.Map<List<CategoryAttribute>, List<CategoryAttributeViewModel>>(attribute);
            if(categoryAttribute == null)
            {
                return NotFound("پیدا نشد.");
            }
            return Ok(categoryAttribute);
        }
        [HttpPost("Create")]
        public ActionResult AddNewAttributes(CategoryAttributeViewModel model)
        {
            if(model != null)
            {
                CategoryAttribute attribute = _mapper.Map<CategoryAttributeViewModel, CategoryAttribute>(model);
                _CategoryAttributeService.Add(attribute);
                _CategoryAttributeService.Save();
                return Ok();
            }
            else
            {
                return NotFound("مشکلی رخ داده است !");
            }
        }
        [HttpDelete("Delete/{id}")]
        public ActionResult DeleteAttribute(int id)
        {
            
            CategoryAttribute attribute = _CategoryAttributeService.GetEntity(id);
            try
            {
                _CategoryAttributeService.Delete(attribute);
                _CategoryAttributeService.Save();
                return Ok();
            }
            catch
            {
                return NotFound("مشکلی رخ داده است !");
            }
            
        }
        [HttpPut("Edit")]
        public ActionResult EditAttributes(List<CategoryAttributeViewModel> model)
        {
            List<CategoryAttribute> attributes = _mapper.Map<List<CategoryAttributeViewModel>, List<CategoryAttribute>>(model);
            try
            {
                foreach (var item in attributes)
                {
                    _CategoryAttributeService.Update(item);
                }
                _CategoryAttributeService.Save();
                return Ok();
            }
            catch
            {
                return NotFound("مشکلی رخ داده است !");
            }
        }
    }
}
