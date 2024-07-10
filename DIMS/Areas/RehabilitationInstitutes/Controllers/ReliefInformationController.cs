using DIMS.BAL.EF;
using DIMS.BAL.Extentions;
using DIMS.BAL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIMS.Areas.RehabilitationInstitutes.Controllers
{
    public class ReliefInformationController : Controller
    {
        // GET: RehabilitationInstitutes/ReliefInformation
        public ActionResult LstReliefInformation()
        {
            //var model = BAL.Manager.ReliefInformationBAL.GetAllReliefInformation();
            //return View(model);
            var userType = CookieManager.GetCookie(DIMS.BAL.SiteConstants.UserType);
            if (userType == "1" || userType == "3")
            {
                return View(BAL.Manager.ReliefInformationBAL.GetAllReliefInformation());

            }
            else if (userType == "2")
            {
                var rehabInstituteID = Convert.ToInt32(CookieManager.GetCookie(DIMS.BAL.SiteConstants.RehabInstituteID));
                return View(BAL.Manager.ReliefInformationBAL.GetAllReliefInformationForInstitute(rehabInstituteID));

            }
            return View();
        }

        public ActionResult ReliefInformation(int ReliefInformationID = 0)
        {
            if (ReliefInformationID > 0)
            {
                var model = ReliefInformationBAL.GetReliefInformationByID(ReliefInformationID);
                return View(model);
            }
            else
            {
                var model = new DIMS.BAL.EF.ReliefInformation() { /*NDMAUserID = 213;*/ };
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult SaveReliefInformation(DIMS.BAL.EF.ReliefInformation reliefInformation)
        {
            if (reliefInformation.ReliefInformationID > 0)
            {
                ReliefInformationBAL.UpdateReliefInformation(reliefInformation);
            }
            else
            {
                var userType = CookieManager.GetCookie(DIMS.BAL.SiteConstants.UserType);
                if (userType == "1")
                {
                    reliefInformation.NDMAUserId = Convert.ToInt32(CookieManager.GetCookie(DIMS.BAL.SiteConstants.NDMAUserID));
                }
                else if (userType == "2")
                {
                    reliefInformation.RehabilitationInstituteID = Convert.ToInt32(CookieManager.GetCookie(DIMS.BAL.SiteConstants.RehabInstituteID));
                }
                ReliefInformationBAL.AddReliefInformation(reliefInformation);
            }
            return RedirectToAction("LstReliefInformation", "ReliefInformation");
        }
        public ActionResult ViewReliefInformation(int ReliefInformationID)
        {
            var model = ReliefInformationBAL.GetReliefInformationByID(ReliefInformationID);
            return View(model);
        }
        public ActionResult DeleteReliefInformation(int ReliefInformationID)
        {
            ReliefInformationBAL.DeleteReliefInformation(ReliefInformationID);
            return Redirect("LstReliefInformation");
        }
    }
}