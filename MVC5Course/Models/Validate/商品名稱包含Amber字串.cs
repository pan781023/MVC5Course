using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.Validate
{
	public class 商品名稱包含Amber字串 : DataTypeAttribute
	{
		public 商品名稱包含Amber字串():base(DataType.Text)
		{
			ErrorMessage = "字串必須有Amber";
		}
		
		public override bool IsValid(object value)
		{
			var str = (string)value;
			return str.Contains("Amber");
		}

	}


}