using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Concrete
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(OnlineEduContext _context) : base(_context)
        {
        }

        public async Task<List<Blog>> GetBlogsWithCategories()
        {
            return await _context.Blogs.Include(x => x.BlogCategory).ToListAsync();
        }
    }
}