using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Concrete
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(OnlineEduContext _context) : base(_context)
        {
        }

        public async Task<List<Course>> GetCoursesWithCategories()
        {
            return await _context.Courses.Include(x => x.CourseCategory).ToListAsync();
        }
        public async Task HideOnHome(int id)
        {
            var value = await _context.Courses.FindAsync(id);
            value.IsShown = false;
            await _context.SaveChangesAsync();
        }

        public async Task ShowOnHome(int id)
        {
            var value = await _context.Courses.FindAsync(id);
            value.IsShown = true;
            await _context.SaveChangesAsync();
        }
    }
}