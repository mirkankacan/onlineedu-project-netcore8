using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ICourseCategoryRepository : IRepository<CourseCategory>
    {
        Task ShowOnHome(int id);

        Task HideOnHome(int id);
    }
}