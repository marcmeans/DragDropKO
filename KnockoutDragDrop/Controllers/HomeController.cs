using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using KnockoutDragDrop.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KnockoutDragDrop.Controllers
{
	public class HomeController : Controller
	{

		public ActionResult Index()
		{
			var sett = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
			var model = DataService.LoadViewModel();
			ViewBag.Model = JsonConvert.SerializeObject(model, Formatting.Indented, sett);
			return View();
		}

		[HttpPost]
		public ActionResult AdjustPriority(string studentId, string newStudentId, int priority, int sourceId, int targetId)
		{
			try
			{
				DataService.UpdateStudentPriority(studentId, newStudentId, priority, sourceId, targetId);
			}
			catch (Exception ex)
			{
				return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
			}
			return new HttpStatusCodeResult(HttpStatusCode.NoContent);
		}

		[HttpPost]
		public ActionResult RemoveStudent(string studentId, int sourceId)
		{
			try
			{
				DataService.RemoveStudent(studentId, sourceId);
			}
			catch (Exception ex)
			{
				return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
			}
			return new HttpStatusCodeResult(HttpStatusCode.NoContent);
		}

		

	}
}
