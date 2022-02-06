using Microsoft.Azure.Cosmos;
using NewBlazorBlog.Server.Services.Foundation;
using NewBlazorBlog.Shared;

namespace NewBlazorBlog.Server.Pratice.BlazorBlogPost.Services
{
    public class BlogPostService
    {
        private readonly CosmosDbService cosmosDbService;
        private readonly Container container;

        public BlogPostService(CosmosDbService cosmosDbService)
        {
            this.cosmosDbService = cosmosDbService;
            container = cosmosDbService.GetContainer();
        }

        public async Task CreateNewBlogPost(BlogPost post)
        {
            post.Id = Guid.NewGuid().ToString();
            await container.AddModel<BlogPost>(post);
        }
    }
}
