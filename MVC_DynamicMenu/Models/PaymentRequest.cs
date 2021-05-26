using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class PaymentRequest
    {
        [Key]

        public int PaymentID { get; set; }
        public String External_Reference { get; set; }
        public String Created_Date { get; set; }
        public String Status { get; set; }
        public String Line_Item_Qty { get; set; }
        public String Total { get; set; }
        public String Biller_Type { get; set; }
        public String Action { get; set; }
    }
}
