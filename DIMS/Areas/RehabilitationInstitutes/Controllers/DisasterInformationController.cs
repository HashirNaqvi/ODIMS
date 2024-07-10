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
    public class DisasterInformationController : Controller
    {
        // GET: RehabilitationInstitutes/DisasterInformation
        public ActionResult LstDisasterInformation()
        {
            var userType = CookieManager.GetCookie(DIMS.BAL.SiteConstants.UserType);
            if (userType == "1" || userType == "3")
            {
                return View(BAL.Manager.DisasterInformationBAL.GetAllDisasterInformation());

            }
            else if (userType == "2")
            {
                var rehabInstituteID = Convert.ToInt32(CookieManager.GetCookie(DIMS.BAL.SiteConstants.RehabInstituteID));
                return View(BAL.Manager.DisasterInformationBAL.GetAllDisasterInformationForInstitute(rehabInstituteID));

            }
            return View();
        }

        public ActionResult DisasterInformation(int DisasterInformationID = 0)
        {
            if (DisasterInformationID > 0)
            {
                var model = DisasterInformationBAL.GetDisasterInformationByID(DisasterInformationID);
                return View(model);
            }
            else
            {
                var model = new DIMS.BAL.EF.DisasterInformation() { /*NDMAUserID = 213;*/ };
                return View(model);
            }
        }

        public ActionResult ViewDisasterInformation(int DisasterInformationID)
        {
            var model = DisasterInformationBAL.GetDisasterInformationByID(DisasterInformationID);
            return View(model);
        }

        public ActionResult DeleteDisasterInformation(int DisasterInformationID)
        {
            DisasterInformationBAL.DeleteDisasterInformation(DisasterInformationID);
            return Redirect("LstDisasterInformation");
        }


        [HttpPost]
        public ActionResult SaveDisasterInformation(DIMS.BAL.EF.DisasterInformation disasterInformation)
        {
            if (disasterInformation.DisasterInformationID > 0)
            {
                DisasterInformationBAL.UpdateDisasterInformation(disasterInformation);
            }
            else
            {
                var userType = CookieManager.GetCookie(DIMS.BAL.SiteConstants.UserType);
                if (userType == "1")
                {
                    disasterInformation.NDMAUserId = Convert.ToInt32(CookieManager.GetCookie(DIMS.BAL.SiteConstants.NDMAUserID));
                }
                else if (userType == "2")
                {
                    disasterInformation.RehabilitationInstituteID = Convert.ToInt32(CookieManager.GetCookie(DIMS.BAL.SiteConstants.RehabInstituteID));
                }
                DisasterInformationBAL.AddDisasterInformation(disasterInformation);
            }
            return RedirectToAction("LstDisasterInformation", "DisasterInformation");
        }
    }
}