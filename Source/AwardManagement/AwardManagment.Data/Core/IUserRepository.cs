using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwardManagment.BusinessObjects.Model;
namespace AwardManagment.Data.Core
{
    public interface IUserRepository : IRepository<BOUser>
    {
        IEnumerable<BOUser> GetAllUser();

        BOUser GetUser(Guid id);
        BOUser GetUser(BOLogin l);
        void InsertUser(BOUser user);
        void UpdateUser(BOUser user);
        void RemoveUser(Guid id);

        bool Emailcheck(string email);
    }
}
