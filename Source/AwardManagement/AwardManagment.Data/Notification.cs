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
    
    public partial class Notification
    {
        public System.Guid NotificationID { get; set; }
        public bool IsCompleted { get; set; }
        public string Details { get; set; }
        public System.Guid UserId { get; set; }
    
        public virtual User User { get; set; }
    }
}