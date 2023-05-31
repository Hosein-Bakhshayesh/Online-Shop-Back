using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;
using UniversityShopProjectRepository.GenericRepository;

namespace UniversityShopProjectRepository.Repository
{
    public class WishListRepository : GenericRepository<WishList>, IWishListRepository
    {
        public WishListRepository(UniversityShopProjectContext context) : base(context)
        {
        }
    }
}
