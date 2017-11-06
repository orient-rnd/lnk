using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LNK.AppServices.Lnk.Models.Home;

namespace LNK.AppServices.Lnk.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult About()
        {
            var team = new List<Team>();
            string path = @"E:\InkEnglish\LNK.AppServices.Lnk\wwwroot\images\profiles\profiles.txt";
            var rawtext = System.IO.File.ReadAllText(path);
            var dep = rawtext.Split('!');
            foreach (var item in dep)
            {
                var itemTeam = new Team();
                var person = item.Split(';');
                itemTeam.Name = person[0];
                itemTeam.Profiles = new List<Profile>();
                for (int i = 1; i < person.Length; i++)
                {
                    var personInfo = person[i].Split('|');
                    
                    itemTeam.Profiles.Add(new Profile() { Name = personInfo[0], Position = personInfo[1], Time = personInfo[2], Img = personInfo[3] });                    
                }
                team.Add(itemTeam);
            }
            return View(team);
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
    }
}
