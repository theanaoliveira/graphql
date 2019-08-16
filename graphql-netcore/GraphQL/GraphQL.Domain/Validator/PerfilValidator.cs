using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Domain.Validator
{
    public class PerfilValidator : AbstractValidator<Perfil.Perfil>
    {
        public PerfilValidator()
        {
            RuleFor(r => r.Id).NotNull().GreaterThan(0);
            RuleFor(r => r.Name).NotNull().NotEmpty();
        }
    }
}
