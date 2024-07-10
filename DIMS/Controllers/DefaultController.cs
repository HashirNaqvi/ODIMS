using DIMS.BAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIMS.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RehabilitationInstitute()
        {
            var model = new RehabilitationInstitutes();
            return View(model);
        }
    }
}