using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public class ValidationTool
    {
        //static dışarıdan bu metota ulaşmamızı sağlıyor.
        public static void Valide(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }

    }
}
