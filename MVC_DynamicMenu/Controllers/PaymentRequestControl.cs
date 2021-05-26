using Microsoft.AspNetCore.Mvc;
using MVC_DynamicMenu.Models;
using MVC_DynamicMenu.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Controllers
{
    public class PaymentRequestControl : Controller
    {
        private readonly PyamentReqRepo _c = null;

        public PaymentRequestControl(PyamentReqRepo c)
        {
            _c = c;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ShowAllPaymentRequest()
        {
            List<MainBudgetAgreement> newBudget = _c.GetAllBudgetInfo();
            List<PaymentRequest> Payment = new List<PaymentRequest>();

            foreach (var item in newBudget)
            {
                PaymentRequest payment = new PaymentRequest
                {
                    PaymentID = item.MainBudgetID,
                    Biller_Type = item.MySupport[0].Biller_type,
                    Created_Date = item.ServiceSchedules[0].Start_date_and_time,
                    Line_Item_Qty = item.MySupport[0].Qty_week,
                    Total = item.MySupport[0].Total_price,
                    Status = "Publish",
                    External_Reference = "",

                };
                Payment.Add(payment);
            }
            return View(Payment);

        }

        [HttpGet]
        public ViewResult ViewBudgetInfoByID(int id)
        {
            MainBudgetAgreement budget = _c.GetAllBudgetInfoByID(id);
            return View(budget);
        }

    }
}
