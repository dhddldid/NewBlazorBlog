using NewBlazorBlog.Shared;

namespace NewBlazorBlog.Client.Services
{
    public interface IBlogService
    {
        Task<List<BlogPost>> GetblogPosts();
        Task<BlogPost> GetBlogPostByUrl(string url);
        Task<BlogPost> CreateNewBlogPost(BlogPost post);
    }
}
