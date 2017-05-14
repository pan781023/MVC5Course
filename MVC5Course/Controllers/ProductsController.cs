using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using MVC5Course.Models.ViewModels;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers
{
	public class ProductsController : BaseController
	{
		ProductRepository repo = RepositoryHelper.GetProductRepository();
		//ProductRepository repo2 = new ProductRepository();

		//private FabricsEntities db = new FabricsEntities();
		//[OutputCache(Duration =300, Location =System.Web.UI.OutputCacheLocation.Any)]
		// GET: Products
		public ActionResult Index(bool Active = true)
		{
			//var data = db.Product.OrderByDescending(x => x.ProductId).Take(20);
			//if (Active != null)
			//{
			//	data = data.Where(x => x.Active.HasValue && x.Active.Value == Active);
			//}
			//repo2.UnitOfWork = new EFUnitOfWork();
			var data = repo.getAlldata(Active, showAll: false);

			ViewData["ppp"] = data;



			return View(data);
		}

		// GET: Products/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			//Product product = db.Product.Find(id);
			Product product = repo.getID(id.Value);
			if (product == null)
			{
				return HttpNotFound();
			}
			return View(product);
		}
		[HandleError(ExceptionType =typeof(DbUpdateException),View = "Error_DbUpdateException")]
		
		// GET: Products/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Products/Create
		// 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
		// 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
		[HandleError(ExceptionType = typeof(DbEntityValidationException), View = "Error_DbEntityValidationException")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
		{
			//if (ModelState.IsValid) //驗證
			//{
				repo.Add(product);
				repo.UnitOfWork.Commit();
				//db.Product.Add(product);
				//db.SaveChanges();
				return RedirectToAction("Index");
			//}

			return View(product);
		}

		// GET: Products/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Product product = repo.getID(id.Value);
			//Product product = db.Product.Find(id);
			if (product == null)
			{
				return HttpNotFound();
			}
			return View(product);
		}

		// POST: Products/Edit/5
		// 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
		// 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit( int id,FormCollection form)
		{
			//[Bind(Include = "ProductId,ProductName,Price,Active,Stock")]
			//Product product


			//維持原本的值
			var product = repo.getID(id);
			if (TryUpdateModel<Product>(product,new string[] {"ProductId","ProductName","Price","Active","Stock" }))
			{

			//}
			//if (ModelState.IsValid)
			//{s
				//repo.Update(product);
				repo.UnitOfWork.Commit();
				//db.Entry(product).State = EntityState.Modified;
				//db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(product);
		}

		// GET: Products/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Product product = repo.getID(id.Value);
			//Product product = db.Product.Find(id);
			if (product == null)
			{
				return HttpNotFound();
			}
			return View(product);
		}

		// POST: Products/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Product product = repo.getID(id);
			repo.UnitOfWork.Context.Configuration.ValidateOnSaveEnabled = false;
			repo.Delete(product);
			repo.UnitOfWork.Commit();
			//Product product = db.Product.Find(id);
			//db.Product.Remove(product);
			//db.SaveChanges();
			return RedirectToAction("Index");
		}

		//protected override void Dispose(bool disposing)
		//{
		//	if (disposing)
		//	{
		//		db.Dispose();
		//	}
		//	base.Dispose(disposing);
		//}
		public ActionResult ProductsList(ProductListSearchVM cond)
		{
			//var Data = db.Product
			//	.Where(x => x.Active == true)
			//	.Select(x => new ProductListVM
			//	{
			//		Price = x.Price,
			//		ProductName = x.ProductName,
			//		Stock = x.Stock,
			//		Active = x.Active
			//	});
			// 表單送出只要有model binging 就會有modelstate
			var Data = repo.getAlldata(true, showAll: true);
			if (ModelState.IsValid)
			{

				if (!string.IsNullOrEmpty(cond.q))
				{
					Data = Data.Where(x => x.ProductName.Contains(cond.q));
				}
			
				Data = Data.Where(x => x.Stock > cond.minnum && x.Stock < cond.maxnum);
			}
			ViewData.Model = Data.Select(p => new ProductListVM()
			{
				Price = p.Price,
				ProductName = p.ProductName,
				Stock = p.Stock,
				Active = p.Active

			}).Take(10);
			return View();
		}
		public ActionResult CreateProduct()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CreateProduct(ProductListVM data)
		{
			if (ModelState.IsValid)
			{
				TempData["CreateProduct_result"] = "商品新增成功";
				return RedirectToAction("Action");
			}
			return View();
		}


	}
}
