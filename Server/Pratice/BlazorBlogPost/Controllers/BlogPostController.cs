using Microsoft.AspNetCore.Mvc;
using NewBlazorBlog.Server.Pratice.BlazorBlogPost.Services;
using NewBlazorBlog.Shared;

namespace NewBlazorBlog.Server.Pratice.BlazorBlogPost.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly BlogPostService blogPostService;

        public BlogPostController(BlogPostService blogPostService)
        {
            this.blogPostService = blogPostService;
        }


        [HttpPost]
        public async Task<ActionResult<BlogPost>> CreateNewBlogPost(BlogPost post)
        {
            await blogPostService.CreateNewBlogPost(post);

            return Ok(post);
        }
    }
}
