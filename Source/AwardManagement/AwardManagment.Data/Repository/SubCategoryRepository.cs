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
    public class SubCategoryRepository : Repository<BOSubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(DbContext context) : base(context)
        {

        }

        public AwardDBEntities AwardDBEntities { get { return Context as AwardDBEntities; } }

        public IEnumerable<BOSubCategory> GetAllSubCategories()
        {
            return AwardDBEntities.SubCategories.Select(S => new BOSubCategory
            {
                SubCategory1 = S.SubCategory1,
                SubCateId = S.SubCateId,
                CateId = S.CateId,
                IsDisable = S.IsDisable,
                LongDescription = S.LongDescription,
                ShortDescription = S.ShortDescription,
                Category = new BOCategory()
                {
                    Category1 = S.Category.Category1,
                    CateId = S.Category.CateId
                }
            });
        }
        public IEnumerable<BOSubCategory> GetSubCategories(Guid cateid)
        {
            return AwardDBEntities.SubCategories.Select(S => new BOSubCategory
            {
                SubCategory1 = S.SubCategory1,
                SubCateId = S.SubCateId,
                IsDisable = S.IsDisable,
                LongDescription = S.LongDescription,
                ShortDescription = S.ShortDescription,
                CateId=S.CateId,
                Category = new BOCategory()
                {
                    Category1 = S.Category.Category1,
                    CateId = S.Category.CateId
                }
            }).Where(s1=> s1.CateId==cateid);
        }
        public BOSubCategory GetSubCategory(string Subcategoryname)
        {
            return AwardDBEntities.SubCategories.Select(s => new BOSubCategory
            {
                SubCategory1 = s.SubCategory1,
                SubCateId = s.SubCateId,
                CateId = s.CateId,
                IsDisable = s.IsDisable,
                LongDescription = s.LongDescription,
                ShortDescription = s.ShortDescription,
                Category = new BOCategory()
                {
                    Category1 = s.Category.Category1,
                    CateId = s.Category.CateId
                }
            }).Where(s => s.SubCategory1 == Subcategoryname).Single();
        }
        public BOSubCategory GetSubCategory(Guid subCateid)
        {
            return AwardDBEntities.SubCategories.Select(s => new BOSubCategory
            {
                SubCategory1 = s.SubCategory1,
                SubCateId = s.SubCateId,
                CateId = s.CateId,
                IsDisable = s.IsDisable,
                LongDescription = s.LongDescription,
                ShortDescription = s.ShortDescription,
                Category = new BOCategory()
                {
                    Category1 = s.Category.Category1,
                    CateId = s.Category.CateId
                }
            }).Where(s => s.SubCateId == subCateid).Single();
        }

        public void InsertSubCategory(BOSubCategory BOSubCategory)
        {
            SubCategory SB = new SubCategory()
            {
                SubCateId = Guid.NewGuid(),
                SubCategory1 = BOSubCategory.SubCategory1,
                CateId = BOSubCategory.CateId,
                LongDescription = BOSubCategory.LongDescription,
                ShortDescription = BOSubCategory.ShortDescription,
                IsDisable = false,
            };

            AwardDBEntities.SubCategories.Add(SB);
        }

        public void RemoveSubCategory(Guid Removeid)
        {
            var Removesubcategory = AwardDBEntities.SubCategories.Single(sb => sb.SubCateId == Removeid);
            Removesubcategory.IsDisable = true;
        }

        public void UpdateSubCategory(BOSubCategory BOSubCategory)
        {
            SubCategory SB = new SubCategory()
            {
                SubCateId = BOSubCategory.SubCateId,
                SubCategory1 = BOSubCategory.SubCategory1,
                CateId = BOSubCategory.CateId,
                LongDescription = BOSubCategory.LongDescription,
                ShortDescription = BOSubCategory.ShortDescription,
                IsDisable = false,
            };
            AwardDBEntities.Entry(SB).State = EntityState.Modified;
        }
    }
}
