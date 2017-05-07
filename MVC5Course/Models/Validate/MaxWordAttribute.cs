using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.Validate
{
	public class MaxWordAttribute: ValidationAttribute
	{
		
		public MaxWordAttribute(int MaxWords):base("{0} has too many words")
		{
			_maxWords = MaxWords;
		}
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value !=null)
			{
				var str = value.ToString();
				if (str.Length > _maxWords)
				{
					var errormessage = FormatErrorMessage(validationContext.DisplayName);
					return new ValidationResult(errormessage);
				}

			}
			return ValidationResult.Success;
		}
		private readonly int _maxWords;
	}
}