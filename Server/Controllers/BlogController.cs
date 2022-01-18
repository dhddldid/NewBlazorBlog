using Microsoft.AspNetCore.Mvc;
using NewBlazorBlog.Shared;

namespace NewBlazorBlog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public List<BlogPost> Posts { get; set; } = new()
        {
            new BlogPost { Url = "new-tutorial", Title = "A New Tutorial about Blazor", Description = "This is a new tutorial, showing you how to build a blog with Blazor", Content = "부트스트랩은 웹사이트를 쉽게 만들 수 있게 도와주는 HTML, CSS, JS 프레임워크이다. 하나의 CSS로 휴대폰, 태블릿, 데스크탑까지 다양한 기기에서 작동한다. 다양한 기능을 제공하여 사용자가 쉽게 웹사이트를 제작, 유지, 보수할 수 있도록 도와준다" },
            new BlogPost { Url = "first-post", Title = "My First Blog Post", Description = "Hi! This is my new shiny blog. Enjoy!", Content = "Quickly design and customize responsive mobile-first sites with Bootstrap, the world’s most popular front-end open source toolkit, featuring Sass variables and mixins, responsive grid system, extensive prebuilt components, and powerful JavaScript plugins." }
        };

        [HttpGet]
        public ActionResult<List<BlogPost>> GimmeAllTheBlogPosts()
        {
            return Ok(Posts);
        }

        [HttpGet("{url}")]
        public ActionResult<BlogPost> GimmeThatSingleBlogPost(string url)
        {
            var post = Posts.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));
            if(post is null)
            {
                return NotFound("This post does not exist.");
            }

            return Ok(post);
        }
    }
}
