using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwardManagment.Data.Core;
using AwardManagment.BusinessObjects.Model;
using System.Data.Entity;
using AwardManagment.Data.Repository;

namespace AwardManagment.Data.Repository
{
    public class NotificationRepository : Repository<BONotification>, INotificationRepository
    {
       
        public NotificationRepository(AwardDBEntities context)
            : base(context)
        {
        }

        public AwardDBEntities AwardDBEntities { get { return Context as AwardDBEntities; } }

         IEnumerable<BONotification> INotificationRepository.GetAllNotification()
        {

            return AwardDBEntities.Notifications.Select(t => new BONotification
            {
                NotificationID = t.NotificationID,
                Details = t.Details,
                IsCompleted = t.IsCompleted,
                User = new BOUser()
                {
                    UserId = t.UserId,
                }
            }).ToList();   
        }
        IEnumerable<BONotification> INotificationRepository.GetAllNotification(Guid userid)
        {

            return AwardDBEntities.Notifications.Select(t => new BONotification
            {
                NotificationID = t.NotificationID,
                Details = t.Details,
                IsCompleted = t.IsCompleted,
                UserId=t.UserId,
                User = new BOUser()
                {
                    UserId = t.UserId,
                }
            }).Where(y=> y.UserId== userid).ToList();
        }
        BONotification INotificationRepository.GetNotification(Guid id)
        {
            var notification = AwardDBEntities.Notifications.Select(t => new BONotification
            {
                NotificationID = t.NotificationID,
                Details = t.Details,
                IsCompleted = t.IsCompleted,
                User = new BOUser()
                {
                    UserId = t.UserId,
                }

            }).Where(t => t.NotificationID == id).First();
            return notification;
        }

        void INotificationRepository.InsertNotitification(BONotification notification)
        {
            AwardDBEntities.Notifications.Add(new Notification
            {
                NotificationID=notification.NotificationID,
                IsCompleted=notification.IsCompleted,
                Details=notification.Details,
                UserId=notification.UserId,
               


            });
        }

        //void INotificationRepository.UpdateNotification(BONotification notification)
        //{
        //    Notification N = new Notification()
        //    {
        //        NotificationID = notification.NotificationID,
        //        Details = notification.Details,
        //        IsCompleted = notification.IsCompleted,
        //    };
        //    AwardDBEntities.Entry(N).State = EntityState.Modified;
        //}



        void INotificationRepository.DeleteNotification(Guid id)
        {
            var temp = AwardDBEntities.Notifications.Single(u => u.NotificationID == id);
            temp.IsCompleted = true;
        }

        public void InsertNotitification(BONotification Notification)
        {
            throw new NotImplementedException();
        }
    }
}
