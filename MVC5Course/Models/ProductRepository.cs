using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
	public class ProductRepository :EFRepository<Product>, IProductRepository
	{
		public override IQueryable<Product> All()
		{
			return base.All().Where(p=>!p.isDeleted);
		}
		public IQueryable<Product> All(bool showAll)
		{
			if (showAll)
			{
				return base.All();
			}
			else
			{
				return this.All();
			}
		}
		public Product getID(int id) {
			return this.All().FirstOrDefault(x => x.ProductId == id);
		}
		public IQueryable<Product> getAlldata(bool active ,bool showAll) {
			IQueryable<Product> all = this.All();
			if (showAll)
			{
				all = base.All();
			}
			return all
				.Where(p => p.Active.HasValue && p.Active.Value == active)
				.OrderByDescending(x => x.ProductId).Take(20);
		}
		public void Update(Product product) {

			this.UnitOfWork.Context.Entry(product).State = EntityState.Modified;
		}
		public override void Delete(Product entity)
		{
			
			//base.Delete(entity);
			entity.isDeleted = true;

		}
	}

	internal interface IProductRepository: IRepository<Product>
	{
	}
}