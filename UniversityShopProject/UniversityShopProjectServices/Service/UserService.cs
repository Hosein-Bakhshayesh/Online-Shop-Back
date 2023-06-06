using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;

namespace UniversityShopProjectServices.Service
{
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(UniversityShopProjectContext context) : base(context)
        {

        }

        public bool CheckMobileNumber(string mobileNumber)
        {
            var users = GetAll();
            var userNames = users.Select(u => u.MobileNumber);
            if (userNames.Any(u => u == mobileNumber))
            {
                return false;
            }
            else
                return true;
        }

        public bool CheckUserName(string userName)
        {
            var users = GetAll();
            var userNames = users.Select(u => u.UserName);
            if(userNames.Any(u=> u == userName))
            {
                return false;
            }
            else
                return true;
        }
    }
}
