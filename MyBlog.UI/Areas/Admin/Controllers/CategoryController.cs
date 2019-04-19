using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Admin.Models.DTO;
using MyBlog.UI.Areas.Admin.Models.DTO.UserDTO;
using MyBlog.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    public class CategoryController:BaseController
    {
        public ActionResult Add()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();

            }
            return Redirect("/Account/Login");
            
        }

        [HttpPost]
        public ActionResult Add(Category data)
        {
            if (User.Identity.IsAuthenticated)
            {
                service.CategoryService.Add(data);
                return Redirect("/Admin/Category/List");

            }
            return Redirect("/Account/Login");

        }
        public ActionResult List()
        {
            if (User.Identity.IsAuthenticated)
            {
                List<Category> model = service.CategoryService.GetActive();
                return View(model);

            }
            return Redirect("/Account/Login");

        }
        public ActionResult Update(int ID)
        {
            if (User.Identity.IsAuthenticated)
            {
                Category cat = service.CategoryService.GetById(ID);
                CategoryDTO model = new CategoryDTO();
                model.ID = cat.ID;
                model.CategoryName = cat.CategoryName;
                model.Description = cat.Description;
                return View(model);

            }
            return Redirect("/Account/Login");

        }

        [HttpPost]
        public ActionResult Update (CategoryDTO data)
        {
            if (User.Identity.IsAuthenticated)
            {
                Category cat = service.CategoryService.GetById(data.ID);
                cat.CategoryName = data.CategoryName;
                cat.Description = data.Description;
                service.CategoryService.Update(cat);
                return Redirect("/Admin/Category/List");

            }
            return Redirect("/Account/Login");

        }
        public ActionResult Delete(int ID)
        {
            if (User.Identity.IsAuthenticated)
            {
                service.CategoryService.Remove(ID);
                return Redirect("/Admin/Category/List");

            }
            return Redirect("/Account/Login");


        }
    }
}