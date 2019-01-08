using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwardManagment.BusinessObjects.Model;
using AwardManagment.Data.Core;
using System.Data.Entity;

namespace AwardManagment.Data.Repository
{
    public class AwardRepository : Repository<BOAward>, IAwardRepository
    {
        public AwardRepository(AwardDBEntities context) : base(context)
        {
        }

        public AwardDBEntities AwardDBEntities { get { return Context as AwardDBEntities; } }
        public IEnumerable<BOAward> GetAllAward()
        {
            return AwardDBEntities.Awards.Select(a => new BOAward
            {
                AwdId = a.AwdId,
                SubCateId = a.SubCateId,
                AwardName = a.AwardName,
                LongDescription = a.LongDescription,
                ShortDescription = a.ShortDescription,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                DateCreated = a.DateCreated,
                IsDisable = a.IsDisable,
                SubCategory = new BOSubCategory()
                {
                    SubCateId = a.SubCategory.SubCateId,
                    SubCategory1 = a.SubCategory.SubCategory1,
                    CateId = a.SubCategory.CateId,
                    IsDisable = a.SubCategory.IsDisable,
                    Category = new BOCategory()
                    {
                        CateId = a.SubCategory.Category.CateId,
                        Category1 = a.SubCategory.Category.Category1
                    }
                }
            });
        }

        public BOAward GetAward(Guid id)
        {
            return AwardDBEntities.Awards.Select(a =>
            new BOAward
            {
                AwardName = a.AwardName,
                AwdId = a.AwdId,
                IsDisable = a.IsDisable,
                LongDescription = a.LongDescription,
                ShortDescription = a.ShortDescription,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                DateCreated = a.DateCreated,
                SubCategory = new BOSubCategory()
                {
                    SubCateId = a.SubCategory.SubCateId,
                    SubCategory1 = a.SubCategory.SubCategory1,
                    CateId = a.SubCategory.CateId,
                    IsDisable = a.SubCategory.IsDisable,
                    Category = new BOCategory()
                    {
                        CateId = a.SubCategory.Category.CateId,
                        Category1 = a.SubCategory.Category.Category1
                    }
                },
                Questions = a.AwardQuestions.Select(x => new BOQuestion { QueId = x.Question.QueId, Question1 = x.Question.Question1, IsDisable = x.Question.IsDisable }).ToList()

            }).Where(s => s.AwdId == id).Single();
        }

        public IEnumerable<BOAward> GetAwardList(Guid id)
        {
            return AwardDBEntities.Awards.Select(a =>
            new BOAward
            {
                AwardName = a.AwardName,
                AwdId = a.AwdId,
                IsDisable = a.IsDisable,
                LongDescription = a.LongDescription,
                ShortDescription = a.ShortDescription,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                DateCreated = a.DateCreated,
                SubCateId=a.SubCateId,
                SubCategory = new BOSubCategory()
                {
                    SubCateId = a.SubCategory.SubCateId,
                    SubCategory1 = a.SubCategory.SubCategory1,
                    CateId = a.SubCategory.CateId,
                    IsDisable = a.SubCategory.IsDisable,
                    Category = new BOCategory()
                    {
                        CateId = a.SubCategory.Category.CateId,
                        Category1 = a.SubCategory.Category.Category1
                    }
                },
                Applications=a.Applications.Select(x=> new BOApplication
                {
                    AppId=x.AppId,
                    Stage=x.Stage,
                    UserId=x.UserId,
                    AppliedDate=x.AppliedDate,
                }).ToList() ,
                Questions=a.AwardQuestions.Select( x=> new BOQuestion { QueId= x.Question.QueId,Question1=x.Question.Question1,IsDisable=x.Question.IsDisable }).ToList()
            }).Where(s => s.SubCateId == id).ToList();
        }

        public Guid InsertAward(BOAward BOAward)
        {
            Award awd = new Award()
            {
                AwdId = Guid.NewGuid(),
                SubCateId = BOAward.SubCateId,
                AwardName = BOAward.AwardName,
                LongDescription = BOAward.LongDescription,
                ShortDescription = BOAward.ShortDescription,
                StartDate = BOAward.StartDate,
                EndDate = BOAward.EndDate,
                DateCreated = BOAward.DateCreated,
                IsDisable = BOAward.IsDisable
            };
            AwardDBEntities.Awards.Add(awd);
           
            return awd.AwdId;
        }

        public void Remove(Guid Removeid)
        {
            var Removeaward = AwardDBEntities.Awards.Single(r => r.AwdId == Removeid);
            Removeaward.IsDisable = true;
        }

        public void UpdateAward(BOAward BOAward)
        {
            Award awd = new Award()
            {
                AwdId = BOAward.AwdId,
                SubCateId = BOAward.SubCateId,
                AwardName = BOAward.AwardName,
                LongDescription = BOAward.LongDescription,
                ShortDescription = BOAward.ShortDescription,
                StartDate = BOAward.StartDate,
                EndDate = BOAward.EndDate,
                DateCreated = BOAward.DateCreated,
                IsDisable = BOAward.IsDisable
            };
            AwardDBEntities.Entry(awd).State = EntityState.Modified;
        }


    }
}
