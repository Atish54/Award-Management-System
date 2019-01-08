using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AwardManagment.BusinessObjects.Model;
using System.Threading.Tasks;

namespace AwardManagment.Data.Core
{
    public interface IAwardQuestionsRepository : IRepository<BOAwardQuection>
    {
        void InsertCategory(BOAwardQuection BOAwardQuection);
    }

   
}
