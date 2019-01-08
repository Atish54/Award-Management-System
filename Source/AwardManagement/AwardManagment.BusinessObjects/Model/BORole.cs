using System;
using System.Collections.Generic;

namespace AwardManagment.BusinessObjects.Model
{
    
    
    public partial class BORole
    {
        public BORole()
        {
            this.UserRoles = new HashSet<BOUserRole>();
        }
        public System.Guid RoleId { get; set; }
        public string Role1 { get; set; }
        public bool IsDisable { get; set; }
        public virtual IEnumerable<BOUserRole> UserRoles { get; set; }
    }
}
