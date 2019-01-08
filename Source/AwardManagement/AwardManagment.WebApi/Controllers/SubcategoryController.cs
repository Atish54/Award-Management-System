using System;
using System.Collections.Generic;
using System.Web.Http;
using AwardManagment.Data;
using AwardManagment.Data.Repository;
using AwardManagment.BusinessObjects.Model;


namespace AwardManagment.WebApi.Controllers
{
    public class SubcategoryController : ApiController
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork(new AwardDBEntities());

        public IEnumerable<BOSubCategory> GetSubCategories()
        {
                return _UnitOfWork.SubCategoryRepository.GetAllSubCategories();
        }

        public BOSubCategory GetSubcategory(Guid id)
        {
            return _UnitOfWork.SubCategoryRepository.GetSubCategory(id);
        }

        public bool PostSubCategory(BOSubCategory _BOSubCategory)
        {
            try
            {
                _UnitOfWork.SubCategoryRepository.InsertSubCategory(_BOSubCategory);
                _UnitOfWork.Complete();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { _UnitOfWork.Dispose(); }
            return false;
        }

        public bool PutSubcategory(BOSubCategory _BOSubCategory)
        {
            try
            {
                _UnitOfWork.SubCategoryRepository.UpdateSubCategory(_BOSubCategory);
                _UnitOfWork.Complete();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { _UnitOfWork.Dispose(); }
            return false;
        }

        public bool DeleteCategory(Guid id)
        {
            try
            {
                _UnitOfWork.SubCategoryRepository.RemoveSubCategory(id);
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
    }
}