using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp6
{
    class UserValidate : AbstractValidator<User>
    {
        public UserValidate()
        {
            RuleFor(uzivatel => uzivatel.Surname).NotEmpty().WithMessage("1");
            RuleFor(uzivatel => uzivatel.Forename).NotEmpty().WithMessage("2");
            RuleFor(uzivatel => uzivatel.Email).EmailAddress().WithMessage("3");
            RuleFor(uzivatel => uzivatel.Address).Length(20, 250).WithMessage("4");
        }
    }
}
