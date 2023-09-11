using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UniversityShopProject.Shared.ViewModels.Product;
using UniversityShopProject.Shared.ViewModels.User;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;
using UniversityShopProjectServices.Service;

namespace UniversityShopProject.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public IMapper _mapper { get; set; }
        UniversityShopProjectContext db = new();
        CartService _cartService;
        CartItemService _cartItemService;
        ProductService _productService;
        UserService _userService;

        public CartController(IMapper mapper)
        {
            _mapper = mapper;
            _cartItemService = new CartItemService(db);
            _cartService = new CartService(db);
            _productService = new ProductService(db);
            _userService = new UserService(db);
        }

        [HttpGet("AddToCart/{userId}/{productId}")]
        public ActionResult AddToCart(int productId, int userId)
        {
            Product product = _productService.GetEntity(productId);
            if (product != null)
            {
                Cart? cart = _cartService.GetAll().Find(t => t.UserId == userId && t.IsActive == true);
                if (cart == null)
                {
                    cart = new Cart();
                    cart.UserId = userId;
                    cart.IsActive = true;
                    cart.Total = 0.ToString();
                    _cartService.Add(cart);
                    _cartService.Save();
                    cart = _cartService.GetAll().Find(t => t.UserId == userId && t.IsActive == true);
                }
                List<CartItem> cartItems = new List<CartItem>();
                cartItems = _cartItemService.GetAll().FindAll(t => t.CartId == cart.CartId && t.IsActive == true);
                CartItem? cartItem = cartItems.Find(t => t.ProductId == product.ProductId);
                if (cartItem != null)
                {
                    cartItem.Quantity += 1;
                    cartItem.Total = (cartItem.Quantity * Convert.ToInt32(product.Price)).ToString();
                    _cartItemService.Update(cartItem);
                    _cartItemService.Save();
                }
                else
                {
                    cartItem = new CartItem();
                    cartItem.ProductId = product.ProductId;
                    cartItem.CartId = cart.CartId;
                    cartItem.Total = product.Price;
                    cartItem.Quantity = 1;
                    cartItem.IsActive = true;
                    _cartItemService.Add(cartItem);
                    _cartItemService.Save();
                }
                cartItems = _cartItemService.GetAll().FindAll(t => t.CartId == cart.CartId && t.IsActive == true);
                foreach (var item in cartItems)
                {
                    cart.Total = (Convert.ToInt32(cart.Total) + Convert.ToInt32(item.Total)).ToString();
                }
                _cartService.Update(cart);
                _cartItemService.Save();
                TotalCal();
                return Ok(true);

            }
            return BadRequest(false);
        }

        [HttpGet("GetItems/{cartId}")]
        public ActionResult GetItems(int cartId)
        {
            List<CartItem> cartItems = new List<CartItem>();
            cartItems = _cartItemService.GetAll().FindAll(t => t.CartId == cartId && t.IsActive == true);
            List<CartItemViewModel> List = _mapper.Map<List<CartItem>, List<CartItemViewModel>>(cartItems);
            TotalCal();
            return Ok(List);
        }

        [HttpGet("GetActiveCart")]
        public ActionResult GetActiveCart()
        {
            UserInfoViewModel userInfoViewModel = GetCurrentUser();
            Cart cart = new Cart();
            cart = _cartService.GetAll().Find(t => t.UserId == userInfoViewModel.UserId && t.IsActive == true);
            CartViewModel cartViewModel = _mapper.Map<Cart,CartViewModel>(cart);
            if(cart == null)
            {
                return Ok(cartViewModel);
            }
            TotalCal();
            return Ok(cartViewModel);
        }

        [HttpPost("DeleteCartItem")]
        public ActionResult DeleteCartItem(CartItemViewModel cartItemViewModel)
        {
            try
            {
                CartItem cartItem = _cartItemService.GetEntity(cartItemViewModel.CartItemId);
                if (cartItem.Quantity > 1)
                {
                    Product product = _productService.GetEntity(cartItem.ProductId);
                    cartItem.Quantity--;
                    cartItem.Total = (cartItem.Quantity * Convert.ToInt32(product.Price)).ToString();
                    _cartItemService.Update(cartItem);
                    _cartItemService.Save();
                    TotalCal();
                    return Ok();
                }
                else
                {
                    _cartItemService.Delete(cartItem);
                    _cartItemService.Save();
                    TotalCal();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        public ActionResult TotalCal()
        {
            UserInfoViewModel userInfoViewModel = GetCurrentUser();
            Cart cart = new Cart();
            cart = _cartService.GetAll().Find(t => t.UserId == userInfoViewModel.UserId && t.IsActive == true);
            if(cart != null)
            {
                List<CartItem> cartItems = new List<CartItem>();
                cartItems = _cartItemService.GetAll().FindAll(t => t.CartId == cart.CartId && t.IsActive == true);
                cart.Total = "0";
                foreach (var item in cartItems)
                {
                    cart.Total = (Convert.ToInt32(cart.Total) + Convert.ToInt32(item.Total)).ToString();
                }
                _cartService.Update(cart);
                _cartService.Save();
            }
            return Ok();
        }

        public UserInfoViewModel GetCurrentUser()
        {
            UserInfoViewModel userInfoViewModel = new UserInfoViewModel();
            if (User.Identity != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    User user = new User();
                    user.UserName = User.FindFirstValue(ClaimTypes.Name);
                    user = _userService.GetAll().Find(t => t.UserName == user.UserName);
                    userInfoViewModel = _mapper.Map<User, UserInfoViewModel>(user);
                }
            }
            return userInfoViewModel;
        }



    }
}
