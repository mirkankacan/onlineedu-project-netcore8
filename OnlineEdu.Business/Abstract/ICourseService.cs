using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface ICourseService : IGenericService<Course>
    {
        Task TShowOnHome(int id);

        Task THideOnHome(int id);
        Task<List<Course>> TGetCoursesWithCategories();
    }
}