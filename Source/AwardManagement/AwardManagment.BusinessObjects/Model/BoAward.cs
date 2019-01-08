using System;
using System.Collections.Generic;
namespace AwardManagment.BusinessObjects.Model
{
  
    
    public partial class BOAward
    {
        public BOAward()
        {
            this.Applications = new HashSet<BOApplication>();
            this.UserRoles = new HashSet<BOUserRole>();
            this.Questions = new HashSet<BOQuestion>();
        }
    
        public System.Guid AwdId { get; set; }
        public System.Guid SubCateId { get; set; }
        public string AwardName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public System.DateTime DateCreated { get; set; }
        public bool IsDisable { get; set; }
        public virtual ICollection<BOApplication> Applications { get; set; }
        public virtual BOSubCategory SubCategory { get; set; } 
        public virtual ICollection<BOUserRole> UserRoles { get; set; }
        public virtual ICollection<BOQuestion> Questions { get; set; }
    }
}
