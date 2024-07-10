using DIMS.BAL.Classes;
using DIMS.BAL.Extentions;
using DIMS.BAL;
using DIMS.BAL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIMS.Areas.RehabilitationInstitutes.Controllers
{
    public class AccountController : Controller
    {
        // GET: RehabilitationInstitutes/Account
        public ActionResult Login()
        {
            var userType = CookieManager.GetCookie(DIMS.BAL.SiteConstants.UserType);
            if (userType == "2")
            {
                return RedirectToAction("LstDisasterInformation", "DisasterInformation");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AuthenticateLogin(DIMS.BAL.EF.RehabilitationInstitutes rehabInstitutes)
        {
            var I = RehabInstituteBAL.AuthenticateInstitute(rehabInstitutes);
            if (I != null)
            {
                CookieManager.SetCookie(SiteConstants.RehabInstituteID, I.RehabilitationInstituteID.ToString());
                CookieManager.SetCookie(SiteConstants.RehabInstituteName, I.InstituteName.ToString());
                CookieManager.SetCookie(SiteConstants.UserType, ((int)UserType.RehabInstitute).ToString());

                return RedirectToAction("LstDisasterInformation", "DisasterInformation");
            }

            return View("Login");
        }

        public ActionResult Logout()
        {
            CookieManager.ClearCookies();
            return Redirect("Login");
        }
    }
}