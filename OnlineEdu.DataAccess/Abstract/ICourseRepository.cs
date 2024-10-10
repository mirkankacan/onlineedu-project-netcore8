using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<List<Course>> GetCoursesWithCategories();
        Task ShowOnHome(int id);

        Task HideOnHome(int id);
    }
}