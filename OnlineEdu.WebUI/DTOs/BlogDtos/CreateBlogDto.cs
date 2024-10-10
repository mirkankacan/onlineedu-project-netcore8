namespace OnlineEdu.WebUI.DTOs.BlogDtos
{
    public class CreateBlogDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int BlogCategoryId { get; set; }
    }
}