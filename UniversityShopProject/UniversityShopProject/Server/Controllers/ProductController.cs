using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UniversityShopProject.Shared.ViewModels;
using UniversityShopProject.Shared.ViewModels.Product;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;
using UniversityShopProjectServices.Service;
using System.IO;
using UniversityShopProject.Shared.Models;

namespace UniversityShopProject.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IMapper _mapper { get; set; }
        UniversityShopProjectContext db = new();
        ProductService _productService;

        public ProductController(IMapper mapper)
        {
            _productService = new ProductService(db);
            _mapper = mapper;
        }

        [HttpGet("List/{id}")]
        public ActionResult ProductList(int id)
        {
            List<Product> products;
            products = _productService.GetAll().FindAll(t => t.CategoryId == id);
            List<ProductViewModel> productVM = _mapper.Map<List<Product>, List<ProductViewModel>>(products);
            if (productVM != null)
            {
                return Ok(productVM);
            }
            else
            {
                return NotFound("Product Not Exist");
            }

        }

        [HttpDelete("Delete/{Pid}")]
        public ActionResult DeleteProduct(int Pid)
        {
            try
            {
                _productService.Delete(Pid);
                _productService.Save();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "حذف انجام نشد");
            }

        }
        [HttpGet("Info/{id}")]
        public ActionResult ProductInfo(int id)
        {
            try
            {
                Product product = _productService.GetEntity(id);
                ProductViewModel model = _mapper.Map<Product, ProductViewModel>(product);
                if (model != null)
                {
                    return Ok(model);
                }
                else
                {
                    return NotFound("Product Not Exist");
                }
            }
            catch
            {
                return NotFound("محصولی یافت نشد.");
            }
        }

        [HttpPost("Add")]
        public ActionResult ProductAdd(ProductViewModel ProductAdd)
        {
            ProductAdd.ProductImagePath = Guid.NewGuid().ToString().Replace("-", "");
            Product product = _mapper.Map<ProductViewModel, Product>(ProductAdd);
            try
            {
                _productService.Add(product);
                _productService.Save();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "انجام نشد");
            }
            
        }

        [HttpPost("SaveImage")]
        public ActionResult SaveImage(ImageFile imageFile)
        {
            try
            {
                string fileExtenstion = imageFile.Files.FileType.ToLower().Contains("jpg") ? "jpg" : "";
                string fileName = $@"/Images/Product-Image/{imageFile.Files.FileName}.{fileExtenstion}";
                var fileStream = System.IO.File.Create(fileName);
                fileStream.WriteAsync(imageFile.Files.Data);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "انجام نشد");
            }
        }
    }
}
