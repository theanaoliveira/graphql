using FluentValidation;
using FluentValidation.Results;
using System;

namespace GraphQL.Domain
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }

        public bool IsValid { get; private set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return IsValid = ValidationResult.IsValid;
        }
    }
}
