using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwardManagment.BusinessObjects.Model;
using AwardManagment.Data.Core;

namespace AwardManagment.Data.Repository
{
    public class RoleRepository:Repository<BORole>,IRoleRepository
    {
        public RoleRepository(AwardDBEntities context) : base(context)
        {

        }
        public AwardDBEntities AwardDBEntities { get { return Context as AwardDBEntities; } }
        public IEnumerable<BOUser> GetUsers(Guid roleid) {
            var v = AwardDBEntities.UserRoles.Select(t => new BOUserRole
            {
                RoleId=t.RoleId,
                User = new BOUser
                {
                    Designation = t.User.Designation,
                    DOB = t.User.DOB,
                    DOJ = t.User.DOJ,
                    Email = t.User.Email,
                    Gender = t.User.Gender,
                    Image = t.User.Image,
                    IsActive = t.User.IsActive,
                    IsDisable = t.User.IsDisable,
                    Mobile = t.User.Mobile,
                    Name = t.User.Name,
                    Password = t.User.Password,
                    UserId = t.User.UserId,
                }
            }).Where(a => a.RoleId == roleid).Select(b=> new BOUser {
                Designation = b.User.Designation,
                DOB = b.User.DOB,
                DOJ = b.User.DOJ,
                Email = b.User.Email,
                Gender = b.User.Gender,
                Image = b.User.Image,
                IsActive = b.User.IsActive,
                IsDisable = b.User.IsDisable,
                Mobile = b.User.Mobile,
                Name = b.User.Name,
                Password = b.User.Password,
                UserId = b.User.UserId,
            });
            return v;
        }
    }
}
