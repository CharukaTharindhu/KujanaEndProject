using Microsoft.EntityFrameworkCore;
using MVC_DynamicMenu.Data;
using MVC_DynamicMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Repo
{
	public class RosterRepo
	{
		private readonly DynamicMenuDBContext _context = null;

		public RosterRepo(DynamicMenuDBContext dynamicMenuDBContext)
		{
			_context = dynamicMenuDBContext;
		}

		public int AddRosterTask(RosterViewModel model)
		{
			_context.Roster.Add(model);
			_context.SaveChanges();
			return (model.TaskID);
		}
		public void StartTask(int id)
		{
			var task = _context.Roster.FirstOrDefault(s => s.TaskID == id);
			task.status = "Started";
			_context.SaveChanges();
		}

		public void EndTask(int id)
		{
			var task = _context.Roster.FirstOrDefault(s => s.TaskID == id);
			task.status = "Ended";
			_context.SaveChanges();
		}

		public List<RosterViewModel> getalltask()
		{
			var obj = _context.Roster.ToList();
			return obj;
		}

		public List<Users> getallusers()
		{
			var obj = _context.Users.Include(s => s.MyProfile).ToList();
		
			return obj;
		}
	}
}
