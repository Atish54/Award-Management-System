

namespace AwardManagment.BusinessObjects.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class BOApplicationDetail
    {
        public System.Guid AppId { get; set; }
        public System.Guid QueId { get; set; }
        public string Answer { get; set; }
    
        public virtual BOApplication Application { get; set; }
        public virtual BOQuestion Question { get; set; }
    }
}
