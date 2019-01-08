using AwardManagment.BusinessObjects.Model;
using AwardManagment.Data;
using AwardManagment.Data.Repository;
using System;
using System.Collections.Generic;
using System.Web.Http;
namespace AwardManagment.WebApi.Controllers
{
    public class QuestionController : ApiController
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork(new AwardDBEntities());
        public IEnumerable<BOQuestion> Get()
        {
            return _UnitOfWork.QuestionRepository.GetAllQuestions();
        }
        public BOQuestion GetQuestion(Guid id)
        {
            return _UnitOfWork.QuestionRepository.GetQuestion(id);
        }
        public bool PostQuestion(BOQuestion _BOQuestion)
        {
            try
            {
                _UnitOfWork.QuestionRepository.InsertQuestion(_BOQuestion);
                _UnitOfWork.Complete();
                return true;
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
            finally { _UnitOfWork.Dispose(); }
            return false;
        }
        public bool PutQuestion(BOQuestion _BOQuestion)
        {
            try
            {
                _UnitOfWork.QuestionRepository.UpdateQuestion(_BOQuestion);
                _UnitOfWork.Complete();
                return true;
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
            finally { _UnitOfWork.Dispose(); }
            return false;
        }
        public bool DeleteQuestion(Guid id)
        {
            try
            {
                _UnitOfWork.QuestionRepository.RemoveQuestion(id);
                _UnitOfWork.Complete();
                return true;
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
            finally { _UnitOfWork.Dispose(); }
            return false;
        }


    }
}
