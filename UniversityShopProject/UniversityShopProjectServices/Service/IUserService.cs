using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityShopProjectModels.Models;

namespace UniversityShopProjectServices.Service
{
    public interface IUserService:IGenericService<User>
    {
        public bool CheckUserName(string userName);
        public bool CheckMobileNumber(string mobileNumber);
    }
}
