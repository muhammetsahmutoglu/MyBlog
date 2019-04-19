using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Author.Models.DTO;
using MyBlog.UI.Areas.Author.Models.VM;
using MyBlog.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.UI.Areas.Author.Controllers
{
    public class AuthorArticleController : BaseController
    {
        // GET: Admin/Article
        public ActionResult Add()
        {
            if (User.Identity.IsAuthenticated)
            {
                AuthorArticleVM model = new AuthorArticleVM()
                {
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
                AppUser appUser = service.AppUserService.FindByUserName(HttpContext.User.Identity.Name);
                data.AppUserID = appUser.ID;
                data.PublishDate = DateTime.Now;
                service.ArticleService.Add(data);
                return Redirect("/Author/AuthorArticle/List");
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
                AuthorArticleVM model = new AuthorArticleVM();
                model.article.ID = article.ID;
                model.article.Header = article.Header;
                model.article.Content = article.Content;
                model.article.CategoryID = article.CategoryID;
                model.article.SubTitle = article.SubTitle;
                model.article.PublishDate = article.PublishDate;
                List<Category> categories = service.CategoryService.GetActive();
                model.Categories = categories;                      
                return View(model);

            }
            return Redirect("/Account/Login");

        }

        [HttpPost]
        public ActionResult Update(AuthorArticleDTO data)
        {
            if (User.Identity.IsAuthenticated)
            {
                Article article = service.ArticleService.GetById(data.ID);
                article.Header = data.Header;
                article.Content = data.Content;
                article.PublishDate = data.PublishDate;
                service.ArticleService.Update(article);
                return Redirect("/Author/AuthorArticle/List");

            }
            return Redirect("/Account/Login");

        }

        public ActionResult Delete(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                service.ArticleService.Remove(id);
                return Redirect("/Author/AuthorArticle/List");

            }
            return Redirect("/Account/Login");

        }
    }
}