using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwardManagment.BusinessObjects.Model;
using AwardManagment.Data.Core;

namespace AwardManagment.Data.Repository
{
    public class CategoryRepository : Repository<BOCategory>, ICategoryRepository
    {
        public CategoryRepository(AwardDBEntities context) : base(context)
        {
        }

        public AwardDBEntities AwardDBEntities { get { return Context as AwardDBEntities; } }

        public IEnumerable<BOCategory> GetAllCategories()
        {
            return AwardDBEntities.Categories.Select(c => new BOCategory
            {
                CateId = c.CateId,
                Category1 = c.Category1,
                ShortDescription = c.ShortDescription,
                LongDescription = c.LongDescription,
                IsDisable = c.IsDisable
            }).Where( a=> a.IsDisable==false ).OrderByDescending(c => c.IsDisable).ToList();
        }

        public BOCategory GetCategory(string categoryname)
        {
            return AwardDBEntities.Categories.Select(c => new BOCategory { Category1 = c.Category1, CateId = c.CateId, IsDisable = c.IsDisable, LongDescription = c.LongDescription, ShortDescription = c.ShortDescription }).Where(s => s.Category1 == categoryname).Single();
        }

        public BOCategory GetCategory(Guid id)
        {
            return AwardDBEntities.Categories.Select(c => new BOCategory
            {
                Category1 = c.Category1,
                CateId = c.CateId,
                IsDisable = c.IsDisable,
                LongDescription = c.LongDescription,
                ShortDescription = c.ShortDescription,
                
            }).Where(s => s.CateId == id).Single();
        }

        public void InsertCategory(BOCategory BOCategory)
        {
            Category cat = new Category()
            {
                CateId = Guid.NewGuid(),
                Category1 = BOCategory.Category1,
                ShortDescription = BOCategory.ShortDescription,
                LongDescription = BOCategory.LongDescription,
                IsDisable = false
            };
            AwardDBEntities.Categories.Add(cat);

        }

        public void RemoveCategory(Guid Removeid)
        {
            var Removecategory = AwardDBEntities.Categories.Single(ct => ct.CateId == Removeid);
            Removecategory.IsDisable = true;

            //. Entry(Category)..State = EntityState.Modified;
        }

        public void UpcateCategory(BOCategory BOCategory)
        {

            Category cat = new Category()
            {
                CateId = BOCategory.CateId,
                Category1 = BOCategory.Category1,
                ShortDescription = BOCategory.ShortDescription,
                LongDescription = BOCategory.LongDescription,
                IsDisable = BOCategory.IsDisable
            };
            AwardDBEntities.Entry(cat).State = EntityState.Modified;
        }
    }
}
