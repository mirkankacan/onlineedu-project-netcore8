namespace OnlineEdu.DTO.DTOs.CourseCategoryDtos
{
    public class CreateCourseCategoryDto
    {
        public int CourseCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public bool IsShown { get; set; }
    }
}