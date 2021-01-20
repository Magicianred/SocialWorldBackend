using FluentValidation;
using SocialWorld.Business.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorld.Business.ValidationRules.FluentValidation
{
    class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(I => I.Email).NotEmpty().WithMessage("Email alanı boş geçilemez");
            RuleFor(I => I.Email).EmailAddress().WithMessage("Email düzgün yazınız");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez ");
        }
    }
}
