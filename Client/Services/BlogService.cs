using NewBlazorBlog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace NewBlazorBlog.Client.Services
{
    public class BlogService : IBlogService
    {
        private readonly HttpClient http;

        public BlogService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<BlogPost> GetBlogPostByUrl(string url)
        {
            var post = await http.GetFromJsonAsync<BlogPost>($"api/Blog/{url}");
            return post;
        }

        public async Task<List<BlogPost>> GetblogPosts()
        {
            return await http.GetFromJsonAsync<List<BlogPost>>("api/Blog");
        }
    }
}
