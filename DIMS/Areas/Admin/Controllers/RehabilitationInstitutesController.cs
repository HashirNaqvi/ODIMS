using DIMS.BAL.EF;
using DIMS.BAL.Extentions;
using DIMS.BAL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIMS.Areas.Admin.Controllers
{
    public class RehabilitationInstitutesController : Controller
    {
        // GET: Admin/RehabilitationInstitutes
        public ActionResult LstRehabilitationInstitutes()
        {
            var model = RehabInstituteBAL.GetAllInstitutes();
            return View(model);
        }

        public ActionResult RehabilitationInstitute(int RehabilitationInstituteID = 0)
        {
            if (RehabilitationInstituteID > 0)
            {
                var model = RehabInstituteBAL.GetInstituteByID(RehabilitationInstituteID);
                return View(model);
            }
            else
            {
                var model = new DIMS.BAL.EF.RehabilitationInstitutes() { /*NDMAUserID = 213;*/ };
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult SaveRehabilitationInstitute(DIMS.BAL.EF.RehabilitationInstitutes rehabInstitutes)
        {
            var userType = CookieManager.GetCookie(DIMS.BAL.SiteConstants.UserType);
            if (rehabInstitutes.RehabilitationInstituteID > 0)
            {
                RehabInstituteBAL.UpdateInstitute(rehabInstitutes);
            }
            else
            {
                if (userType == "1")
                {
                    rehabInstitutes.NDMAUserID = Convert.ToInt32(CookieManager.GetCookie(DIMS.BAL.SiteConstants.NDMAUserID));
                }
                RehabInstituteBAL.AddInstitute(rehabInstitutes);
            }
            if (userType == "1")
            {
                return RedirectToAction("LstRehabilitationInstitutes", "RehabilitationInstitutes");
            }
            else { 
                return Redirect("/");
            }
        }

        public ActionResult DeleteRehabilitationInstitutes(int RehabilitationInstituteID)
        {
            RehabInstituteBAL.DeleteRehabilitationInstitutes(RehabilitationInstituteID);
            return Redirect("LstRehabilitationInstitutes");
        }
    }
}