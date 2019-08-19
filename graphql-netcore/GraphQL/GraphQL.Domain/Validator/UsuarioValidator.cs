using FluentValidation;
using System;

namespace GraphQL.Domain.Validator
{
    public class UsuarioValidator : AbstractValidator<Usuario.Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(r => r.Id).NotNull().NotEqual(new Guid());
            RuleFor(r => r.Name).NotNull().NotEmpty();
            RuleFor(r => r.Email).NotNull().NotEmpty();
            RuleFor(r => r.Age).GreaterThan(0);
            RuleFor(r => r.Salario).GreaterThan(0);
            RuleFor(r => r.Perfil).Null()
                .When(w => w.Perfil != null)
                .SetValidator(new PerfilValidator());
        }
    }
}
