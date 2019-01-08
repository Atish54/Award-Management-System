using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwardManagment.BusinessObjects.Model;
using AwardManagment.Data.Core;

namespace AwardManagment.Data.Repository
{
    class ApplicationDetailRepository : Repository<BOApplicationDetail>, IApplicationDetailRepository
    {
        public ApplicationDetailRepository(DbContext context) : base(context)
        {
        }
        public AwardDBEntities AwardDBEntities { get { return Context as AwardDBEntities; } }
        public void InsertApplication(BOApplicationDetail BOApplication)
        {
            ApplicationDetail App = new ApplicationDetail()
            {
                AppId = BOApplication.AppId,
                Answer = BOApplication.Answer,
                QueId = BOApplication.QueId,
            };
            AwardDBEntities.ApplicationDetails.Add(App);
        }

        public void UpdateApplication(BOApplicationDetail BOApplication)
        {
            // This Update Method Access by only Admin and Admin can change only Stage part

            ApplicationDetail App = new ApplicationDetail()
            {
                AppId = BOApplication.AppId,
                Answer = BOApplication.Answer,
                QueId = BOApplication.QueId,
            };
            AwardDBEntities.Entry(App).State = EntityState.Modified;
        }
    }
}
