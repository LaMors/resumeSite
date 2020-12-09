using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyResume.Domain.Repositories;
using MyResume.Service;

namespace MyResume.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly MailHelper mailHelper;
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager, ILogger<HomeController> logger, MailHelper mailHelper)
        {
            this.dataManager = dataManager;
            this.logger = logger;
            this.mailHelper = mailHelper;
        }

        public IActionResult Index()
        {
            return View(dataManager.TextFields.GetFieldByCodeWord("PageIndex"));
        }

        [HttpPost]
        public IActionResult SendMessage(string name, string sender, string subject, string body)
        {
            mailHelper.SendEmail(name, sender, subject, body);
            return RedirectToAction("Index");
        }
    }
}
