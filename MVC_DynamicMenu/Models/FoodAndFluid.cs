using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class FoodAndFluid
    {
        [Key]
        public int Id { get; set; }
        public int ClientID { get; set; }
        public String Client_Name { get; set; }
        public int Pending_Plans { get; set; }
        public int Approved_Plane { get; set; }
    }
}
