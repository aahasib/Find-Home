using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Net.Mail;
using System.Net;
using System.Web.Security;
using System.Data.SqlClient;


namespace WebApplication1.Controllers
{
    public class DeveloperLoginController : Controller
    {
        public ActionResult DeveloperLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeveloperLogin(DEVELOPER objUser)
        {
            if (ModelState.IsValid)
            {
                using (DBmodelEntities db = new DBmodelEntities())
                {
                    var obj = db.DEVELOPERS.Where(a => a.DeveloperEmail.Equals(objUser.DeveloperEmail) && a.DeveloperPass.Equals(objUser.DeveloperPass)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["DeveloperEmail"] = objUser.DeveloperEmail.ToString();
                         //< a  href="~/DeveloperLogin/DeveloperLogin">Developer Login</a>
                        return RedirectToAction("DeveloperLogin", "DeveloperLogin");
                    }
                }
            }
            return View(objUser);
        }

        
    }
}