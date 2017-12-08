using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LostInTheWoods.Factory;
using LostInTheWoods.Models;

namespace LostInTheWoods.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrailFactory trailFactory;
        public HomeController(TrailFactory connect)
        {
            //Instantiate a UserFactory object that is immutable (READONLY)
            //This establishes the initial DB connection for us.
            trailFactory = connect;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.trails = trailFactory.GetAllTrails();
            return View();
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateTrail")]
        public IActionResult CreateTrail(Trail t)
        {
            if(ModelState.IsValid)
            {
                // insert trail into DB
                trailFactory.AddTrail(t);
                return RedirectToAction("Index");
            }
            return View("Add");
        }

        [HttpGet]
        [Route("trails/{id}")]
        public IActionResult ShowTrail(int id)
        {
            ViewBag.trail = trailFactory.GetSingleTrail(id);
            return View();
        }


    }
}
