using AwardManagment.BusinessObjects.Model;
using AwardManagment.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwardManagment.Data.Repository
{
    public class UserRatingRepository : Repository<BOUserRating>, IUserRatingRepository
    {
        public UserRatingRepository(AwardDBEntities context) :
            base(context){ }
        public AwardDBEntities AwardDBEntities { get { return Context as AwardDBEntities; } }
        public IEnumerable<BOUserRating> GetUserRating(Guid applicationid)
        {
            var v = AwardDBEntities.UserRatings.Select(t => new BOUserRating
            {
                AppId = t.AppId,
                Rating = t.Rating,
                Reason = t.Reason,
                UserId = t.UserId,
                User = new BOUser { Name = t.User.Name }
            }).Where(a => a.AppId == applicationid).ToList();
            return v;
        }
        public void AddUserRating(BOUserRating a)
        {
            AwardDBEntities.UserRatings.Add(new UserRating() { AppId= a.AppId,Rating=a.Rating,Reason=a.Reason,UserId=a.UserId });
        }
        public void UpdateUserRating(BOUserRating b)
        {
            UserRating u=new UserRating() { AppId = b.AppId, Rating = b.Rating, Reason = b.Reason, UserId = b.UserId };
            AwardDBEntities.Entry(u).State = System.Data.Entity.EntityState.Modified;
        }

    }
}
