using DateCheckerSeleniumDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DateCheckerSeleniumDemo.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CheckDate(DateModel model)
		{
			bool isValid = CheckingFunction.CheckDate(model.Year, model.Month, model.Day);
			ViewBag.IsValid = isValid;
			return View("Result");
		}
	}
}
