using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_DynamicMenu.Models;
using MVC_DynamicMenu.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Controllers
{
    public class AddNewFoodAndFluidController : Controller
    {
        private readonly AddNewFoodAndFluidRepo _context = null;

        public AddNewFoodAndFluidController(AddNewFoodAndFluidRepo context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult AddNewFoodAndFluid()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewFoodAndFluid(AddNewFoodAndFluid FF)
        {
            _context.AddNewFoodAndFluid(FF);
            return RedirectPermanent("/AddNewFoodAndFluid/ShowAllFoodAndFluid");
        }

        public void setSession(int id)
        {
            var newUser = _context.getUserById(id);
            HttpContext.Session.SetString("loggedname", newUser.Clients);
        }

            public ViewResult ShowAllFoodAndFluid()
        {
            HttpContext.Session.SetString("FoodsAndFluids", _context.GetPatients());       
            var FF = _context.getAllFoodAndFluid();
            return View(FF);

        }
        [HttpGet]
        public ViewResult UpdateFoodAndFluid(int id)
        {
            AddNewFoodAndFluid FF = _context.getFFId(id);
            return View(FF);
        }

        [HttpGet]
        public ViewResult ViewFoodAndFluid(int id)
        {
            AddNewFoodAndFluid FF = _context.getFFId(id);
            return View(FF);
        }

        [Route("/AddNewFoodAndFluid/DeleteFoodAndFluid/{id:int}")]
        public ActionResult DeleteFoodAndFluid(int id)
        {
            _context.DeleteFoodAndFluid(id);
            return RedirectPermanent("/AddNewFoodAndFluid/ShowAllFoodAndFluid");
        }

        [HttpPost]
        public ActionResult UpdateFoodAndFluid(AddNewFoodAndFluid model)
        {
            _context.UpdateFoodAndFluid(model);
            return RedirectPermanent("/AddNewFoodAndFluid/ShowAllFoodAndFluid");
        }

        [Route("/AddNewFoodAndFluid/PlanView/{id:int}")]
        [HttpGet]
        public ActionResult PlanView(int id)
        {
            var obj = _context.getFFById(id);
            return View(obj);
        }


        [Route("/AddNewFoodAndFluid/EditPlan/{id:int}")]
        [HttpGet]
        public ActionResult EditPlan(int id)
        {
            var obj = _context.getFFId(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult EditPlan(AddNewFoodAndFluid model)
        {
            _context.updateFF(model);
            return RedirectPermanent("/AddNewFoodAndFluid/ShowAllFoodAndFluid");
        }


        [HttpGet]
        [Route("AddNewFoodAndFluid/FFApprove/{id:int}")]
        public ActionResult FFApprove(int id)
        {
            _context.approvemed(id);
            return RedirectPermanent("/AddNewFoodAndFluid/ShowAllFoodAndFluid");
        }


    }
}
