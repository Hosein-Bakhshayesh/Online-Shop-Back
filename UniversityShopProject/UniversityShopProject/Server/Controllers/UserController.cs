using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UniversityShopProject.Shared.ViewModels.Auth;
using UniversityShopProject.Shared.ViewModels.User;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;
using UniversityShopProjectServices.Service;

namespace UniversityShopProject.Server.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IMapper _mapper { get; set; }
        UniversityShopProjectContext db = new();
        UserService _userService;
        public UserController(IMapper mapper)
        {
            _userService = new UserService(db);
            _mapper = mapper;
        }
        [HttpGet("List")]
        public ActionResult UserList()
        {
            List<User> users = _userService.GetAll();
            List<UserListViewModel> usersVM = _mapper.Map<List<User>, List<UserListViewModel>>(users);


            if (usersVM != null)
            {
                return Ok(usersVM);
            }
            else
            {
                return NotFound("User Not Exist");
            }
        }
        [HttpGet("Info/{userid}")]
        public ActionResult UserInfo(int userid)
        {
            User user = new User();
            user = _userService.GetEntity(userid);
            UserInfoViewModel userInfo = _mapper.Map<User, UserInfoViewModel>(user);
            if (user != null)
            {
                return Ok(userInfo);
            }
            else
            {
                return NotFound("User Not Found");
            }
        }
        [HttpPut("Edit")]
        public ActionResult EditUser(UserInfoViewModel userInfo)
        {
            User user = _mapper.Map<UserInfoViewModel, User>(userInfo);
            try
            {
                if (user == null)
                {
                    return NotFound("User Not Found !");
                }
                _userService.Update(user);
                _userService.Save();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "بروزرسانی انجام نشد");
            }
        }
        [HttpPost("Delete")]
        public ActionResult DeleteUser([FromBody] int userID)
        {
            try
            {
                _userService.Delete(userID);
                _userService.Save();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "عملیات حذف انجام نشد");
            }
        }

        [HttpPut("Delete")]
        public ActionResult DeleteUser(UserListViewModel userInfo)
        {
            User user = _mapper.Map<UserListViewModel, User>(userInfo);
            try
            {
                if (user == null)
                {
                    return NotFound("User Not Found !");
                }
                _userService.Delete(user);
                _userService.Save();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "عملیات حذف انجام نشد");
            }
        }

        [HttpPost("Create")]
        public ActionResult CreateUser(UserCreateViewModel userCreate)
        {
            User user = _mapper.Map<UserCreateViewModel, User>(userCreate);
            try
            {
                if (user == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "با مشکل مواجه شد");
                }
                else
                {
                    if (_userService.CheckUserName(user.UserName) == true)
                    {
                        return NotFound("کاربری با این نام کاربری قبلا ثبت شده است");
                    }
                    if (_userService.CheckMobileNumber(user.MobileNumber) == false)
                    {
                        return NotFound("کاربری با این شماره موبایل قبلا ثبت شده است");
                    }
                    _userService.Add(user);
                    _userService.Save();
                    return Ok();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "عملیات درج کاربر انجام نشد");
            }
        }

        [HttpGet("CheckUserNameAdd/{UserName}/{mobile}")]
        public ActionResult CheckUserNameAdd(string UserName, string mobile)
        {
            if (_userService.CheckUserName(UserName) == true)
            {
                return Ok(false);
            }
            if (_userService.CheckMobileNumber(mobile) == false)
            {
                return Ok(false);
            }
            else
            {
                return Ok(true);
            }

        }

        [HttpPost("LoginUser")]
        public ActionResult Login(LoginRequest userRequest)
        {
            User? user = _userService.GetAll().Where(t => t.UserName == userRequest.UserName && t.Password == userRequest.Password).FirstOrDefault();
            if (user != null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, "User"),
                };
                var claimIdentity = new ClaimsIdentity(claims, "ServerAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimIdentity);
                AuthenticationHttpContextExtensions.SignInAsync(HttpContext, claimsPrincipal);
            }
            return Ok(user);
        }

        [HttpGet("GetCurrentUser")]
        public ActionResult GetCurrentUser()
        {
            UserInfoViewModel userInfoViewModel = new UserInfoViewModel();
            if (User.Identity != null)
            {
                if (User.Identity.IsAuthenticated && User.IsInRole("User"))
                {
                    User user = new User();
                    user.UserName = User.FindFirstValue(ClaimTypes.Name);
                    user = _userService.GetAll().Find(t => t.UserName == user.UserName);
                    userInfoViewModel = _mapper.Map<User, UserInfoViewModel>(user);
                }
            }
            return Ok(userInfoViewModel);
        }

        [HttpGet("LogOutUser")]
        public ActionResult LogOutUser()
        {
            AuthenticationHttpContextExtensions.SignOutAsync(HttpContext);
            return Ok(true);
        }

        [HttpGet("CheckUserName/{userName}")]
        public ActionResult CheckUserName(string userName)
        {
            bool isExist = false;
            if (!string.IsNullOrEmpty(userName))
            {
                isExist = _userService.CheckUserName(userName);
            }
            return Ok(isExist);
        }

        [HttpPost("RegisterUser")]
        public ActionResult RegisterUser(RegisterViewModel registerViewModel)
        {
            User user = new User();
            if (registerViewModel != null)
            {
                user.Email = registerViewModel.Email;
                user.UserName = registerViewModel.UserName;
                user.Password = registerViewModel.Password;
                user.IsActive = true;
                _userService.Add(user);
                _userService.Save();
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, "User"),
                };
                var claimIdentity = new ClaimsIdentity(claims, "ServerAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimIdentity);
                AuthenticationHttpContextExtensions.SignInAsync(HttpContext, claimsPrincipal);
                return Ok(user);
            }

            return NotFound();
        }

        [HttpGet("GetPermission/{userName}/{password}")]
        public ActionResult GetPermission(string userName, string password)
        {
            var res = _userService.CheckPermission(userName, password);
            return Ok(res);
        }


    }
}
