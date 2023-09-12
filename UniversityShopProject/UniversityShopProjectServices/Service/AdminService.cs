using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;

namespace UniversityShopProjectServices.Service
{
    public class AdminService : GenericService<Admin>, IAdminService
    {
        public AdminService(UniversityShopProjectContext context) : base(context)
        {

        }
        public bool CheckMobileNumber(string mobileNumber)
        {
            var admins = GetAll();
            var userNames = admins.Select(u => u.MobileNumber);
            if (userNames.Any(u => u == mobileNumber))
            {
                return false;
            }
            else
                return true;
        }

        public bool CheckUserName(string userName)
        {
            var admins = GetAll();
            if (!admins.Any(u => u.UserName.ToUpper() == userName.ToUpper()))
            {
                return false;
            }
            else
                return true;
        }

        public bool CheckPermission(string userName, string password)
        {
            return GetAll().Any(t => t.UserName == userName && t.Password == password);
        }
    }
}
