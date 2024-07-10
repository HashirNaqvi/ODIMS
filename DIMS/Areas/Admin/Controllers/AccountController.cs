using DIMS.BAL;
using DIMS.BAL.Classes;
using DIMS.BAL.Extentions;
using DIMS.BAL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIMS.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: RehabilitationInstitutes/Account
        public ActionResult Login()
        {
            var userType = CookieManager.GetCookie(DIMS.BAL.SiteConstants.UserType);
            if (userType == "1")
            {
                return RedirectToAction("LstRehabilitationInstitutes", "RehabilitationInstitutes");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AuthenticateLogin(DIMS.BAL.EF.NDMAUser ndma)
        {
            var I = NDMABAL.AuthenticateNDMA(ndma);
            if (I != null)
            {
                CookieManager.SetCookie(SiteConstants.NDMAUserID, I.NDMAUserID.ToString());
                CookieManager.SetCookie(SiteConstants.NDMAUserName, I.FirstName.ToString());
                CookieManager.SetCookie(SiteConstants.UserType, ((int)UserType.NDMA).ToString());

                return RedirectToAction("LstRehabilitationInstitutes", "RehabilitationInstitutes");
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