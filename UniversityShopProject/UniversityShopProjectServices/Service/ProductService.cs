using Azure;
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
        CategoryService _categoryService;
        public ProductService(UniversityShopProjectContext context) : base(context)
        {
            _categoryService = new CategoryService(context);
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
            Category category = _categoryService.GetEntity(id);
            if(category.ParentId != null)
            {
                var skip = size * (page - 1);
                var list = GetAll().FindAll(t => t.CategoryId == id);
                list.Reverse();
                return list.Skip(skip).Take(size).ToList();
            }
            else
            {
                List<Category> categories = new List<Category>();
                categories = _categoryService.GetAll().FindAll(t=>t.ParentId == id);
                List<Product> products = new List<Product>();
                foreach (var item in categories)
                {
                    var temp = GetAll().FindAll(t => t.CategoryId == item.CategoryId);
                    products.AddRange(temp);
                }
                var skip = size * (page - 1);
                products.Reverse();
                return products.Skip(skip).Take(size).ToList();
            }
        }

        public int GetTotalPageCount(int size,int id)
        {
            Category category = _categoryService.GetEntity(id);
            if (category.ParentId != null)
            {
                var count = GetAll().FindAll(t => t.CategoryId == id).Count();

                return count > 0 ? (int)Math.Ceiling((decimal)count / size) : 1;
            }
            else
            {
                List<Category> categories = new List<Category>();
                categories = _categoryService.GetAll().FindAll(t => t.ParentId == id);
                List<Product> products = new List<Product>();
                foreach (var item in categories)
                {
                    var temp = GetAll().FindAll(t => t.CategoryId == item.CategoryId);
                    products.AddRange(temp);
                }
                var count = products.Count();

                return count > 0 ? (int)Math.Ceiling((decimal)count / size) : 1;
            }
        }
    }
}
