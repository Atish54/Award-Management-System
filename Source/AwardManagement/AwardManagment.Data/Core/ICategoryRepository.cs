using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwardManagment.BusinessObjects.Model;


namespace AwardManagment.Data.Core
{
    // Note : In this interface All Category Function Define here and Inherit to IRepository<> interface


    public interface ICategoryRepository : IRepository<BOCategory>
    {
        IEnumerable<BOCategory> GetAllCategories();

        BOCategory GetCategory(Guid id);

        BOCategory GetCategory(string categoryname);

        void InsertCategory(BOCategory BOCategory);

        void RemoveCategory(Guid Removeid);

        void UpcateCategory(BOCategory BOCategory);


    }
}
