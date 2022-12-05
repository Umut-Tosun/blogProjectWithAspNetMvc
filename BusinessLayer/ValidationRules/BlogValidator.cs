using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Blog başlığı en az 5 karakter olmalıdır!");
            RuleFor(x => x.Content).MinimumLength(200).WithMessage("Blog içerigi en az 200 karakter olmalıdır.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Blog görsel boş olamaz!");
            
        }
    }
}
