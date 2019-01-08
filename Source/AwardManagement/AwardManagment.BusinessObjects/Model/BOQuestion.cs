
using System.Collections.Generic;
namespace AwardManagment.BusinessObjects.Model
{
    public partial class BOQuestion
    {
        public BOQuestion()
        {
            this.ApplicationDetails = new HashSet<BOApplicationDetail>();
            this.Awards = new HashSet<BOAward>();
        }
        public System.Guid QueId { get; set; }
        public string Question1 { get; set; }
        public bool IsDisable { get; set; }
        public virtual ICollection<BOApplicationDetail> ApplicationDetails { get; set; }
        public virtual ICollection<BOAward> Awards { get; set; }
    }
}
