using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez!");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Kategori açıklaması boş geçilemez!");

            RuleFor(x => x.Description).MinimumLength(20).WithMessage("Kategori açıklaması en az 20 karakter olmalıdır!");
        }
    }
}
