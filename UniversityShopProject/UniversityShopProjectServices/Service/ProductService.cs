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
        public List<Product>? GetMostView()
        {
            var products = GetAll().OrderBy(t=>t.Views).TakeLast(10).ToList();
            if(products!=null)
            {
                return products;
            }
            else
            {
                return null;
            }
        }

        public List<Product> GetAllWithPage(int id,int size,int page =1)
        {
            var skip = size * (page - 1);
            var list = GetAll().FindAll(t => t.CategoryId == id);
            list.Reverse();
            return list.Skip(skip).Take(size).ToList();
        }

        public int GetTotalPageCount(int size,int id)
        {
            var count = GetAll().FindAll(t => t.CategoryId == id).Count();

            return count > 0 ? (int)Math.Ceiling((decimal)count / size) : 1;
        }
    }
}
