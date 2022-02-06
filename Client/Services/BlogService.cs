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

        public async Task<BlogPost> CreateNewBlogPost(BlogPost post)
        {
            var result = await http.PostAsJsonAsync("api/Blog", post);
            return await result.Content.ReadFromJsonAsync<BlogPost>();
        }

        public async Task<BlogPost> GetBlogPostByUrl(string url)
        {
            //var post = await http.GetFromJsonAsync<BlogPost>($"api/Blog/{url}");
            //return post;

            var result = await http.GetAsync($"api/Blog/{url}");
            if(result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                return new BlogPost { Title = message };
            }
            else
            {
                return await result.Content.ReadFromJsonAsync<BlogPost>();
            }
        }

        public async Task<List<BlogPost>> GetblogPosts()
        {
            return await http.GetFromJsonAsync<List<BlogPost>>("api/Blog");
        }
    }
}
