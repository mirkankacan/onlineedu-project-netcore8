using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Concrete
{
    public class CourseCategoryRepository : GenericRepository<CourseCategory>, ICourseCategoryRepository
    {
        public CourseCategoryRepository(OnlineEduContext _context) : base(_context)
        {
        }

        public async Task HideOnHome(int id)
        {
            var value = await _context.CourseCategories.FindAsync(id);
            value.IsShown = false;
            await _context.SaveChangesAsync();
        }

        public async Task ShowOnHome(int id)
        {
            var value = await _context.CourseCategories.FindAsync(id);
            value.IsShown = true;
            await _context.SaveChangesAsync();
        }
    }
}