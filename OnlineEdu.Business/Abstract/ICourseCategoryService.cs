using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface ICourseCategoryService : IGenericService<CourseCategory>
    {
        Task TShowOnHome(int id);

        Task THideOnHome(int id);
    }
}