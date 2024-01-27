using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;

        public CommentsController(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public IActionResult CommentList() {
            var values = _commentRepository.GetAll();
            return Ok(values);
        }
        [HttpGet("CommentListByBlog")]
        public IActionResult CommentListByBlog(int id)
        {
            var values = _commentRepository.GetCommentsByBlogId(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment) {
            _commentRepository.Create(comment);
            return Ok("Creation Succeed");    
        }
        [HttpDelete]
        public IActionResult RemoveComment(int id) {
            _commentRepository.Remove(id);
            return Ok("Comment Deleted");
        }

        [HttpPut]
        public IActionResult UpdateComment(Comment comment) {
            _commentRepository.Update(comment);
            return Ok("Comment Updated");
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id) {
            var value = _commentRepository.GetById(id);
            return Ok(value);
        }
    }
}
