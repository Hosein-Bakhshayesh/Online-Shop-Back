using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UniversityShopProject.Shared.ViewModels.Order;
using UniversityShopProject.Shared.ViewModels.Product;
using UniversityShopProject.Shared.ViewModels.User;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;
using UniversityShopProjectServices.Service;

namespace UniversityShopProject.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public IMapper _mapper { get; set; }
        UniversityShopProjectContext db = new();
        OrderService _orderService;
        OrderItemService _orderItemService;
        ProductService _productService;
        CartService _cartService;
        CartItemService _cartItemService;
        UserService _userService;

        public OrderController(IMapper mapper)
        {
            _mapper = mapper;
            _orderService = new OrderService(db);
            _orderItemService = new OrderItemService(db);
            _productService = new ProductService(db);
            _cartItemService = new CartItemService(db);
            _cartService = new CartService(db);
            _userService = new UserService(db);
        }

        [HttpGet("GetAllOrders/{page}")]
        public ActionResult GetAllOrders(int page)
        {
            List<OrderViewModel> orders = _mapper.Map<List<Order>, List<OrderViewModel>>(_orderService.GetAllWithPage(10, page));
            return Ok(orders);
        }

        [HttpGet("TotalPageCount/{size}")]
        public ActionResult TotalPageCount(int size)
        {
            int count = _orderService.GetTotalPageCount(size);
            return Ok(count);
        }

        [HttpPost("DeliverOrder")]
        public ActionResult DeliverOrder([FromBody] int id)
        {
            try
            {
                Order order = _orderService.GetEntity(id);
                if(order != null)
                {
                    order.Status = "تحویل داده شده";
                    _orderService.Update(order);
                }
                _orderService.Save();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetOrderList/{userId}")]
        public ActionResult GetOrderList(int userId)
        {
            List<OrderViewModel> orders = new List<OrderViewModel>();
            orders = _mapper.Map<List<Order>, List<OrderViewModel>>(_orderService.GetAll().FindAll(t => t.UserId == userId));
            orders = orders.FindAll(t => t.IsActive == true);
            return Ok(orders);
        }

        [HttpGet("GetOrderItemsList/{orderId}")]
        public ActionResult GetOrderItemsList(int orderId)
        {
            List<OrderItemViewModel> ordersItems = new List<OrderItemViewModel>();
            ordersItems = _mapper.Map<List<OrderItem>, List<OrderItemViewModel>>(_orderItemService.GetAll().FindAll(t => t.OrderId == orderId));
            ordersItems = ordersItems.FindAll(t => t.IsActive == true);
            return Ok(ordersItems);
        }

        [HttpPut("AddOrder/{cartId}")]
        public ActionResult GetOrderItemsList(int cartId, AddressesViewModel addresses)
        {
            try
            {
                UserInfoViewModel userInfoViewModel = GetCurrentUser();
                int userId = userInfoViewModel.UserId;
                List<CartItem> cartItemViewModels = _cartItemService.GetAll().FindAll(t=>t.CartId == cartId && t.IsActive == true);
                Cart cart = _cartService.GetEntity(cartId);
                User user = _userService.GetEntity(userId);
                Order order = new Order();
                order.UserId = user.UserId;
                order.FirstName = addresses.FirstName;
                order.LastName = addresses.LastName;
                order.Mobile = addresses.Mobile != null ? addresses.Mobile : "0";
                order.Email = user.Email;
                order.ProvinceId = addresses.Province;
                order.CityId = addresses.CityId;
                order.Street = addresses.Street;
                order.Pelak = addresses.Pelak;
                order.Vahed = addresses.Vahed;
                order.PostalCode = addresses.PostalCode;
                order.Total = cart.Total;
                order.IsActive = false;
                order.Date = DateTime.Now.ToString("MM/dd/yyyy");
                order.Status = "در انتظار پرداخت";
                _orderService.Add(order);
                _orderService.Save();
                order = _orderService.GetAll().Find(x => x.UserId == userId && x.Status == "در انتظار پرداخت");
                if (order != null)
                {
                    foreach (var item in cartItemViewModels)
                    {
                        OrderItem orderItem = new OrderItem();
                        orderItem.OrderId = order.OrderId;
                        orderItem.ProductId = item.ProductId;
                        orderItem.Quantity = item.Quantity;
                        orderItem.Total = item.Total;
                        orderItem.IsActive = false;
                        _orderItemService.Add(orderItem);
                        _orderItemService.Save();
                    }
                }
                OrderViewModel viewModel = _mapper.Map<Order,OrderViewModel>(order);
                return Ok(viewModel);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetPaymentOrder/{userId}")]
        public ActionResult GetPaymentOrder(int userId)
        {
            Order? order = new Order();
            OrderViewModel orderViewModel = new OrderViewModel();
            order = _orderService.GetAll().Find(t => t.UserId == userId && t.IsActive == false);
            if (order != null)
            {
                orderViewModel = _mapper.Map<Order, OrderViewModel>(order);
                return Ok(orderViewModel);
            }
            return Ok(orderViewModel);
        }

        [HttpPost("PaymentSuccess")]
        public ActionResult PaymentSuccess(OrderViewModel orderViewModel)
        {
            UserInfoViewModel userInfoViewModel = GetCurrentUser();
            if (orderViewModel != null)
            {
                Order order = _mapper.Map<OrderViewModel,Order>(orderViewModel);
                order.IsActive = true;
                order.Status = "پرداخت موفق";
                List<OrderItem> orderItems = _orderItemService.GetAll().FindAll(t=>t.OrderId == orderViewModel.OrderId);
                foreach (var item in orderItems)
                {
                    item.IsActive = true;
                    _orderItemService.Update(item);
                }
                _orderItemService.Save();
                Cart cart = _cartService.GetAll().Find(t => t.UserId == userInfoViewModel.UserId && t.IsActive == true);
                cart.IsActive = false;
                var cartItem = _cartService.GetAll().FindAll(t => t.CartId == cart.CartId);
                foreach (var item in cartItem)
                {
                    item.IsActive = false;
                    _cartService.Update(item);
                }
                _cartItemService.Save();
                _cartService.Update(cart);
                _cartService.Save();
                _orderService.Update(order);
                _orderService.Save();
                return Ok();
            }
            return NotFound();
        }

        [HttpPost("PaymentError")]
        public ActionResult PaymentError(OrderViewModel orderViewModel)
        {
            if (orderViewModel != null)
            {
                Order order = _mapper.Map<OrderViewModel, Order>(orderViewModel);
                order.IsActive = true;
                order.Status = "پرداخت ناموفق";
                List<OrderItem> orderItems = _orderItemService.GetAll().FindAll(t => t.OrderId == orderViewModel.OrderId);
                foreach (var item in orderItems)
                {
                    item.IsActive = true;
                    _orderItemService.Update(item);
                }
                _orderItemService.Save();
                _orderService.Update(order);
                _orderService.Save();
                return Ok();
            }
            return NotFound();
        }

        [HttpPost("ProductCountDown")]
        public ActionResult ProductCountDown(OrderViewModel orderViewModel)
        {
            UserInfoViewModel userInfoViewModel = GetCurrentUser();
            if (orderViewModel != null)
            {
                List<OrderItem> orderItems = _orderItemService.GetAll().FindAll(t => t.OrderId == orderViewModel.OrderId);
                foreach (var item in orderItems)
                {
                    Product product = _productService.GetEntity(item.ProductId);
                    for (int i = 0; i < item.Quantity; i++)
                    {
                        if (product.Number > 0)
                        {
                            product.Number--;
                        }
                    }
                    _productService.Update(product);
                }
                _productService.Save();
                return Ok();
            }
            return NotFound();
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
