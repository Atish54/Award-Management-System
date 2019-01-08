using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AwardManagment.BusinessObjects.Model;
using AwardManagment.Data;
using AwardManagment.Data.Repository;

namespace AwardManagment.WebApi.Controllers
{
    public class NewsController : ApiController
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork(new AwardDBEntities());
        public IEnumerable<BONews> Get()
        {
            return _UnitOfWork.NewsRepository.GetAllNews();
        }
        public BONews GetNews(Guid id)
        {
            return _UnitOfWork.NewsRepository.GetNews(id);
        }
        public bool PostNews(BONews _BONews)
        {
            try
            {
                _UnitOfWork.NewsRepository.InsertNews(_BONews);
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
        public bool PutNews(BONews _BONews)
        {
            try
            {
                _UnitOfWork.NewsRepository.UpdateNews(_BONews);
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
        public bool DeleteNews(Guid id)
        {
            try
            {
                _UnitOfWork.NewsRepository.RemoveNews(id);
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
