using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers
{
	public class EFController : Controller
	{
		FabricsEntities DB = new FabricsEntities();
		// GET: EF
		public ActionResult Index()
		{
			var all = DB.Product.AsQueryable();

			var data = all.Where(p => p.Active == true && p.isDeleted==false).OrderByDescending(p => p.ProductId).Take(10);

			return View(data);
		}
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create(Product product)
		{
			if (ModelState.IsValid)
			{
				DB.Product.Add(product);
				DB.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(product);
		}
		public ActionResult Details(int id)
		{
			var product = DB.Product.Where(x => x.ProductId == id).FirstOrDefault();
			return View(product);
		}
		public ActionResult Edit(int id)
		{
			var product = DB.Product.Where(x => x.ProductId == id).FirstOrDefault();
			return View(product);
		}
		[HttpPost]
		public ActionResult Edit(int id, Product product)
		{

			if (ModelState.IsValid)
			{
				var item = DB.Product.Find(id);
				item.Active = product.Active;
				item.Price = product.Price;
				item.ProductName = product.ProductName;
				item.Stock = product.Stock;

				DB.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(product);
		}
		
		public ActionResult Delete(int id)
		{
			var product = DB.Product.Where(x => x.ProductId == id).FirstOrDefault();
			return View(product);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteOK(int id)
		{
			var product = DB.Product.Find(id);
			//if (ModelState.IsValid)
			//{
			//DB.OrderLine.RemoveRange(product.OrderLine);
			//DB.Product.Remove(DB.Product.Find(id));
			product.isDeleted = true;
			try
			{
				DB.SaveChanges();
			}
			catch (DbEntityValidationException ex)
			{

				throw;
			}
			
			//}
			return RedirectToAction("Index");
		}
	}
}