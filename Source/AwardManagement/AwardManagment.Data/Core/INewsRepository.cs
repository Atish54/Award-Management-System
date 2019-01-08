using AwardManagment.BusinessObjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwardManagment.Data.Core
{
    public interface INewsRepository:IRepository<BONews>
    {
        IEnumerable<BONews> GetAllNews();
        BONews GetNews(Guid id);

        void InsertNews(BONews news);

        void RemoveNews(Guid id);

        void UpdateNews(BONews news);
    }
}
