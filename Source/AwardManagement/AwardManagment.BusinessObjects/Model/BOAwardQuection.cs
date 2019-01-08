using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwardManagment.BusinessObjects.Model
{
    public class BOAwardQuection
    {
        public System.Guid QueId { get; set; }
        public System.Guid AwdId { get; set; }
        public bool isDisable { get; set; }

        public virtual BOAward Award { get; set; }
        public virtual BOQuestion Question { get; set; }

    }
}
