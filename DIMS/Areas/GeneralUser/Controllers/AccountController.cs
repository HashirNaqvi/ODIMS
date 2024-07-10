using DIMS.BAL;
using DIMS.BAL.Classes;
using DIMS.BAL.Extentions;
using DIMS.BAL.Manager;
using System.Web.Mvc;

namespace DIMS.Areas.GeneralUser.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            var userType = CookieManager.GetCookie(DIMS.BAL.SiteConstants.UserType);
            if (userType == "3")
            {
                return RedirectToAction("LstPublicMessages", "PublicMessages", new { area = "Admin" });
            }

            return View();
        }

        [HttpPost]
        public ActionResult AuthenticateLogin(DIMS.BAL.EF.GeneralUser generalUser)
        {
            var I = GeneralUserBAL.AuthenticateGeneralUser(generalUser);
            if (I != null)
            {
                CookieManager.SetCookie(SiteConstants.GeneralUserID, I.NDMAUserID.ToString());
                CookieManager.SetCookie(SiteConstants.GeneralUserName, I.UserName.ToString());
                CookieManager.SetCookie(SiteConstants.UserType, ((int)UserType.General).ToString());

                return RedirectToAction("LstPublicMessages", "PublicMessages", new { area = "Admin" } );
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