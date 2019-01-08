using AwardManagment.BusinessObjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwardManagment.Data.Core
{
    public interface IQuestionRepository : IRepository<BOQuestion>
    {
        IEnumerable<BOQuestion> GetAllQuestions();
        BOQuestion GetQuestion(Guid id);

        void InsertQuestion(BOQuestion question);

        void RemoveQuestion(Guid id);

        void UpdateQuestion(BOQuestion question);

    }
}
