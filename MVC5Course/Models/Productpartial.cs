using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
	[MetadataType(typeof(Productdata))]
	public partial class Product {

	}
	public partial class Productdata
	{
		[Required(ErrorMessage = "請輸入商品名稱")]
		[MinLength(3), MaxLength(30, ErrorMessage = "最大長度30字")]
		public string ProductName { get; set; }
		[Required]
		[Range(0, 9999, ErrorMessage = "請設定正確商品價格")]
		[DisplayFormat(DataFormatString ="{0:0}",ApplyFormatInEditMode =false)]
		public Nullable<decimal> Price { get; set; }

		[Required]
		public Nullable<bool> Active { get; set; }
		[Required]
		public Nullable<decimal> Stock { get; set; }

	}
}