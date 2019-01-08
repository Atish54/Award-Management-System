using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwardManagment.Data.Core;

namespace AwardManagment.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AwardDBEntities _awardDBEntities;

        public UnitOfWork(AwardDBEntities awardDBEntities)
        {
            this._awardDBEntities = awardDBEntities;
            CategoryRepository = new CategoryRepository(_awardDBEntities);
            SubCategoryRepository = new SubCategoryRepository(_awardDBEntities);
            QuestionRepository = new QuestionRepository(_awardDBEntities);
            UserRepositories = new UserRepository(_awardDBEntities);
            UserRoleRepositories = new UserRoleRepository(_awardDBEntities);
            ApplicationRepository = new ApplicationRepository(_awardDBEntities);
            NewsRepository = new NewsRepository(_awardDBEntities);
            AwardRepository = new AwardRepository(_awardDBEntities);
            NotificationRepository = new NotificationRepository(_awardDBEntities);
            RoleRepositories = new RoleRepository(_awardDBEntities);
            AwardQuestionsRepository = new AwardQuestionsRepository(_awardDBEntities);
            ApplicationDetailRepository = new ApplicationDetailRepository(_awardDBEntities);
            UserRatingRepository = new UserRatingRepository(_awardDBEntities);
        }

        public ICategoryRepository CategoryRepository { get; private set; }
        //public object Question { get; set; }
        public IQuestionRepository QuestionRepository { get; private set; }
        public IUserRoleRepository UserRoleRepositories { get; private set; }
        public IUserRepository UserRepositories { get; private set; }
        public ISubCategoryRepository SubCategoryRepository { get; private set; }
        public INewsRepository NewsRepository { get; private set; }
       public  IUserRatingRepository UserRatingRepository { get; private set; }
        public INotificationRepository NotificationRepository { get; private set; }
        public IApplicationRepository ApplicationRepository { get; private set; }
        public IRoleRepository RoleRepositories { private set; get; }
        public IAwardQuestionsRepository AwardQuestionsRepository { private set; get; }

        public IAwardRepository AwardRepository { get; private set; }

        public IApplicationDetailRepository ApplicationDetailRepository { get; private set; }
        public int Complete()
        {
            return _awardDBEntities.SaveChanges();
        }
        public void Dispose()
        {
            _awardDBEntities.Dispose();
        }
    }
}
