using AwardManagment.BusinessObjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwardManagment.Data.Core
{
    public interface IUserRoleRepository:IRepository<BOUserRole>
    {
        IEnumerable<BOUserRole> GetAllUser();
        BORole GetRole(Guid id);
       // BOUser GetUserRole(Guid roleid);
        void AssignRole(BOUserRole b);
       // void UpdateUser(BOUser user);
        //void RemoveUser(Guid id);
        void RemoveRoleUser(Guid roleid);
        void RemoveUserRole(Guid userid, Guid roleid);
        void RemoveUserRole(Guid userid);
    }
}
