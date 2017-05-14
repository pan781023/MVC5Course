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

namespace MVC5Course.Controllers
{
	//abstract 抽象類別就不會被執行
	public abstract class BaseController : Controller
	{

		//只有 public & protected
	 public	FabricsEntities db = new FabricsEntities();
		public ActionResult Debug() {
			return Content("這是Debug");
		}
		public ActionResult Show() {
			return Content("即將轉向");
			
		}
		//protected override void HandleUnknownAction(string actionName)
		//{
		//	////////base.HandleUnknownAction(actionName);
		//	this.RedirectToAction("Index","Home").ExecuteResult(this.ControllerContext);
		//}
	}
}