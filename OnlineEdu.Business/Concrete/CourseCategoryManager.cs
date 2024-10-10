using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class CourseCategoryManager : GenericManager<CourseCategory>, ICourseCategoryService
    {
        private readonly ICourseCategoryRepository _courseCategoryRepository;

        public CourseCategoryManager(IRepository<CourseCategory> _repository, ICourseCategoryRepository courseCategoryRepository) : base(_repository)
        {
            _courseCategoryRepository = courseCategoryRepository;
        }

        public async Task THideOnHome(int id)
        {
            await _courseCategoryRepository.HideOnHome(id);
        }

        public async Task TShowOnHome(int id)
        {
            await _courseCategoryRepository.ShowOnHome(id);
        }
    }
}