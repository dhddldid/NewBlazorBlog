using NewBlazorBlog.Shared.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace NewBlazorBlog.Shared
{
    public class BlogPost : CosmosModelBase
    {
        //public int Id { get; set; }
        [Required, StringLength(20)]
        public string? Url { get; set; } = String.Empty;
        [Required]
        public string? Title { get; set; } = String.Empty;
        public string? Content { get; set; } = String.Empty;
        public string? Description { get; set; } = String.Empty;
        public string? Author { get; set; } = String.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool IsPublished { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public override string ClassType => "BlogPost";
    }
}
