using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;
using UniversityShopProjectServices.Service;

namespace UniversityShopProject.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UniversityShopProjectContext db = new UniversityShopProjectContext();
        UserService _userService;
        public UserController()
        {
            _userService = new UserService(db);
        }
        [Route("List")]
        public  ActionResult UserList()
        {
            List<User> users = _userService.GetAll().ToList();
            if(users != null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound("User Not Exist");
            }
        }
    }
}
