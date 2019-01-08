using System;
using System.Collections.Generic;
namespace AwardManagment.BusinessObjects.Model
{
    
    public partial class BOApplication
    {
        public BOApplication()
        {
            this.ApplicationDetails = new HashSet<BOApplicationDetail>();
            this.UserRatings = new HashSet<BOUserRating>();
        }

        public Guid AppId { get; set; }
        public DateTime AppliedDate { get; set; }
        public int Stage { get; set; }
        public Guid AwdId { get; set; }
        public Guid UserId { get; set; }
        public Nullable<bool> isRejected { get; set; }
        public virtual IEnumerable<BOApplicationDetail> ApplicationDetails { get; set; }
        public virtual ICollection<BOUserRating> UserRatings { get; set; }
        public virtual BOAward Award { get; set; }
        public virtual BOUser User { get; set; }
    }
}