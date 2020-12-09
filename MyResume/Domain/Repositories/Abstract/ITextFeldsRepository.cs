using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyResume.Domain.Entities;

namespace MyResume.Domain.Repositories.Abstract
{
    public interface ITextFeldsRepository
    {
        IQueryable<TextField> GetTextFields();
        TextField GetTextFieldById(Guid id);
        TextField GetFieldByCodeWord(string codeWord);
        void SaveTextField(TextField entity);
        void DeleteTextField(Guid id);
    }
}
