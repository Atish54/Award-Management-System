using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwardManagment.BusinessObjects.Model;
namespace AwardManagment.Data.Core
{
   public interface INotificationRepository : IRepository<BONotification>
    {
        IEnumerable<BONotification> GetAllNotification();

        BONotification GetNotification(Guid id);
        IEnumerable<BONotification> GetAllNotification(Guid userid);

       void InsertNotitification(BONotification Notification);

      //  void UpdateNotification(BONotification Notification);

        void DeleteNotification(Guid id);
        
    }
}
