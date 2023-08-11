using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityShopProject.Shared.Models;
using UniversityShopProject.Shared.ViewModels.Product;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;
using UniversityShopProjectServices.Service;

namespace UniversityShopProject.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        public IMapper _mapper { get; set; }
        UniversityShopProjectContext db = new();
        ProductImageService _productImageService;
        ProductService _productService;

        public ProductImageController(IMapper mapper)
        {
            _mapper = mapper;
            _productImageService = new ProductImageService(db);
            _productService = new ProductService(db);
        }
        [HttpGet("GetImages/{Id}")]
        public ActionResult GetAllImages(int id)
        {
            List<ProductImage> images = _productImageService.GetAll().FindAll(t => t.ProductId == id);
            if (images != null)
            {
                List<ProductImagesViewModel> list = _mapper.Map<List<ProductImage>, List<ProductImagesViewModel>>(images);
                return Ok(list);
            }
            return NotFound("یافت نشد.");
        }
        [HttpPut("Save/{id}")]
        public async Task<ActionResult> SaveImage(ImageFile file, int id)
        {
            try
            {
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.fileName);
                    string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()) + "\\Client\\wwwroot\\Images\\Product-Image\\" + fileName);
                    var buf = Convert.FromBase64String(file.base64data);
                    await System.IO.File.WriteAllBytesAsync(path, buf);
                    ProductImage productImage = new ProductImage();
                    productImage.ProductId = id;
                    productImage.ImagePath = fileName;
                    _productImageService.Add(productImage);
                    _productImageService.Save();
                }
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "انجام نشد");
            }
        }
        [HttpPut("EditProductImage/{Id}")]
        public async Task<ActionResult> EditProductImage(ImageFile file, int id)
        {
            try
            {
                var product = _productService.GetEntity(id);
                if (product != null)
                {
                    var fileName = product.ProductImagePath;
                    string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()) + "\\Client\\wwwroot\\Images\\Product-Image\\" + fileName);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.fileName);
                    product.ProductImagePath = fileName;
                    path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()) + "\\Client\\wwwroot\\Images\\Product-Image\\" + fileName);
                    var buf = Convert.FromBase64String(file.base64data);
                    await System.IO.File.WriteAllBytesAsync(path, buf);
                    _productService.Update(product);
                    _productService.Save();
                }
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "انجام نشد");
            }
        }
    }
}
