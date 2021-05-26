using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using MVC_DynamicMenu.Models;
using MVC_DynamicMenu.Repo;
using MVC_DynamicMenu.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Controllers
{
	public class RosterController : Controller
	{
		private readonly RosterRepo _rostRepo = null;
		IFirebaseConfig config = new FirebaseConfig
		{
			
			AuthSecret = "PuA6dv5Gr7s2osLcJN3MJRDOo3ob7dYdgZVLva4I",
			BasePath = "https://kujana-mvc-default-rtdb.firebaseio.com/"
		};


		public RosterController(RosterRepo rosterRepo)
		{
			_rostRepo = rosterRepo;
		}
		[HttpGet]
		public IActionResult Roster()
		{
			var users = _rostRepo.getallusers();
			ViewBag.Users = users;
			return View();
		}

		[HttpPost]
		public IActionResult Roster(RosterView model)
		{
			var date = DateTime.Now.ToString();
			RosterViewModel roster = new RosterViewModel {
				StartDateTime = DateTime.Parse(model.StartDate + " " + model.StartTime),
				EndDateTime = DateTime.Parse(model.EndDate + " " + model.EndTime),
				Location = model.Location,
				StaffName = model.StaffName,
				status = "Pending"
			};
			TimeSpan tm = TimeSpan.FromMinutes(model.offset);	
			var taskid = _rostRepo.AddRosterTask(roster);
			roster.TaskID = taskid;
			
			try
			{
				tasktofirebase(roster);

			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			
			roster.status = "Started";
			BackgroundJob.Schedule(() => updatetasktofirebase(roster), roster.StartDateTime.Add(tm));
			roster.status = "Ended";
			BackgroundJob.Schedule(() => updatetasktofirebase(roster), roster.EndDateTime.Add(tm));

			return RedirectPermanent("/Roster/Roster");
		}
		[HttpGet]
		public IActionResult Calendar()
		{
			return View();
		}

		[Route("/getevents")]
		public IActionResult getevents()
		{
			List <CalendarJObject> calj = new List<CalendarJObject>();
			var tasks = _rostRepo.getalltask();
			foreach (var item in tasks)
			{
				CalendarJObject cj = new CalendarJObject
				{
					title = item.StaffName,
					start = item.StartDateTime,
					end = item.EndDateTime
				};
				calj.Add(cj);
			}
			string jsoncal = JsonSerializer.Serialize(calj);
			Console.WriteLine(jsoncal);
			return Ok(jsoncal);
		}

		public void tasktofirebase(RosterViewModel model)
		{
			var client = new FireSharp.FirebaseClient(config);
			var data = model;
			SetResponse setResponse = client.Set("Tasks/"+data.TaskID, data);



		}
		public void updatetasktofirebase(RosterViewModel model)
		{
			var client = new FireSharp.FirebaseClient(config);
			var data = model;
			SetResponse response = client.Set("Tasks/"+data.TaskID, data);


		}
	}
}
