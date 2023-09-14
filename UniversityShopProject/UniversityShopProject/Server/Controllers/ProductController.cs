using AutoMapper;
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
    public class ProductController : ControllerBase
    {
        public IMapper _mapper { get; set; }
        UniversityShopProjectContext db = new();
        ProductService _productService;
        CategoryService _categoryService;
        ProductImageService _productImageService;
        private readonly IWebHostEnvironment env;
        public static string ImageFileName = "1.jpg";
        public ProductController(IMapper mapper, IWebHostEnvironment env)
        {
            _productService = new ProductService(db);
            _productImageService = new ProductImageService(db);
            _categoryService = new CategoryService(db);
            _mapper = mapper;
            this.env = env;
        }

        [HttpGet("List/{id}")]
        public ActionResult ProductList(int id)
        {
            var categoty = _categoryService.GetEntity(id);
            if (categoty == null)
            {
                return NotFound("Product Not Exist");
            }
            if (categoty.ParentId != null)
            {
                List<Product> products;
                products = _productService.GetAll().FindAll(t => t.CategoryId == id);
                List<ProductViewModel> productVM = _mapper.Map<List<Product>, List<ProductViewModel>>(products);
                productVM.Reverse();
                if (productVM != null)
                {
                    return Ok(productVM);
                }
            }
            else
            {
                var categories = _categoryService.GetAll().FindAll(t => t.ParentId == id);
                List<ProductViewModel> productViewModels = new List<ProductViewModel>();
                foreach (var item in categories)
                {
                    List<Product> products;
                    products = _productService.GetAll().FindAll(t => t.CategoryId == id);
                    List<ProductViewModel> productVM = _mapper.Map<List<Product>, List<ProductViewModel>>(products);
                    productViewModels.AddRange(productVM);
                }
                productViewModels.Reverse();
                if (productViewModels != null)
                {
                    return Ok(productViewModels);
                }
            }
            return NotFound("Product Not Exist");
        }

        [HttpGet("List/{id}/{page}")]
        public ActionResult ProductList(int id, int page)
        {
            List<Product> products;
            products = _productService.GetAllWithPage(id, 15, page);
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
        [HttpGet("TotalPageCount/{size}/{id}")]
        public ActionResult TotalPageCount(int size, int id)
        {
            int count = _productService.GetTotalPageCount(size, id);

            return Ok(count);
        }

        [HttpDelete("Delete/{Pid}")]
        public ActionResult DeleteProduct(int Pid)
        {
            try
            {
                Product product = _productService.GetEntity(Pid);
                string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()) + "\\Client\\wwwroot\\Images\\Product-Image\\" + product.ProductImagePath);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                var list = _productImageService.GetAll().FindAll(t => t.ProductId == Pid);
                foreach (var item in list)
                {
                    path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()) + "\\Client\\wwwroot\\Images\\Product-Image\\" + item.ImagePath);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    _productImageService.Delete(item);
                }
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

        [HttpPost("Create")]
        public ActionResult ProductCreate([FromBody] ProductViewModel ProductAdd)
        {
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

        [HttpPut("SaveImage/{fileName}")]
        public async Task<ActionResult> ProductSaveImage([FromBody] ImageFile file, string fileName)
        {
            try
            {
                if (file != null)
                {
                    ImageFileName = fileName;
                    string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()) + "\\Client\\wwwroot\\Images\\Product-Image\\" + fileName);
                    var buf = Convert.FromBase64String(file.base64data);
                    await System.IO.File.WriteAllBytesAsync(path, buf);
                }
                return Content(ImageFileName);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "انجام نشد");
            }
        }
        [HttpPut("SubmitEdit/{Id}")]
        public ActionResult SubmitEdit(ProductInfoViewModel productInfoViewModel, int Id)
        {
            try
            {
                if (productInfoViewModel != null && Id > 0)
                {
                    var p = _productService.GetEntity(Id);
                    if (p != null)
                    {
                        p.ProductName = productInfoViewModel.ProductName;
                        p.ProductDiscription = productInfoViewModel.ProductDiscription;
                        p.Price = productInfoViewModel.Price;
                        p.Number = productInfoViewModel.Number;
                        p.IsActive = productInfoViewModel.IsActive;
                        bool res = _productService.Update(p);
                        _productService.Save();
                    }
                }
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "انجام نشد");
            }
        }

        [HttpGet("GetLast")]
        public ActionResult GetLastProduct()
        {
            var LastProduct = _productService.GetLastProduct();
            if (LastProduct != null)
            {
                List<ProductViewModel> products = new List<ProductViewModel>();
                products = _mapper.Map<List<Product>, List<ProductViewModel>>(LastProduct);
                return Ok(products);
            }
            return NotFound("محصولی یافت نشد.");
        }
        [HttpGet("GetMostView")]
        public ActionResult GetMostView()
        {
            var LastProduct = _productService.GetMostView();
            if (LastProduct != null)
            {
                List<ProductViewModel> products = new List<ProductViewModel>();
                products = _mapper.Map<List<Product>, List<ProductViewModel>>(LastProduct);
                return Ok(products);
            }
            return NotFound("محصولی یافت نشد.");
        }

        [HttpPost("AddView")]
        public ActionResult AddView([FromBody] int id)
        {
            try
            {
                Product product = _productService.GetEntity(id);
                if (product.Views == null)
                {
                    product.Views = 1;
                }
                else
                {
                    product.Views++;
                }
                _productService.Update(product);
                _productService.Save();
                return Ok();
            }
            catch
            {
                return NotFound("محصولی یافت نشد.");
            }
        }

    }
}
