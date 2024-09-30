using FluentValidation;
using OnlineEdu.WebUI.DTOs.BlogCategoryDtos;

namespace OnlineEdu.WebUI.Validators
{
    public class BlogCategoryValidator : AbstractValidator<CreateBlogCategoryDto>
    {
        public BlogCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Blog kategori adı boş geçilemez!");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Blog kategori adı en fazla 30 karakter olmalıdır!");
        }
    }
}