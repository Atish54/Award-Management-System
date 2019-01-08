using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwardManagment.BusinessObjects.Model;

namespace AwardManagment.Data.Core
{
    public interface IApplicationDetailRepository : IRepository<BOApplicationDetail>
    {
        void InsertApplication(BOApplicationDetail BOApplication);

        void UpdateApplication(BOApplicationDetail BOApplication);

       
    }
}
