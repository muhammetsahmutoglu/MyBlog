using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.UI.Areas.Member.Controllers
{
    public class MemberHomeController : Controller
    {
        // GET: Member/MemberHome
        public ActionResult MemberHomeIndex()
        {
            return View();
        }
    }
}