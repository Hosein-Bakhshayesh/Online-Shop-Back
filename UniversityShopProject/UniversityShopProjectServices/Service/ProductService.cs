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

        public List<Product>? GetLastProduct()
        {
            var products = GetAll().TakeLast(10).ToList();
            if(products!=null)
            {
                return products;
            }
            else
            {
                return null;
            }
        }
    }
}
