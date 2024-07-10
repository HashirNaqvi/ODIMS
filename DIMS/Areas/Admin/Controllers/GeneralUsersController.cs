using DIMS.BAL.Classes;
using DIMS.BAL;
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
    public class GeneralUsersController : Controller
    {
        // GET: GeneralUser
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult LstGeneralUsers()
        {
            var model = GeneralUserBAL.GetAllGeneralUsers();
            return View(model);
        }
        public ActionResult GeneralUsers(int GeneralUserID = 0)
        {
            if (GeneralUserID > 0)
            {
                var model = GeneralUserBAL.GetGeneralUserByID(GeneralUserID);
                return View(model);
            }
            else
            {
                var model = new DIMS.BAL.EF.GeneralUser() { /*NDMAUserID = 213;*/ };
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult AuthenticateLogin(DIMS.BAL.EF.GeneralUser generalUser)
        {
            var I = GeneralUserBAL.AuthenticateGeneralUser(generalUser);
            if (I != null)
            {
                CookieManager.SetCookie(SiteConstants.GeneralUserID, I.GeneralUserID.ToString());
                CookieManager.SetCookie(SiteConstants.GeneralUserName, I.UserName.ToString());
                CookieManager.SetCookie(SiteConstants.UserType, ((int)UserType.General).ToString());

                return Redirect("Admin/PublicMessages/LstPublicMessages");
            }

            return View("Login");
        }
        [HttpPost]
        public ActionResult SaveGeneralUser(DIMS.BAL.EF.GeneralUser generalUser)
        {
            if (generalUser.GeneralUserID > 0)
            {
                GeneralUserBAL.UpdateGeneralUser(generalUser);
                return RedirectToAction("LstGeneralUsers", "GeneralUsers");
            }
            else
            {
                try
                {
                    GeneralUserBAL.AddGeneralUser(generalUser);
                    ViewBag.IsSuccess = true;
                }
                catch (Exception e) { 
                    ViewBag.IsSuccess = false;

                }
            }
            return View("Register");
        }
        public ActionResult DeleteGeneralUsers(int GeneralUserID)
        {
            GeneralUserBAL.DeleteGeneralUser(GeneralUserID);
            return Redirect("LstGeneralUsers");
        }
    }
}