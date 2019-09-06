using System.ComponentModel.DataAnnotations;

namespace GraphQL.Application.UseCases.Expressions
{
    public class WhereExpression
    {
        [Required]
        public string Field { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
