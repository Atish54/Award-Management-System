using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AwardManagment.BusinessObjects.Model;
using AwardManagment.Data.Repository;

namespace AwardManagment.WebApi.Controllers
{
    public class UserRoleController : ApiController
    {
        private UnitOfWork _UnitOfWorks = new UnitOfWork(new Data.AwardDBEntities());
        // GET: api/UserRole
        public IEnumerable<BOUserRole> Get()
        {
            return _UnitOfWorks.UserRoleRepositories.GetAllUser();
        }

        // GET: api/UserRole/5
        public BORole Get(Guid id)
        {
            return _UnitOfWorks.UserRoleRepositories.GetRole(id);
        }

        // POST: api/UserRole
        public bool Post(BOUserRole ur)
        {
            
            try
            {
                _UnitOfWorks.UserRoleRepositories.AssignRole(ur);
                _UnitOfWorks.Complete();
                return true;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;
            }
            finally {
                _UnitOfWorks.Dispose();
            }
        }

      
        // DELETE: api/UserRole/5
        public bool Delete(BOUserRole ur)
        {
            try
            {
                _UnitOfWorks.UserRoleRepositories.RemoveUserRole(ur.UserId,ur.RoleId);
                _UnitOfWorks.Complete();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                _UnitOfWorks.Dispose();
            }
        }
    }
}
