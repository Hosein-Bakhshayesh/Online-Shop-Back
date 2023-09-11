using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityShopProject.Shared.ViewModels.Product;
using UniversityShopProject.Shared.ViewModels.WishList;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;
using UniversityShopProjectServices.Service;

namespace UniversityShopProject.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        public IMapper _mapper { get; set; }
        UniversityShopProjectContext db = new();
        WishListService _wishListService;
        ProductService _productService;
        public WishListController(IMapper mapper)
        {
            _mapper = mapper;
            _wishListService = new WishListService(db);
            _productService = new ProductService(db);
        }

        [HttpGet("GetWishList/{userId}")]
        public ActionResult GetWishList(int userId)
        {
            List<WishListViewModel> wishListViewModel = _mapper.Map<List<WishList>, List<WishListViewModel>>(_wishListService.GetAll().FindAll(t => t.UserId == userId));
            List<ProductViewModel> Products = new List<ProductViewModel>();
            if (wishListViewModel.Count > 0)
            {
                List<Product> WishProducts = new List<Product>();
                foreach (var item in wishListViewModel)
                {
                    WishProducts.Add(_productService.GetEntity(item.ProductId));
                }
                Products = _mapper.Map<List<Product>, List<ProductViewModel>>(WishProducts);
                return Ok(Products);
            }
            return Ok(Products);
        }

        [HttpGet("AddToWishList/{userId}/{prodictId}")]
        public ActionResult AddToWishList(int userId, int prodictId)
        {
            try
            {
                List<WishList> wishLists = _wishListService.GetAll();
                if (!wishLists.Any(t => t.UserId == userId && t.ProductId == prodictId))
                {
                    WishList wishList = new WishList();
                    wishList.ProductId = prodictId;
                    wishList.UserId = userId;
                    _wishListService.Add(wishList);
                    _wishListService.Save();
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("DeleteFromWishList/{userId}/{prodictId}")]
        public ActionResult DeleteFromWishList(int userId, int prodictId)
        {
            try
            {
                WishList wishList = _wishListService.GetAll().Find(t=>t.UserId==userId && t.ProductId==prodictId);
                _wishListService.Delete(wishList);
                _wishListService.Save();
                return Ok(true);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
