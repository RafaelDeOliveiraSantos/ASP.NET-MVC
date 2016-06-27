using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoBenner.Core.Attributes
{
    public class MaxWordsAttribute : ValidationAttribute
    {
        private int _maxWords;

        public MaxWordsAttribute(int maxWords) : base("{0} tem muitas palavras.")
        {
            _maxWords = maxWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var valueAsString = value?.ToString();
            if (valueAsString?.Split(' ').Length > _maxWords)
            {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
