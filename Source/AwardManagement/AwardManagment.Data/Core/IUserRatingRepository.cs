using AwardManagment.BusinessObjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwardManagment.Data.Core
{
   public interface IUserRatingRepository: IRepository<BOUserRating>
    {
        IEnumerable<BOUserRating> GetUserRating(Guid applicationid);
        void AddUserRating(BOUserRating a);
        void UpdateUserRating(BOUserRating b);
    }
}
