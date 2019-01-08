using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwardManagment.BusinessObjects.Model
{
    public class BOAddAward
    {
        public System.Guid SubCateId { get; set; }
        public string AwardName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.Guid[] QueId { get; set; }
        public System.Guid AssesorUserId { get; set; }
        public System.Guid JuryUserId { get; set; }
        public System.Guid ChairmanUserId { get; set; }
        public System.Guid AssesorRoleId { get; set; }
        public System.Guid JuryRoleId { get; set; }
        public System.Guid ChairmanRoleId { get; set; }

    }
}
