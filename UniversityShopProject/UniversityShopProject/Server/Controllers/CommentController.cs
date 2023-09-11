using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityShopProject.Shared.ViewModels.Comment;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;
using UniversityShopProjectServices.Service;

namespace UniversityShopProject.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        CommentService _commentService;
        public IMapper _mapper;
        UniversityShopProjectContext db = new();

        public CommentController(IMapper mapper)
        {
            _mapper = mapper;
            _commentService = new CommentService(db);
        }

        [HttpGet("GetAllComments/{page}")]
        public ActionResult GetAllComments(int page)
        {
            List<Comment> commentList = _commentService.GetAllWithPage(10,page);
            if (commentList != null)
            {
                List<CommentViewModel> model = _mapper.Map<List<Comment>, List<CommentViewModel>>(commentList);
                return Ok(model);
            }
            else
            {
                return NotFound("یافت نشد.");
            }
        }

        [HttpGet("TotalPageCount/{size}")]
        public ActionResult TotalPageCount(int size)
        {
            int count = _commentService.GetTotalPageCount(size);
            return Ok(count);
        }

        [HttpGet("Get/{Id}")]
        public ActionResult GetComment(int Id)
        {
            List<Comment> commentList = _commentService.GetAll().FindAll(t => t.ProductId == Id && t.IsActive == true);
            if (commentList != null)
            {
                List<CommentViewModel> model = _mapper.Map<List<Comment>, List<CommentViewModel>>(commentList);
                return Ok(model);
            }
            else
            {
                return NotFound("یافت نشد.");
            }
        }
        [HttpPost("AddComment")]
        public ActionResult AddComment(CommentViewModel model)
        {
            try
            {
                Comment comment = new Comment();
                comment = _mapper.Map<CommentViewModel, Comment>(model);
                _commentService.Add(comment);
                _commentService.Save();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "انجام نشد");
            }
        }

        [HttpPost("DeleteComment")]
        
        public ActionResult DeleteComment([FromBody]int Id)
        {
            try
            {
                _commentService.Delete(Id);
                _commentService.Save();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "انجام نشد");
            }
        }
        [HttpPost("ChangeActive")]
        
        public ActionResult ChangeActive([FromBody]int Id)
        {
            try
            {
                Comment comment = _commentService.GetEntity(Id);
                if(comment!=null)
                {
                    comment.IsActive = !comment.IsActive;
                    _commentService.Update(comment);
                    _commentService.Save();
                }

                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "انجام نشد");
            }
        }
    }
}
