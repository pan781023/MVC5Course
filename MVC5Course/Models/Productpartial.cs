using MVC5Course.Models.Validate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
	[MetadataType(typeof(Productdata))]

	
	public partial class Product:IValidatableObject {
		public int 數量 { get { return this.OrderLine.Count; } }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (Stock >5 && Price >100)
			{
				yield return new ValidationResult("庫存大於5&價格大於100", new[] { "Stock", "Price" });
			}

			if (Active !=true)
			{
				yield return new ValidationResult("Active!=true", new[] { "Stock", "Price" });
			}
			//throw new NotImplementedException();
		}
	}

	

	public partial class Productdata
	{
		[Required(ErrorMessage = "請輸入商品名稱")]
		//[MinLength(3), MaxLength(100, ErrorMessage = "最大長度30字")]
		[商品名稱包含Amber字串]
		[MaxWord(10)]
		[DisplayName("商品名稱")]
		public string ProductName { get; set; }
		[Required]
		[Range(0, 9999, ErrorMessage = "請設定正確商品價格")]
		[DisplayFormat(DataFormatString ="{0:0}",ApplyFormatInEditMode =false)]
		[DisplayName("價格")]
		public Nullable<decimal> Price { get; set; }

		[Required]
		[DisplayName("是否上架")]
		public Nullable<bool> Active { get; set; }
		[Required]
		[DisplayName("庫存")]
		
		public Nullable<decimal> Stock { get; set; }

	}
}