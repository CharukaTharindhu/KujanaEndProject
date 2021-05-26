﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class ServiceLog
    {
        [Key]
        public int Reference { get; set; }
        public int SSID { get; set; }
        public String Client_name { get; set; }
        public String Start_date { get; set; }
        public String End_date { get; set; }
        public String Service { get; set; }
        public String Status { get; set; }


    }
}
