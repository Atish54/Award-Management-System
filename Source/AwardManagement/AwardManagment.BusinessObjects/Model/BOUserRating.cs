

namespace AwardManagment.BusinessObjects.Model
{
   
    public partial class BOUserRating
    {
        public System.Guid AppId { get; set; }
        public System.Guid UserId { get; set; }
        public int Rating { get; set; }
        public string Reason { get; set; }
        public virtual BOApplication Application { get; set; }
        public virtual BOUser User { get; set; }
    }
}
