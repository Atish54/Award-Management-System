using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwardManagment.Data.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }

        IQuestionRepository QuestionRepository { get; }
        IUserRatingRepository UserRatingRepository { get; }
        ISubCategoryRepository SubCategoryRepository { get; }

        IUserRepository UserRepositories { get; }

        IUserRoleRepository UserRoleRepositories { get; }

        IRoleRepository RoleRepositories { get; }

        INewsRepository NewsRepository { get; }

        IApplicationRepository ApplicationRepository { get; }

        INotificationRepository NotificationRepository { get; }
        IApplicationDetailRepository ApplicationDetailRepository { get; }
        IAwardQuestionsRepository AwardQuestionsRepository { get; }

        int Complete();
    }
}
