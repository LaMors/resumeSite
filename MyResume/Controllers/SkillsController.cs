using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyResume.Domain.Repositories;

namespace MyResume.Controllers
{
    public class SkillsController: Controller
    {
        private readonly DataManager dataManager;

        public SkillsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult MySkills(Guid id)
        {
            if (id != default)
            {
                return View("Show", dataManager.Skills.GetSkillById(id));
            }

            ViewBag.TextField = dataManager.TextFields.GetFieldByCodeWord("PageSkills");
            return View(dataManager.Skills.GetSkills());
        }
    }
}
