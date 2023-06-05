using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;
using UniversityShopProjectServices.Service;
using AutoMapper;
using UniversityShopProject.Shared.ViewModels.User;

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
        public  ActionResult UserList()
        {
            List<User> users = _userService.GetAll();
            List<UserListViewModel> usersVM = _mapper.Map<List<User>, List< UserListViewModel >> (users);
            

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
            if(user != null)
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
                if(user == null)
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
        [HttpPut("Delete")]
        public ActionResult DeleteUser(UserInfoViewModel userInfo)
        {
            User user = _mapper.Map<UserInfoViewModel, User>(userInfo);
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
    }
}
