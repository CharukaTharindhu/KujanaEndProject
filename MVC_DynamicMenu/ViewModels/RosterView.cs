using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.ViewModels
{
	public class RosterView
	{
		public int StaffID { get; set; }
		public string StaffName { get; set; }
		public string StartDate { get; set; }
		public string StartTime { get; set; }
		public string EndDate { get; set; }
		public string EndTime { get; set; }
		public string Location { get; set; }
		public string status { get; set; }
		public double offset { get; set; }
	}
}
