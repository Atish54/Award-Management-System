using System.Linq;
using AwardManagment.Data.Core;
using AwardManagment.BusinessObjects.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace AwardManagment.Data.Repository
{
    public class UserRepository : Repository<BOUser>, IUserRepository
    {
        public UserRepository(AwardDBEntities context) :
            base(context)
        {
        }
        public AwardDBEntities AwardDBEntities { get { return Context as AwardDBEntities; } }

        
        public bool Emailcheck(string email)
        {
            var data = AwardDBEntities.Users.Where(u => u.Email == email).FirstOrDefault();
            if (data != null) { return true; }
            return false;
        }

        public IEnumerable<BOUser> GetAllUser()
        {
            return AwardDBEntities.Users.Select(u => new BOUser
            {
                Designation = u.Designation,
                DOB = u.DOB,
                DOJ = u.DOJ,
                Email = u.Email,
                Gender = u.Gender,
                Image = u.Image,
                IsActive = u.IsActive,
                IsDisable = u.IsDisable,
                Mobile = u.Mobile,
                Name = u.Name,
                Password = u.Password,
                UserId = u.UserId,
                Applications = u.Applications.Select(a => new BOApplication { AppId = a.AppId, AppliedDate = a.AppliedDate, Stage = a.Stage, AwdId = a.AwdId, UserId = a.UserId }).ToList(),
            });
        }

        public BOUser GetUser(BOLogin l)
        {
            var tmp = AwardDBEntities.Users.Select(u => new BOUser
            {
                Designation = u.Designation,
                DOB = u.DOB,
                DOJ = u.DOJ,
                Email = u.Email,
                Gender = u.Gender,
                Image = u.Image,
                IsActive = u.IsActive,
                IsDisable = u.IsDisable,
                Mobile = u.Mobile,
                Name = u.Name,
                Password = u.Password,
                UserId = u.UserId,
                UserRoles = u.UserRoles.Select(x => new BOUserRole
                {
                    AwardId = x.AwardId,
                    RoleId = x.RoleId,
                    UserId = x.UserId,
                    IsDisable = x.IsDisable,
                    Role = new BORole
                    {
                        Role1 = x.Role.Role1,
                        RoleId = x.Role.RoleId,
                        IsDisable = x.Role.IsDisable
                    }
                }).ToList(),
                Applications = u.Applications.Select(a => new BOApplication { AppId = a.AppId, AppliedDate = a.AppliedDate, Stage = a.Stage, AwdId = a.AwdId, UserId = a.UserId }).ToList(),
            }).Where(s => s.Email == l.Email && s.Password == l.Password).SingleOrDefault();
            if (tmp != null)
            {
                return tmp;
            }
            return null;
        }


        public BOUser GetUser(Guid id)
        {
            var user = AwardDBEntities.Users.Select(u => new BOUser
            {
                Designation = u.Designation,
                DOB = u.DOB,
                DOJ = u.DOJ,
                Email = u.Email,
                Gender = u.Gender,
                Image = u.Image,
                IsActive = u.IsActive,
                IsDisable = u.IsDisable,
                Mobile = u.Mobile,
                Name = u.Name,
                Password = u.Password,
                UserId = u.UserId,
                Applications = u.Applications.Select(a => new BOApplication { AppId = a.AppId, AppliedDate = a.AppliedDate, Stage = a.Stage, AwdId = a.AwdId, UserId = a.UserId }).ToList(),
                //UserRating = new BOUserRating { AppId = u.UserRating.AppId, UserId = u.UserRating.UserId, Rating = u.UserRating.Rating, Reason = u.UserRating.Reason },
                UserRoles = u.UserRoles.Select(x => new BOUserRole
                {
                    AwardId = x.AwardId,
                    RoleId = x.RoleId,
                    UserId = x.UserId
                }).ToList()
                //UserRating = new BOUserRating { AppId = u.UserRating.AppId, UserId = u.UserRating.UserId, Rating = u.UserRating.Rating, Reason = u.UserRating.Reason },
            }
                ).Where(s => s.UserId == id).First();
            return user;
        }

        public void InsertUser(BOUser user)
        {
            AwardDBEntities.Users.Add(new User
            {
                Designation = user.Designation,
                DOB = user.DOB,
                DOJ = user.DOJ,
                Email = user.Email,
                Gender = user.Gender,
                Image = user.Image,
                IsActive = true,
                IsDisable = false,
                Mobile = user.Mobile,
                Name = user.Name,
                Password = user.Password,
                UserId = Guid.NewGuid(),
            });
        }

        public void RemoveUser(Guid id)
        {
            var temp = AwardDBEntities.Users.Single(u => u.UserId == id);
            temp.IsDisable = true;
        }
        public void UpdateUser(BOUser user)
        {
            User u = new User();
            u.Designation = user.Designation;
            u.DOB = user.DOB;
            u.DOJ = user.DOJ;
            u.Email = user.Email;
            u.Gender = user.Gender;
            u.Image = user.Image;
            u.IsActive = true;
            u.IsDisable = false;
            u.Mobile = user.Mobile;
            u.Name = user.Name;
            u.Password = user.Password;
            u.UserId = user.UserId;
            AwardDBEntities.Entry(u).State = EntityState.Modified;
        }
    }

}
