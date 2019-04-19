using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.UI.Areas.Member.Controllers
{
    public class MemberHomeController : BaseController
    {
        // GET: Member/MemberHome
        public ActionResult MemberHomeIndex()
        {
            if (User.Identity.IsAuthenticated)
            {
                IEnumerable<Article> articles = service.ArticleService.GetActive().Take(5);
                return View(articles);

            }return Redirect("/Account/Login");
            
        }
    }
}