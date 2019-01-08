using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwardManagment.BusinessObjects.Model;
using AwardManagment.Data.Core;
namespace AwardManagment.Data.Core
{
    public interface IRoleRepository: IRepository<BORole>
    {
        IEnumerable<BOUser> GetUsers(Guid roleid);
    }
}
