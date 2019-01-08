using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwardManagment.BusinessObjects.Model
{
    public class BOApplicationQuestions
    {
        public DateTime AppliedDate { get; set; }
        public int Stage { get; set; }
        public Guid AwdId { get; set; }
        public Guid UserId { get; set; }
        public Nullable<bool> isRejected { get; set; }
        public virtual ICollection<BOQuestionAnswer> QuestionAnswer { get; set; }
    }
    
}
