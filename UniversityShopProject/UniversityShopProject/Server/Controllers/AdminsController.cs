using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityShopProject.Shared.ViewModels.Admin;
using UniversityShopProject.Shared.ViewModels.Auth;
using UniversityShopProject.Shared.ViewModels.User;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;
using UniversityShopProjectServices.Service;

namespace UniversityShopProject.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        public IMapper _mapper { get; set; }
        UniversityShopProjectContext db = new();
        AdminService _AdminService;
        public AdminsController(IMapper mapper)
        {
            _AdminService = new AdminService(db);
            _mapper = mapper;

        }
        [HttpGet("List")]
        public ActionResult AdminsList()
        {
            List<Admin> admins = _AdminService.GetAll();
            List<AdminListViewModel> adminVM = _mapper.Map<List<Admin>, List<AdminListViewModel>>(admins);


            if (adminVM != null)
            {
                return Ok(adminVM);
            }
            else
            {
                return NotFound("Admin Not Exist");
            }
        }
        [HttpGet("Info/{adminid}")]
        public ActionResult UserInfo(int adminid)
        {
            Admin admin = new Admin();
            admin = _AdminService.GetEntity(adminid);
            AdminInfoViewModel adminInfo = _mapper.Map<Admin, AdminInfoViewModel>(admin);
            if (admin != null)
            {
                return Ok(adminInfo);
            }
            else
            {
                return NotFound("User Not Found");
            }
        }
        [HttpPut("Edit")]
        public ActionResult EditUser(AdminInfoViewModel adminInfo)
        {
            Admin user = _mapper.Map<AdminInfoViewModel, Admin>(adminInfo);
            try
            {
                if (user == null)
                {
                    return NotFound("User Not Found !");
                }
                _AdminService.Update(user);
                _AdminService.Save();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "بروزرسانی انجام نشد");
            }
        }
        [HttpPut("Delete")]
        public ActionResult DeleteUser(AdminInfoViewModel adminInfo)
        {
            Admin user = _mapper.Map<AdminInfoViewModel, Admin>(adminInfo);
            try
            {
                if (user == null)
                {
                    return NotFound("User Not Found !");
                }
                _AdminService.Delete(user);
                _AdminService.Save();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "عملیات حذف انجام نشد");
            }
        }
        [HttpPost("Create")]
        public ActionResult CreateUser(AdminCreateViewModel adminCreate)
        {
            Admin admin = _mapper.Map<AdminCreateViewModel, Admin>(adminCreate);
            try
            {
                if (admin == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "با مشکل مواجه شد");
                }
                else
                {
                    if (_AdminService.CheckUserName(admin.UserName) == true)
                    {
                        return NotFound("کاربری با این نام کاربری قبلا ثبت شده است");
                    }
                    if (_AdminService.CheckMobileNumber(admin.MobileNumber) == false)
                    {
                        return NotFound("کاربری با این شماره موبایل قبلا ثبت شده است");
                    }
                    _AdminService.Add(admin);
                    _AdminService.Save();
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
            if (_AdminService.CheckUserName(UserName) == true)
            {
                return Ok(false);
            }
            if (_AdminService.CheckMobileNumber(mobile) == false)
            {
                return Ok(false);
            }
            else
            {
                return Ok(true);
            }

        }

        [HttpPost("LoginAdmin")]
        public ActionResult Login(LoginRequest userRequest)
        {
            Admin? admin = _AdminService.GetAll().Where(t => t.UserName == userRequest.UserName && t.Password == userRequest.Password).FirstOrDefault();
            if (admin != null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, admin.UserName),
                    new Claim(ClaimTypes.Role, "Admin"),
                };
                var claimIdentity = new ClaimsIdentity(claims, "ServerAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimIdentity);
                AuthenticationHttpContextExtensions.SignInAsync(HttpContext, claimsPrincipal);
            }
            return Ok(admin);
        }

        [HttpGet("IsAdmin")]
        public ActionResult IsAdmin()
        {
            AdminInfoViewModel adminInfoViewModel = new AdminInfoViewModel();
            if (User.Identity != null)
            {
                if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
                {
                    Admin admin = new Admin();
                    admin.UserName = User.FindFirstValue(ClaimTypes.Name);
                    admin = _AdminService.GetAll().Find(t => t.UserName == admin.UserName);
                    adminInfoViewModel = _mapper.Map<Admin, AdminInfoViewModel>(admin);
                }
            }
            return Ok(adminInfoViewModel);
        }

        [HttpGet("LogOutAdmin")]
        public ActionResult LogOutUser()
        {
            AuthenticationHttpContextExtensions.SignOutAsync(HttpContext);
            return Ok(true);
        }

        [HttpGet("GetPermission/{userName}/{password}")]
        public ActionResult GetPermission(string userName, string password)
        {
            var res = _AdminService.CheckPermission(userName, password);
            return Ok(res);
        }
    }
}
