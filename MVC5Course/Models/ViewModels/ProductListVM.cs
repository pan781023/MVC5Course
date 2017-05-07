using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModels
{
	/// <summary>
	/// 這是一個簡易版的
	/// </summary>
	public class ProductListVM
	{
		
		[Required]
		public string ProductName { get; set; }
		
		public Nullable<decimal> Price { get; set; }
		
		public Nullable<bool> Active { get; set; }

		public Nullable<decimal> Stock { get; set; }
	}
}