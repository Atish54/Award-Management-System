using AwardManagment.BusinessObjects.Model;
using AwardManagment.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace AwardManagment.Data.Repository
{
    public class UserRoleRepository : Repository<BOUserRole>, IUserRoleRepository
    {
        public UserRoleRepository(AwardDBEntities context) :
            base(context)
        { }
        public AwardDBEntities AwardDBEntities { get { return Context as AwardDBEntities; } }

        public IEnumerable<BOUserRole> GetAllUser()
        {
            var v = AwardDBEntities.UserRoles.Select(t => new BOUserRole
            {
                RoleId = t.RoleId,
                Role = new BORole() { RoleId = t.Role.RoleId, Role1 = t.Role.Role1 },
                UserId = t.UserId,
                User = new BOUser()
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
                },
                IsDisable = t.IsDisable,
                AwardId = t.AwardId
            }).ToList();
            return v;
        }

        public BORole GetRole(Guid userid)
        {
            var v = AwardDBEntities.UserRoles.Select(t => new BOUserRole
            {
                UserId = t.UserId,
                Role = new BORole
                {
                    Role1 = t.Role.Role1,
                    RoleId = t.Role.RoleId,
                    IsDisable = t.Role.IsDisable,
                }
            }).Where(a => a.UserId == userid).SingleOrDefault();
            return v.Role;
        }

        //public BOUser GetUserRole(Guid roleid)
        //{
        //    var v = AwardDBEntities.UserRoles.Select(t => new BOUserRole
        //    {
        //        User = new BOUser
        //        {
        //            Designation = t.User.Designation,
        //            DOB = t.User.DOB,
        //            DOJ = t.User.DOJ,
        //            Email = t.User.Email,
        //            Gender = t.User.Gender,
        //            Image = t.User.Image,
        //            IsActive = t.User.IsActive,
        //            IsDisable = t.User.IsDisable,
        //            Mobile = t.User.Mobile,
        //            Name = t.User.Name,
        //            Password = t.User.Password,
        //            UserId = t.User.UserId,
        //        }
        //    }).Where(a => a.RoleId == roleid).SingleOrDefault();
        //    return v.User;
        //}

        public void AssignRole(BOUserRole b)
        {

            AwardDBEntities.UserRoles.Add(new UserRole() { UserId = b.UserId, RoleId = b.RoleId, IsDisable = false, AwardId = b.AwardId });
        }

        public void RemoveUserRole(Guid userid, Guid roleid)
        {
            var temp = AwardDBEntities.UserRoles.Single(u => u.UserId == userid && u.RoleId == roleid);
            temp.IsDisable = true;
        }
        public void RemoveUserRole(Guid userid)
        {
            var temp = AwardDBEntities.UserRoles.Single(u => u.UserId == userid);
            temp.IsDisable = true;
        }
        public void RemoveRoleUser(Guid roleid)
        {
            var temp = AwardDBEntities.UserRoles.Single(u => u.RoleId == roleid);
            temp.IsDisable = true;
        }

    }
}
