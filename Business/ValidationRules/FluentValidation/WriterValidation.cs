using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class WriterValidation : AbstractValidator<Writer>
    {
        public WriterValidation()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş bırakılamaz");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadı boş bırakılamaz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında kısımı boş bırakılamaz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail kısımı boş bırakılamaz");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("En az 2 karakter giriniz");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("En fazla 50 karakter giriniz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Ünvan alanı boş bırakılamaz");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("En az 3 karakter olmalıdır");
        }
    }
}
