using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwardManagment.BusinessObjects.Model;

namespace AwardManagment.Data.Core
{
    public interface IAwardRepository:IRepository <BOAward>
    {
        IEnumerable<BOAward> GetAllAward();

        BOAward GetAward(Guid id);

        IEnumerable<BOAward> GetAwardList(Guid id);

        Guid InsertAward(BOAward BOAward);

        void Remove(Guid Removeid);

        void UpdateAward(BOAward BOAward);
    }
}
