using System;
using System.Collections.Generic;

namespace AwardManagment.BusinessObjects.Model
{
    public partial class BOSubCategory
    {
        public BOSubCategory()
        {
            this.Awards = new HashSet<BOAward>();
        }
        public System.Guid SubCateId { get; set; }
        public string SubCategory1 { get; set; }
        public System.Guid CateId { get; set; }
        public bool IsDisable { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public virtual IEnumerable<BOAward> Awards { get; set; }
        public virtual BOCategory Category { get; set; }
    }
}
