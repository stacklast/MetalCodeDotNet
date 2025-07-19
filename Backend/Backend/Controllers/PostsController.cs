using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        IPostsService _titleServices;

        public PostsController(IPostsService titleServices)
        {
            _titleServices = titleServices;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> Get() => await _titleServices.Get();
    }
}
