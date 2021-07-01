using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresi boş bırakılamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş bırakılamaz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş bırakılamaz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen minumum 3 karakter girişi yapınız");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Maximum 50 karakter girilebilir.");
            RuleFor(x => x.Message).MaximumLength(250).WithMessage("Maximum 250 karakter girilebilir.");
        }
    }
}
