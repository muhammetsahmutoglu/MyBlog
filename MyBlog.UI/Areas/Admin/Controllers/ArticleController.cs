using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Admin.Models.DTO;
using MyBlog.UI.Areas.Admin.Models.VM;
using MyBlog.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    public class ArticleController : BaseController
    {
        // GET: Admin/Article
        public ActionResult Add()
        {
            if (User.Identity.IsAuthenticated)
            {
                AddArticleVM model = new AddArticleVM()
                {
                    AppUsers = service.AppUserService.GetActive(),
                    Categories = service.CategoryService.GetActive()
                };
                return View(model);
                
            }
            return Redirect("/Account/Login");

        }
        [HttpPost]
        public ActionResult Add(Article data)
        {
            if (User.Identity.IsAuthenticated)
            {
                service.ArticleService.Add(data);
                return Redirect("/Admin/Article/List");

            }
            return Redirect("/Account/Login");


        }

        public ActionResult List()
        {
            if (User.Identity.IsAuthenticated)
            {
                List<Article> model = service.ArticleService.GetActive();
                return View(model);

            }
            return Redirect("/Account/Login");

        }

        public ActionResult Update(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                Article article = service.ArticleService.GetById(id);
                AddArticleVM model = new AddArticleVM();
                model.Articles.ID = article.ID;
                model.Articles.Content = article.Content;
                model.Articles.Header = article.Header;
                model.Articles.PublishDate = article.PublishDate;
                List<Category> categories = service.CategoryService.GetActive();
                List<AppUser> appUsers = service.AppUserService.GetActive();
                model.Categories = categories;
                model.AppUsers = appUsers;

                return View(model);

            }
            return Redirect("/Account/Login");

        }

        [HttpPost]
        public ActionResult Update(ArticleDTO data)
        {
            if (User.Identity.IsAuthenticated)
            {
                Article article = service.ArticleService.GetById(data.ID);
                article.Header = data.Header;
                article.Content = data.Content;
                article.PublishDate = data.PublishDate;
                service.ArticleService.Update(article);
                return Redirect("/Admin/Article/List");

            }
            return Redirect("/Account/Login");

        }

        public ActionResult Delete(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                service.ArticleService.Remove(id);
                return Redirect("/Admin/Article/List");

            }
            return Redirect("/Account/Login");

        }
    }
}