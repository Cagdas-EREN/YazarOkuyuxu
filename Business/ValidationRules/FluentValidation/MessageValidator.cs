using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresi boş bırakılamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş bırakılamaz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj alanı boş bırakılamaz");
            RuleFor(x=>x.Subject).MaximumLength(100).WithMessage("Maximum 100 karakter girilebilir.");
            RuleFor(x=>x.Subject).MinimumLength(3).WithMessage("Minimum 3 karakter girilebilir.");
        }
    }
}
