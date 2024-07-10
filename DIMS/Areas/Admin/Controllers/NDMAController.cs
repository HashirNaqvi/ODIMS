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
    public class NDMAController : Controller
    {
        public ActionResult NewNDMAUser()
        {
            var model = new DIMS.BAL.EF.NDMAUser() {  };
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveNDMA(DIMS.BAL.EF.NDMAUser ndma)
        {

            if (ndma.NDMAUserID > 0)
            {
                NDMABAL.UpdateNDMA(ndma);
            }
            else
            {
                NDMABAL.AddNDMA(ndma);
            }
            return RedirectToAction("LstRehabilitationInstitutes", "RehabilitationInstitutes");
        }
    }
}