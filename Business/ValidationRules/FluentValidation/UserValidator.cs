using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<RegisterAuthDto>
    {
        public UserValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Kullanıcı adı boş olamaz!");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Mail adresi boş olamaz!");
            RuleFor(p => p.ImageUrl).NotEmpty().WithMessage("Kullanıcı Resmi boş olamaz!");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş olamaz!");
            RuleFor(p => p.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır!");
        }
    }
}
