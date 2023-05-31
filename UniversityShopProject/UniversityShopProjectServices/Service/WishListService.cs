using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;

namespace UniversityShopProjectServices.Service
{
    public class WishListService : GenericService<WishList>, IWishListService
    {
        public WishListService(UniversityShopProjectContext context) : base(context)
        {
        }
    }
}
