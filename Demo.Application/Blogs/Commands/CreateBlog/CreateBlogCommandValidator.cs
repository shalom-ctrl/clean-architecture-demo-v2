using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author is required.")
                .MaximumLength(100).WithMessage("Author cannot exceed 100 characters.");
        }
    }
}
