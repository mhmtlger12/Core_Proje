using EntityLayer.Concrete;
using FluentValidation;
using System;


namespace BusinessLayer.ValidationRules
{
    public class ExperienceValidator : AbstractValidator<Experience>
    {
        public ExperienceValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Deneyim başlığı zorunludur.")
                .MaximumLength(100).WithMessage("Deneyim başlığı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Tarih bilgisi zorunludur.")
                .Must(date => date != default(DateTime)).WithMessage("Geçerli bir tarih giriniz.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Resim yolu zorunludur.")
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute)).WithMessage("Geçerli bir URL giriniz.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama zorunludur.")
                .MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olabilir.");
        }
    }
}
