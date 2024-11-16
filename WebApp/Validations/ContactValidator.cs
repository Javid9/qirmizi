using Domain.Dtos.Contact;
using FluentValidation;

namespace WebApp.Validations;

public class ContactValidator : AbstractValidator<CreateContact>
{
    public ContactValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Boş ola bilməz").EmailAddress().WithMessage("Bos ola bilmez");
        RuleFor(x => x.Phone).NotEmpty().WithMessage("Boş ola bilməz");
        RuleFor(x => x.FullName).NotEmpty().WithMessage("Boş ola bilməz");
        RuleFor(x => x.Message).NotEmpty().WithMessage("Boş ola bilməz");
        RuleFor(x => x.Subject).NotEmpty().WithMessage("Boş ola bilməz");
    }
}