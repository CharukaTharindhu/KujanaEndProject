using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
	public class RosterViewModel
	{
		[Key]
		public int TaskID { get; set; }
		public int StaffID { get; set; }
		public string StaffName { get; set; }

		public DateTime StartDateTime { get; set; }
		public DateTime EndDateTime { get; set; }
		public string Location { get; set; }
		public string status { get; set; }

	}
}
