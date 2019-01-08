using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwardManagment.BusinessObjects.Model;
namespace AwardManagment.Data.Core
{
    public interface ISubCategoryRepository :IRepository<BOSubCategory>
    {
        IEnumerable<BOSubCategory> GetAllSubCategories();

        BOSubCategory GetSubCategory(Guid id);
        IEnumerable<BOSubCategory> GetSubCategories(Guid cateid);
        BOSubCategory GetSubCategory(string Subcategoryname);

        void InsertSubCategory(BOSubCategory BOSubCategory);

        void RemoveSubCategory(Guid Removeid);

        void UpdateSubCategory(BOSubCategory BOSubCategory);

    }
}
