using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class CourseManager : GenericManager<Course>, ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseManager(IRepository<Course> _repository, ICourseRepository courseRepository) : base(_repository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<Course>> TGetCoursesWithCategories()
        {
            return await _courseRepository.GetCoursesWithCategories();
        }
        public async Task THideOnHome(int id)
        {
            await _courseRepository.HideOnHome(id);
        }

        public async Task TShowOnHome(int id)
        {
            await _courseRepository.ShowOnHome(id);
        }
    }
}