using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        Task<List<Blog>> TGetBlogsWithCategories();
    }
}