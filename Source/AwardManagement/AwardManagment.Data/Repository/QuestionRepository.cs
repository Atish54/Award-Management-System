using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwardManagment.Data.Core;
using AwardManagment.BusinessObjects.Model;
using System.Data.Entity;

namespace AwardManagment.Data.Repository
{
    public class QuestionRepository : Repository<BOQuestion>, IQuestionRepository
    {
        public QuestionRepository(AwardDBEntities context)
            : base(context)
        {
        }
        public AwardDBEntities AwardDBEntities { get { return Context as AwardDBEntities; } }
        public IEnumerable<BOQuestion> GetAllQuestions()
        {
            return AwardDBEntities.Questions.Select(t => new BOQuestion
            {
                QueId = t.QueId,
                Question1 = t.Question1,
                IsDisable = t.IsDisable,
            });
        }
        public BOQuestion GetQuestion(Guid id)
        {
            var questions = AwardDBEntities.Questions.Select(t => new BOQuestion
            {
                QueId = t.QueId,
                Question1 = t.Question1,
                IsDisable = t.IsDisable,
            }).Where(t => t.QueId == id).First();
            return questions;
        }
        public void InsertQuestion(BOQuestion question)
        {
            AwardDBEntities.Questions.Add(new Question
            {
                QueId = Guid.NewGuid(),
                Question1 = question.Question1,
                IsDisable = false,
            });
        }
        public void RemoveQuestion(Guid id)
        {
            var temp = AwardDBEntities.Questions.Single(u => u.QueId == id);
            temp.IsDisable = true;
        }
        public void UpdateQuestion(BOQuestion question)
        {
            Question q = new Question()
            {
                QueId = question.QueId,
                Question1 = question.Question1,
                IsDisable = false,
            };
            AwardDBEntities.Entry(q).State = EntityState.Modified;
        }
    }
}
