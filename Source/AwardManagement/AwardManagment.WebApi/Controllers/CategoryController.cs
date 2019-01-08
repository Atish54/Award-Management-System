using System;
using System.Collections.Generic;
using System.Web.Http;
using AwardManagment.Data;
using AwardManagment.BusinessObjects.Model;
using AwardManagment.Data.Repository;
namespace AwardManagment.WebApi.Controllers
{
    public class CategoryController : ApiController
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork(new AwardDBEntities());
        public IEnumerable<BOCategory> GetCategories()
        {
            return _UnitOfWork.CategoryRepository.GetAllCategories();
        }
        public BOCategory GetCategory(Guid id)
        {
            return _UnitOfWork.CategoryRepository.GetCategory(id);
        }
        public bool PostCategory(BOCategory _BOCategory)
        {
            try
            {
                _UnitOfWork.CategoryRepository.InsertCategory(_BOCategory);
                _UnitOfWork.Complete();
                return true;
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
            finally { _UnitOfWork.Dispose(); }
            return false;
        }
        public bool PutCategory(BOCategory _BOCategory)
        {
            try
            {
                _UnitOfWork.CategoryRepository.UpcateCategory(_BOCategory);
                _UnitOfWork.Complete();
                return true;
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
            finally { _UnitOfWork.Dispose(); }
            return false;
        }
        public bool DeleteCategory(Guid id)
        {
            try
            {
                _UnitOfWork.CategoryRepository.RemoveCategory(id);
                _UnitOfWork.Complete();
                return true;
            }
            catch (Exception e)Z
            {
                Console.Write(e.ToString());
            }
            finally { _UnitOfWork.Dispose(); }
            return false;
        }
    }
}