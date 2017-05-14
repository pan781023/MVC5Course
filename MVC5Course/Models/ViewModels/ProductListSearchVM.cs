using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModels
{
	public class ProductListSearchVM : IValidatableObject
	{
		public ProductListSearchVM()
		{

			this.maxnum = 999;
			this.minnum = 0;

		}

		public string q { get; set; }
		public int minnum { get; set; }
		public int maxnum { get; set; }


		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (minnum > maxnum)
			{
				yield return new ValidationResult("最大值不得小於最小值", new string[] { "minnum", "maxnum" });
			}

			
			//throw new NotImplementedException();
		}
	}
}