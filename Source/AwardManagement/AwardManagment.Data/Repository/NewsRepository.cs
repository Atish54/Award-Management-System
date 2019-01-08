using AwardManagment.BusinessObjects.Model;
using AwardManagment.Data.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwardManagment.Data.Repository
{
    public class NewsRepository : Repository<BONews>, INewsRepository
    {
        public NewsRepository(AwardDBEntities context)
            : base(context)
        {
        }
        public AwardDBEntities AwardDBEntities { get { return Context as AwardDBEntities; } }
        public IEnumerable<BONews> GetAllNews()
        {
            return AwardDBEntities.News.Select(t => new BONews
            {
                NewsId = t.NewsId,
                News1 = t.news1,

                IsDisable = t.IsDisable
            });
        }
        public BONews GetNews(Guid id)
        {
            var news = AwardDBEntities.News.Select(t => new BONews
            {
                NewsId = t.NewsId,
                News1 = t.news1,
                IsDisable = t.IsDisable,
            }).Where(t => t.NewsId == id).First();
            return news;
        }
        public void InsertNews(BONews news)
        {
            News ne=new News()
            {
                NewsId = Guid.NewGuid(),
                news1 = news.News1,
                IsDisable = false,
            };
            AwardDBEntities.News.Add(ne);
        }
        public void RemoveNews(Guid id)
        {
            var temp = AwardDBEntities.News.Single(u => u.NewsId == id);
            temp.IsDisable = true;
        }
        public void UpdateNews(BONews news)
        {
            News N = new News()
            {
                NewsId =news.NewsId,
                news1 = news.News1,
                IsDisable = false,
            };  
            AwardDBEntities.Entry(N).State = EntityState.Modified;
        }
    }
}
