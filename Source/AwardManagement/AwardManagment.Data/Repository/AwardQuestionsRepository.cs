using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwardManagment.BusinessObjects.Model;
using AwardManagment.Data.Core;

namespace AwardManagment.Data.Repository
{
    public class AwardQuestionsRepository : Repository<BOAwardQuection>, IAwardQuestionsRepository
    {
        public AwardQuestionsRepository(AwardDBEntities context) : base(context)
        {
        }

        public AwardDBEntities _AwardDBEntities { get { return Context as AwardDBEntities; } }

        public void InsertCategory(BOAwardQuection BOAwardQuection)
        {
            AwardQuestion AQ = new AwardQuestion();
            AQ.AwdId = BOAwardQuection.AwdId;
            AQ.QueId = BOAwardQuection.QueId;

            _AwardDBEntities.AwardQuestions.Add(AQ);

        }
    }
}
