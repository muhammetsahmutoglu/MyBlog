using MyBlog.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.UI.Areas.Member.Controllers
{
    public class MemberArticleController : BaseController
    {
        // GET: Member/MemberArticle
        public ActionResult Show()
        {
            if (User.Identity.IsAuthenticated)
            {
                service.ArticleService.GetActive().Take(5);
                return View(service);

            }
            return View("/Account/Login");
                                                               

        }
    }
}