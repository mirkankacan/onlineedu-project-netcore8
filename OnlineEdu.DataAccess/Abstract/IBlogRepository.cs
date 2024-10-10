using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Task<List<Blog>> GetBlogsWithCategories();
    }
}