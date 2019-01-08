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
    public class NotificationController : ApiController
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork(new AwardDBEntities());
        public IEnumerable<BONotification> Get()
        {
            return _UnitOfWork.NotificationRepository.GetAllNotification();
        }
        public IEnumerable<BONotification> GetNotification(Guid id)
        {
            return _UnitOfWork.NotificationRepository.GetAllNotification(id);
        }
        public bool PostNotification(BONotification _BONotification)
        {
            try
            {
                _UnitOfWork.NotificationRepository.InsertNotitification(_BONotification);
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

        //public bool PutNotification(BONotification _BONotification)
        //{
        //    try
        //    {
        //        _UnitOfWork.NotificationRepository.UpdateNotification(_BONotification);
        //        _UnitOfWork.Complete();
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.Write(e.ToString());
        //    }
        //    finally { _UnitOfWork.Dispose(); }
        //    return false;
        //}

        public bool DeleteNotification(Guid notificationguid)
        {
            try
            {
                _UnitOfWork.NotificationRepository.DeleteNotification(notificationguid);
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
