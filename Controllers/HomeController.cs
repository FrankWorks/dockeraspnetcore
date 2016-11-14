using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    
    public class HomeController : Controller
    {
        private MeetingDbContext ctx = new MeetingDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult CreateConference()
        {
            var conference = new Conference {
                Name ="Firset Conference",
                TicketPrice = 250.00m
            };
            ctx.Conferences.Add(conference);
            ctx.SaveChanges();

            var sessionTitles = new List<string> {
                ".Net Core", "ASP.NET Core", "Entity Framework Core"
            };

            foreach (var title in sessionTitles)
            {
                var session = new Session {
                    Title=title,
                    Conference = conference

                };

                ctx.Sessions.Add(session);
                ctx.SaveChanges();
            }
            return RedirectToAction("ViewConference");
        }
        
        public IActionResult ViewConference()
        {
            var conference = ctx.Conferences.Include( c=> c.Sessions).First();
            return View(conference);
        }

    }
}
