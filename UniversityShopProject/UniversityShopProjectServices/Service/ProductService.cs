using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;

namespace UniversityShopProjectServices.Service
{
    public class ProductService : GenericService<Product>, IProductService
    {
        public ProductService(UniversityShopProjectContext context) : base(context)
        {
        }
    }
}
