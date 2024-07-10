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
    public class PublicMessagesController : Controller
    {
        // GET: Admin/PublicMessages
        public ActionResult LstPublicMessages()
        {
            var userType = CookieManager.GetCookie(DIMS.BAL.SiteConstants.UserType);
            if (userType == "1" || userType == "3")
            {
                return View(PublicMessageBAL.GetPublicMessage());

            }
            else if (userType == "2")
            {
                var rehabInstituteID = Convert.ToInt32(CookieManager.GetCookie(DIMS.BAL.SiteConstants.RehabInstituteID));
                return View(BAL.Manager.PublicMessageBAL.GetPublicMessageByInstituteID(rehabInstituteID));

            }
            return View();
        }

        public ActionResult PublicMessage(int PublicMessageID = 0)
        {
            if (PublicMessageID > 0)
            {
                var model = PublicMessageBAL.GetPublicMessageByID(PublicMessageID);
                return View(model);
            }
            else
            {
                var model = new DIMS.BAL.EF.PublicMessage() { /*NDMAUserID = 213;*/ };
                return View(model);
            }
        }
        public ActionResult ViewPublicMessage(int PublicMessageID)
        {
            var model = PublicMessageBAL.GetPublicMessageByID(PublicMessageID);
            return View(model);
        }
        public ActionResult DeletePublicMessage(int PublicMessageID)
        {
            PublicMessageBAL.DeletePublicMessage(PublicMessageID);
            return Redirect("LstPublicMessages");
        }

        [HttpPost]
        public ActionResult SavePublicMessage(DIMS.BAL.EF.PublicMessage publicMessage, bool delete = false)
        {
            if (delete)
            {
                if (publicMessage.PublicMessageID > 0)
                {
                    PublicMessageBAL.DeletePublicMessage(publicMessage.PublicMessageID);
                    return RedirectToAction("LstPublicMessages", "PublicMessages");
                }
                else
                {
                    // Handle error - trying to delete a message that doesn't exist
                    ModelState.AddModelError("", "Cannot delete a message that doesn't exist.");
                    return View("PublicMessage", publicMessage);
                }
            }

            if (publicMessage.PublicMessageID > 0)
            {
                PublicMessageBAL.UpdatePublicMessage(publicMessage);
            }
            else
            {
                var userType = CookieManager.GetCookie(DIMS.BAL.SiteConstants.UserType);
                if (userType == "1")
                {
                    publicMessage.NDMAUserID = Convert.ToInt32(CookieManager.GetCookie(DIMS.BAL.SiteConstants.NDMAUserID));
                }
                else if (userType == "2")
                {
                    publicMessage.RehabilitationInstituteID = Convert.ToInt32(CookieManager.GetCookie(DIMS.BAL.SiteConstants.RehabInstituteID));
                }

                PublicMessageBAL.AddPublicMessage(publicMessage);
            }
            return RedirectToAction("LstPublicMessages", "PublicMessages");
        }

    }
}