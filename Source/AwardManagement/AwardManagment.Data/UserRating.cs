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
    using System.ComponentModel.DataAnnotations;

    public partial class UserRating
    {
        [Key]
        public System.Guid AppId { get; set; }
        [Key]
        public System.Guid UserId { get; set; }
        public int Rating { get; set; }
        public string Reason { get; set; }
    
        public virtual Application Application { get; set; }
        public virtual User User { get; set; }
    }
}
