using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Member.Models.VM;
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
        public ActionResult Show(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                MemberArticleCommentVM model = new MemberArticleCommentVM()
                {

                    Articles = service.ArticleService.GetActive(),

                    AppUsers = service.AppUserService.GetActive(),

                    Comments = service.CommentService.GetDefault(x => x.ArticleID == id).OrderByDescending(x => x.AddDate).Take(10),

                    

                };
                return View(model);
            }
            return View("/Account/Login");
                                                               

        }
        public ActionResult AddComment(MemberCommentVM data)
        {
            if (User.Identity.IsAuthenticated)
            {
                Comment comment = new Comment();
                comment.AppUserID = service.AppUserService.FindByUserName(HttpContext.User.Identity.Name).ID;
                comment.ArticleID = data.ID;
                comment.Content = data.Content;
                comment.AddDate = DateTime.Now;
                service.CommentService.Add(comment);
                return Redirect("/Member/MemberArticle/Show/" + data.ID);

            }
            return View("/Account/Login");


        }
    }
}