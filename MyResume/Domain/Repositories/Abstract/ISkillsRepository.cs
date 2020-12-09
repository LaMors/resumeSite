using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyResume.Domain.Entities;

namespace MyResume.Domain.Repositories.Abstract
{
    public interface ISkillsRepository
    {
        IQueryable<Skill> GetSkills();
        Skill GetSkillById(Guid id);
        void SaveSkill(Skill entity);
        void DeleteSkill(Guid id);
    }
}
