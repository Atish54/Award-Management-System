
using System;

namespace AwardManagment.BusinessObjects.Model
{
   
    public partial class BOUserRole
    {
        public System.Guid UserId { get; set; }
        public System.Guid RoleId { get; set; }
        public bool IsDisable { get; set; }
        public Nullable<System.Guid> AwardId { get; set; }
        public virtual  BOAward Award { get; set; }
        public virtual BORole Role { get; set; }
        public virtual BOUser User { get; set; }
    }
}
