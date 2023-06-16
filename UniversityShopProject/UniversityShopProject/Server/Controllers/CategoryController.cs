using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UniversityShopProject.Shared.ViewModels;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;
using UniversityShopProjectServices.Service;

namespace UniversityShopProject.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public IMapper _mapper;
        UniversityShopProjectContext db = new();
        CategoryService _categoryService;
        public CategoryController(IMapper mapper)
        {
            _categoryService = new CategoryService(db);
            _mapper = mapper;
        }
        [HttpGet("List")]
        public ActionResult CategoryList()
        {
            List<Category> categories = _categoryService.GetAll();
            List<CategoryViewModel> categoryViews = _mapper.Map<List<Category>, List<CategoryViewModel>>(categories);
            if (categoryViews != null)
            {
                return Ok(categoryViews);
            }
            return NotFound("دسته بندی یافت نشد.");
        }

        [HttpGet("Info/{categoryId}")]
        public ActionResult CategoryInfo(int categoryId)
        {
            Category category = _categoryService.GetEntity(categoryId);
            CategoryViewModel categoryView = _mapper.Map<Category, CategoryViewModel>(category);
            if (categoryView != null)
            {
                return Ok(categoryView);
            }
            else
            {
                return NotFound("مشکلی پیش آمده...");
            }

        }

        [HttpGet("ChildInfo/{id}")]
        public ActionResult CategoryChildInfo(int id)
        {
            List<Category> category = _categoryService.GetAll();
            List<CategoryViewModel> categoryView = _mapper.Map<List<Category>, List<CategoryViewModel>>(category);
            categoryView = categoryView.FindAll(t => t.ParentId == id);
            if (categoryView != null)
            {
                return Ok(categoryView);
            }
            else
            {
                return Ok();
            }

        }

        [HttpPut("Edit")]
        public ActionResult CategoryEdit(CategoryViewModel categoryView)
        {
            Category category = _mapper.Map<CategoryViewModel, Category>(categoryView);
            try
            {
                if (category == null)
                {
                    return NotFound("User Not Found !");
                }
                _categoryService.Update(category);
                _categoryService.Save();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "بروزرسانی انجام نشد");

            }

        }
        [HttpPut("EditChild")]
        public ActionResult CategoryChildEdit(List<CategoryViewModel> categories)
        {
            List<Category> category = _mapper.Map<List<CategoryViewModel>, List<Category>>(categories);
            try
            {
                if (category == null)
                {
                    return NotFound("User Not Found !");
                }
                foreach (var item in category)
                {
                    _categoryService.Update(item);
                }
                _categoryService.Save();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "بروزرسانی انجام نشد");

            }

        }
        [HttpPost("Delete")]
        public ActionResult DeleteCategory(CategoryViewModel categoryView)
        {
            Category category = _mapper.Map<CategoryViewModel, Category>(categoryView);
            try
            {
                if(category ==null)
                {
                    return NotFound("User Not Found !");
                }

                _categoryService.Delete(category);
                _categoryService.Save();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "بروزرسانی انجام نشد");
            }
        }
        [HttpPost("Create")]
        public ActionResult CreateCategory(CategoryViewModel categoryView)
        {
            Category category = _mapper.Map<CategoryViewModel, Category>(categoryView);
            try
            {
                if (category == null)
                {
                    return NotFound("User Not Found !");
                }
                _categoryService.Add(category);
                _categoryService.Save();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "بروزرسانی انجام نشد");
            }
        }
    }
}
