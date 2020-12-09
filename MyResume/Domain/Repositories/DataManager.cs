using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyResume.Domain.Repositories.Abstract;

namespace MyResume.Domain.Repositories
{
    public class DataManager
    {
        public ITextFeldsRepository TextFields { get; set; }
        public ISkillsRepository Skills { get; set; }

        public DataManager(ITextFeldsRepository textFieldsRepository, ISkillsRepository skillsRepository)
        {
            TextFields = textFieldsRepository;
            Skills = skillsRepository;
        }
    }
}
