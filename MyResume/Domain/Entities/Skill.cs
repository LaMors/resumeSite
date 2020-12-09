using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyResume.Domain.Entities
{
    public class Skill: EntityBase
    {
        [Required(ErrorMessage = "Заполните название навыка")]
        [Display(Name = "Название навыка (заголовок)")] 
        public override string Title { get; set; }

        [Display(Name = "Краткое описание навыка")]
        public override string Subtitle { get; set; }

        [Display(Name = "Полное описание навыка")]
        public override string Text { get; set; }
    }
}
