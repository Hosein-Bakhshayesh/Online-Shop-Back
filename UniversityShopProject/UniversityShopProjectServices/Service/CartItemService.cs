using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;
using UniversityShopProjectRepository.Repository;

namespace UniversityShopProjectServices.Service
{
    public class CartItemService : GenericService<CartItem>, ICartItemService
    {
        public CartItemService(UniversityShopProjectContext context) : base(context)
        {
        }
    }
}
