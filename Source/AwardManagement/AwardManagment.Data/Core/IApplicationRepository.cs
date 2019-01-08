using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwardManagment.BusinessObjects.Model;

namespace AwardManagment.Data.Core
{
    public interface IApplicationRepository : IRepository<BOApplication>
    {
        IEnumerable<BOApplication> GetAppApplications();

        BOApplication GetApplication(Guid id);
        IEnumerable<BOApplication> GetAppApplications(int stage);
        BOApplication InsertApplication(BOApplication BOApplication);

        void UpdateApplication(BOApplication BOApplication);

       
    }
}
