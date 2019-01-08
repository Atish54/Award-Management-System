using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AwardManagment.Data;
using AwardManagment.Data.Repository;
using AwardManagment.BusinessObjects.Model;


namespace AwardManagment.WebApi.Controllers
{
    public class ApplicationController : ApiController
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork(new AwardDBEntities());

        public IEnumerable<BOApplication> GetApplications()
        {
            return _UnitOfWork.ApplicationRepository.GetAppApplications();
        }

        public BOApplication GetApplication(Guid id)
        {
            return _UnitOfWork.ApplicationRepository.GetApplication(id);
        }
        [HttpPost]
        public bool PostApplication(BOApplicationQuestions _BOApplication)
        {
            BOApplication application=new BOApplication();
            BOApplicationDetail applicationDetail = new BOApplicationDetail();
            try
            {

                application.AppliedDate = _BOApplication.AppliedDate;
                application.AwdId = _BOApplication.AwdId;
                application.Stage = _BOApplication.Stage;
                application.isRejected = _BOApplication.isRejected;
                application.UserId = _BOApplication.UserId;
                application=_UnitOfWork.ApplicationRepository.InsertApplication(application);
                _UnitOfWork.Complete();
                foreach(var v in _BOApplication.QuestionAnswer)
                {
                    applicationDetail.AppId = application.AppId;
                    applicationDetail.QueId = v.QueId;
                    applicationDetail.Answer = v.Answer;
                    _UnitOfWork.ApplicationDetailRepository.InsertApplication(applicationDetail);
                }
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
        
        public bool PutApplication(BOApplicationRating br)
        {
            try
            {

                _UnitOfWork.ApplicationRepository.UpdateApplication(br.Application);
                _UnitOfWork.Complete();
                if (br.Rating != null)
                {
                    BOUserRating b = new BOUserRating();
                    b.AppId = br.Application.AppId;
                    b.Rating = br.Rating.rating;
                    b.UserId = br.Rating.UserId;
                    b.Reason = br.Rating.Reason;
                    _UnitOfWork.UserRatingRepository.AddUserRating(b);
                    _UnitOfWork.Complete();
                        
                }
             
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
