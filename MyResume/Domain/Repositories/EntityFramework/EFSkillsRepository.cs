using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyResume.Domain.Entities;
using MyResume.Domain.Repositories.Abstract;

namespace MyResume.Domain.Repositories.EntityFramework
{
    public class EFSkillsRepository: ISkillsRepository
    {
        private readonly AppDbContext context;

        public EFSkillsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Skill> GetSkills()
        {
            return context.Skills;
        }

        public Skill GetSkillById(Guid id)
        {
            return context.Skills.FirstOrDefault(s => s.Id == id);
        }


        public void SaveSkill(Skill entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;

            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteSkill(Guid id)
        {
            context.Skills.Remove(new Skill() { Id = id });
            context.SaveChanges();
        }
    }
}

