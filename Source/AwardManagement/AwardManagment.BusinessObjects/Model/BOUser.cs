

using System.Collections.Generic;

namespace AwardManagment.BusinessObjects.Model
{
    
    public partial class BOUser
    {
        public BOUser()
        {
            this.Applications = new HashSet<BOApplication>();
            this.Notifications = new HashSet<BONotification>();
            this.UserRoles = new HashSet<BOUserRole>();
        }
        public System.Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public bool Gender { get; set; }
        public System.DateTime DOB { get; set; }
        public System.DateTime DOJ { get; set; }
        public string Designation { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public bool IsDisable { get; set; }
        public virtual IEnumerable<BOApplication> Applications { get; set; }
        public virtual IEnumerable<BONotification> Notifications { get; set; }
        public virtual BOUserRating UserRating { get; set; }
        public virtual IEnumerable<BOUserRole> UserRoles { get; set; }
    }
}
