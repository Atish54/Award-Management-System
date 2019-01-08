using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwardManagment.BusinessObjects.Model
{
    public partial class BONews
    {
        public System.Guid NewsId { get; set; }
        public string News1 { get; set; }
        public bool IsDisable { get; set; }
    }
}
