using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Service;
using MyResume.Domain.Entities;
using MyResume.Domain.Repositories;

namespace MyResume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        public SkillsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new Skill() : dataManager.Skills.GetSkillById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(Skill model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    model.TitleImagePath = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                dataManager.Skills.SaveSkill(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.Skills.DeleteSkill(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
