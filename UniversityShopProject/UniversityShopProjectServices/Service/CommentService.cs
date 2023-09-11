using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;

namespace UniversityShopProjectServices.Service
{
    public class CommentService : GenericService<Comment>, ICommentService
    {
        public CommentService(UniversityShopProjectContext context) : base(context)
        {
        }

        public List<Comment> GetAllWithPage(int size, int page = 1)
        {
            var skip = size * (page - 1);
            return GetAll().Skip(skip).Take(size).ToList();
        }

        public int GetTotalPageCount(int size)
        {
            var count = GetAll().Count();

            return count > 0 ? (int)Math.Ceiling((decimal)count / size) : 1;
        }
    }
}
