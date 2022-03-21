using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Components.Common
{
    public static class Validator
    {
        public static Func<object, string, Task<IEnumerable<string>>> ValidateModel<TModel, TValidator>() where TValidator : AbstractValidator<TModel>
        {
            async Task<IEnumerable<string>> ValidateFunction(object model, string propertyName)
            {
                var validator = (TValidator)Activator.CreateInstance(typeof(TValidator));
                var result = await validator.ValidateAsync(ValidationContext<TModel>.CreateWithOptions((TModel)model, x => x.IncludeProperties(propertyName)));
                if (result.IsValid)
                    return Array.Empty<string>();
                return result.Errors.Select(e => e.ErrorMessage);
            }

            return ValidateFunction;
        }
    }
}
