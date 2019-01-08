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
    class ApplicationRepository : Repository<BOApplication>, IApplicationRepository
    {
        public ApplicationRepository(DbContext context) : base(context)
        {
        }
        public AwardDBEntities AwardDBEntities { get { return Context as AwardDBEntities; } }
        public IEnumerable<BOApplication> GetAppApplications()
        {
            return AwardDBEntities.Applications.Select(A => new BOApplication
            {
                AppId = A.AppId,
                AppliedDate = A.AppliedDate,
                Stage = A.Stage,
                AwdId = A.AwdId,
                UserId = A.UserId,
                #region Award
                Award = new BOAward()
                {
                    #region SubCategory
                    SubCategory = new BOSubCategory()
                    {
                        SubCateId = A.Award.SubCategory.SubCateId,
                        SubCategory1 = A.Award.SubCategory.SubCategory1,
                        CateId = A.Award.SubCategory.CateId,
                        IsDisable = A.Award.SubCategory.IsDisable,
                        #region Category
                        Category = new BOCategory()
                        {
                            CateId = A.Award.SubCategory.Category.CateId,
                            Category1 = A.Award.SubCategory.Category.Category1
                        }
                        #endregion
                    },
                    #endregion
                    AwdId = A.Award.AwdId,
                    SubCateId = A.Award.SubCateId,
                    AwardName = A.Award.AwardName,
                    ShortDescription = A.Award.ShortDescription,
                    LongDescription = A.Award.LongDescription,
                    StartDate = A.Award.StartDate,
                    EndDate = A.Award.EndDate,
                    DateCreated = A.Award.DateCreated,
                    IsDisable = A.Award.IsDisable,
                    #region UserRole
                    UserRoles = A.Award.UserRoles.Select(x => new BOUserRole
                    {
                        RoleId = x.RoleId,
                        AwardId = x.AwardId,
                        Role = new BORole
                        {
                            RoleId = x.Role.RoleId,
                            Role1 = x.Role.Role1
                        },
                        UserId=x.UserId,
                    }).ToList()
                    #endregion
                },
                #endregion
                #region applicationDetail
                ApplicationDetails = A.ApplicationDetails.Select(y => new BOApplicationDetail
                {
                    Answer = y.Answer,
                    AppId = y.AppId,
                    QueId = y.QueId,
                    Question = new BOQuestion
                    {
                        Question1 = y.Question.Question1,
                        QueId = y.Question.QueId,
                        IsDisable = y.Question.IsDisable
                    }
                }).ToList(),
                #endregion
                #region User
                User = new BOUser()
                {
                    Designation = A.User.Designation,
                    DOB = A.User.DOB,
                    DOJ = A.User.DOJ,
                    Email = A.User.Email,
                    Gender = A.User.Gender,
                    Image = A.User.Image,
                    IsActive = A.User.IsActive,
                    IsDisable = A.User.IsDisable,
                    Mobile = A.User.Mobile,
                    Name = A.User.Name,

                    UserId = A.User.UserId,
                },
                #endregion
                #region UserRating
                UserRatings = A.UserRatings.Select(y => new BOUserRating
                {
                    AppId = y.AppId,
                    Rating = y.Rating,
                    Reason = y.Reason,
                    UserId = y.UserId,
                    User = new BOUser()
                    {
                        Designation = y.User.Designation,
                        DOB = y.User.DOB,
                        DOJ = y.User.DOJ,
                        Email = y.User.Email,
                        Gender = y.User.Gender,
                        Image = y.User.Image,
                        IsActive = y.User.IsActive,
                        IsDisable = y.User.IsDisable,
                        Mobile = y.User.Mobile,
                        Name = y.User.Name,
                        UserId = y.User.UserId,
                    }

                }).ToList(),
                #endregion
                isRejected = A.isRejected
            }).ToList();
        }
        public IEnumerable<BOApplication> GetAppApplications(int stage)
        {
            return AwardDBEntities.Applications.Select(A => new BOApplication
            {
                AppId = A.AppId,
                AppliedDate = A.AppliedDate,
                Stage = A.Stage,
                AwdId = A.AwdId,
                UserId = A.UserId,
                #region Award
                Award = new BOAward()
                {
                    #region SubCategory
                    SubCategory = new BOSubCategory()
                    {
                        SubCateId = A.Award.SubCategory.SubCateId,
                        SubCategory1 = A.Award.SubCategory.SubCategory1,
                        CateId = A.Award.SubCategory.CateId,
                        IsDisable = A.Award.SubCategory.IsDisable,
                        #region Category
                        Category = new BOCategory()
                        {
                            CateId = A.Award.SubCategory.Category.CateId,
                            Category1 = A.Award.SubCategory.Category.Category1
                        }
                        #endregion
                    },
                    #endregion
               
                    AwdId = A.Award.AwdId,
                    SubCateId = A.Award.SubCateId,
                    AwardName = A.Award.AwardName,
                    ShortDescription = A.Award.ShortDescription,
                    LongDescription = A.Award.LongDescription,
                    StartDate = A.Award.StartDate,
                    EndDate = A.Award.EndDate,
                    DateCreated = A.Award.DateCreated,
                    IsDisable = A.Award.IsDisable,
                    #region UserRole
                    UserRoles = A.Award.UserRoles.Select(
                        x => new BOUserRole
                        {
                            RoleId = x.RoleId,
                            AwardId = x.AwardId,
                            Role = new BORole
                            {
                                RoleId = x.Role.RoleId,
                                Role1 = x.Role.Role1
                            },
                            UserId = x.UserId
                        }).ToList(),
                    #endregion
                },
                #endregion
                #region applicationDetail
                ApplicationDetails = A.ApplicationDetails.Select(y => new BOApplicationDetail
                {
                    Answer = y.Answer,
                    AppId = y.AppId,
                    QueId = y.QueId,
                    Question = new BOQuestion
                    {
                        Question1 = y.Question.Question1,
                        QueId = y.Question.QueId,
                        IsDisable = y.Question.IsDisable
                    }
                }).ToList(),
                #endregion
                #region User
                User = new BOUser()
                {
                        Designation = A.User.Designation,
                        DOB = A.User.DOB,
                        DOJ = A.User.DOJ,
                        Email = A.User.Email,
                        Gender = A.User.Gender,
                        Image = A.User.Image,
                        IsActive = A.User.IsActive,
                        IsDisable = A.User.IsDisable,
                        Mobile = A.User.Mobile,
                        Name = A.User.Name,
                        UserId = A.User.UserId,   
                },
                #endregion
                #region UserRating
                UserRatings = A.UserRatings.Select(y => new BOUserRating
                {
                    AppId = y.AppId,
                    Rating = y.Rating,
                    Reason = y.Reason,
                    UserId = y.UserId,
                    User = new BOUser()
                    {
                        Designation = y.User.Designation,
                        DOB = y.User.DOB,
                        DOJ = y.User.DOJ,
                        Email = y.User.Email,
                        Gender = y.User.Gender,
                        Image = y.User.Image,
                        IsActive = y.User.IsActive,
                        IsDisable = y.User.IsDisable,
                        Mobile = y.User.Mobile,
                        Name = y.User.Name,
                        UserId = y.User.UserId,
                    }

                }).ToList(),
                #endregion
                isRejected = A.isRejected
            }).Where(a => a.Stage == stage).ToList();
        }
        public BOApplication GetApplication(Guid id)
        {
            return AwardDBEntities.Applications.Select(A => new BOApplication
            {
                AppId = A.AppId,
                AppliedDate = A.AppliedDate,
                Stage = A.Stage,
                AwdId = A.AwdId,
                UserId = A.UserId,
                Award = new BOAward()
                {
                    AwdId = A.Award.AwdId,
                    SubCateId = A.Award.SubCateId,
                    AwardName = A.Award.AwardName,
                    ShortDescription = A.Award.ShortDescription,
                    LongDescription = A.Award.LongDescription,
                    StartDate = A.Award.StartDate,
                    EndDate = A.Award.EndDate,
                    DateCreated = A.Award.DateCreated,
                    IsDisable = A.Award.IsDisable,
                    
                    UserRoles = A.Award.UserRoles.Select(x => new BOUserRole
                    {
                        RoleId = x.RoleId,
                        AwardId=x.AwardId,
                        UserId=x.UserId,
                    }).ToList()
                },
                ApplicationDetails = A.ApplicationDetails.Select(y => new BOApplicationDetail
                {
                    Answer = y.Answer,
                    AppId = y.AppId,
                    QueId = y.QueId,
                    Question = new BOQuestion
                    {
                        Question1 = y.Question.Question1,
                        QueId = y.Question.QueId,
                        IsDisable = y.Question.IsDisable
                    }
                }).ToList(),
                User = new BOUser()
                {
                    Designation = A.User.Designation,
                    DOB = A.User.DOB,
                    DOJ = A.User.DOJ,
                    Email = A.User.Email,
                    Gender = A.User.Gender,
                    Image = A.User.Image,
                    IsActive = A.User.IsActive,
                    IsDisable = A.User.IsDisable,
                    Mobile = A.User.Mobile,
                    Name = A.User.Name,

                    UserId = A.User.UserId,
                },
                UserRatings = A.UserRatings.Select(y => new BOUserRating
                {
                    AppId = y.AppId,
                    Rating = y.Rating,
                    Reason = y.Reason,
                    UserId = y.UserId,
                    User = new BOUser()
                    {
                        Designation = y.User.Designation,
                        DOB = y.User.DOB,
                        DOJ = y.User.DOJ,
                        Email = y.User.Email,
                        Gender = y.User.Gender,
                        Image = y.User.Image,
                        IsActive = y.User.IsActive,
                        IsDisable = y.User.IsDisable,
                        Mobile = y.User.Mobile,
                        Name = y.User.Name,
                        UserId = y.User.UserId,
                    }

                }).ToList(),
                isRejected = A.isRejected
            }).Where(a => a.AppId == id).Single();
        }

        public BOApplication InsertApplication(BOApplication BOApplication)
        {
            Application App = new Application()
            {
                AppId = Guid.NewGuid(),
                AppliedDate = BOApplication.AppliedDate,
                Stage = BOApplication.Stage,
                AwdId = BOApplication.AwdId,
                UserId = BOApplication.UserId,
                isRejected = false
            };
            BOApplication.AppId = App.AppId;
            AwardDBEntities.Applications.Add(App);
            return BOApplication;
        }

        public void UpdateApplication(BOApplication BOApplication)
        {
            // This Update Method Access by only Admin and Admin can change only Stage part

            Application App = new Application()
            {
                AppId = BOApplication.AppId,
                AppliedDate = BOApplication.AppliedDate,
                Stage = BOApplication.Stage,
                AwdId = BOApplication.AwdId,
                UserId = BOApplication.UserId,
                isRejected = BOApplication.isRejected
            };
            AwardDBEntities.Entry(App).State = EntityState.Modified;
        }
    }
}
