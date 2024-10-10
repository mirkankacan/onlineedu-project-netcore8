using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogManager(IRepository<Blog> _repository, IBlogRepository blogRepository) : base(_repository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<Blog>> TGetBlogsWithCategories()
        {
            return await _blogRepository.GetBlogsWithCategories();
        }
    }
}