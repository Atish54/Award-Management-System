//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AwardManagment.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Application
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Application()
        {
            this.ApplicationDetails = new HashSet<ApplicationDetail>();
            this.UserRatings = new HashSet<UserRating>();
        }
    
        public System.Guid AppId { get; set; }
        public System.DateTime AppliedDate { get; set; }
        public int Stage { get; set; }
        public System.Guid AwdId { get; set; }
        public System.Guid UserId { get; set; }
        public Nullable<bool> isRejected { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicationDetail> ApplicationDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRating> UserRatings { get; set; }
        public virtual Award Award { get; set; }
        public virtual User User { get; set; }
    }
}
