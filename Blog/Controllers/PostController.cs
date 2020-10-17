using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Models.ApiResponse;
using Blog.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository dataRepository)
        {
            _postRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get(int limit = 10, int offset = 0)
        {
            IEnumerable<Post> posts = _postRepository.GetAll(limit, offset);

            PaginationApiResponse<IEnumerable<Post>> response = new PaginationApiResponse<IEnumerable<Post>>();
            response.Data = posts;
            response.Meta = new Meta { Limit = limit, Offset = offset, Total = _postRepository.GetAllCount() };
            return Ok(response);
        }

        [HttpGet("filter")]
        public IActionResult Search(string searchText, int limit = 10, int offset = 0)
        {
            IEnumerable<Post> posts;
            if (String.IsNullOrEmpty(searchText))
            {
                posts = _postRepository.GetAll(limit, offset);
            }
            else
            {
                posts = _postRepository.Search(searchText, limit, offset);
            }

            PaginationApiResponse<IEnumerable<Post>> response = new PaginationApiResponse<IEnumerable<Post>>();
            response.Data = posts;
            response.Meta = new Meta { Limit = limit, Offset = offset, Total = _postRepository.GetAllCount() };
            return Ok(response);
        }

        // GET: api/Post/5
        //[HttpGet("{id}", Name = "Get")]
        //public IActionResult Get(long id)
        //{
        //    Post post = _postRepository.Get(id);
        //    if (post == null)
        //    {
        //        return NotFound("Post not found.");
        //    }
        //    return Ok(post);
        //}
    }
}
