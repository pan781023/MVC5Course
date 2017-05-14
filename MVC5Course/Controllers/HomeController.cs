using MVC5Course.Models.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
			//this.View("About").ExecuteResult(this.ControllerContext);

            return View();
        }
		public ActionResult Unknown()
		{
			

			return View();
		}
		[localonly]
		[SharedViewBag]
		
		public ActionResult About()
        {
			throw new ArgumentException("Error Handled!!");
			//ViewBag.Message = "Your application description page.";

			return View();
        }
		public ActionResult PartialAbout()
		{
			ViewBag.Message = " this is partialAbout Your application description page.";
			if (Request.IsAjaxRequest())
			{
				//網頁按F12 > 執行 > $.get('/Home/PartialAbout', function(data){ alert(data)})
				//只會跳出裡面的內容
				return PartialView("About");
			}
			else
			{
				
				return View("About");
			}

			
		}
		public ActionResult SomeAction() {
			//return Content("<script>alert('建立成功');location.href='/';</script>");
			return PartialView("SuccessRedirect", "/");
		}

		public ActionResult getFile()
		{
			return File(Server.MapPath("~/Content/bkntw-20160804135226593-0804_04111_001_01p.jpg"),"image/jpg", "newname.jpg");
		}
		public ActionResult getJson()
		{
			db.Configuration.LazyLoadingEnabled = false;
			//var data = db.Product.Take(5).ToList();
			return Json(db.Product.Take(5), JsonRequestBehavior.AllowGet);
		}

		public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
		public ActionResult test()
		{
			return View();
		}
		public ActionResult VT()
		{
			ViewBag.isEnabled = true;
			return View();
		}
		public ActionResult RazorTest()
		{
			ViewData.Model = new int[] {1,2,3,4,5,6 };
			return View();
		}
    }
}