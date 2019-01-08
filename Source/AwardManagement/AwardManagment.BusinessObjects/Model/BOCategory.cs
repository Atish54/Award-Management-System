using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AwardManagment.BusinessObjects.Model
{
    public partial class BOCategory
    {
        public BOCategory()
        {
            this.SubCategories = new HashSet<BOSubCategory>();
        }

        [Key]
        public System.Guid CateId { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z\\s]+$", ErrorMessage = "Use Characters only")]
        public string Category1 { get; set; }

        public bool IsDisable { get; set; }

        [Required(ErrorMessage = "Enter Short Name")]
        [StringLength(2, ErrorMessage = "Enter only 2 Char", MinimumLength = 2)]
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "Enter Long Name")]
        public string ShortDescription { get; set; }
        public virtual ICollection<BOSubCategory> SubCategories { get; set; }
    }
}
