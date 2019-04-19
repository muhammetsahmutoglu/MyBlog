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
    public class AppUserController : BaseController
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
        public ActionResult Add(AppUser data)
        {
            if (User.Identity.IsAuthenticated)
            {
                service.AppUserService.Add(data);
                return Redirect("/Admin/AppUser/List");

            }
            return Redirect("/Account/Login");

        }

        public ActionResult List()
        {
            if (User.Identity.IsAuthenticated)
            {
                List<AppUser> model = service.AppUserService.GetActive();
                return View(model);

            }
            return Redirect("/Account/Login");

        }
        public ActionResult Update(int ID)
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = service.AppUserService.GetById(ID);
                AppUserDTO model = new AppUserDTO();
                model.ID = user.ID;
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.UserName = user.UserName;
                model.Role = user.Role;
                model.Gender = user.Gender;
                model.Email = user.Email;
                model.Password = user.Password;
                return View(model);

            }
            return Redirect("/Account/Login");

        }
        [HttpPost]
        public ActionResult Update(AppUserDTO data)
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = service.AppUserService.GetById(data.ID);
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;
                user.UserName = data.UserName;
                user.Password = data.Password;
                user.Email = data.Email;
                user.Gender = data.Gender;
                user.Role = data.Role;
                service.AppUserService.Update(user);
                return Redirect("/Admin/AppUser/List");

            }
            return Redirect("/Account/Login");

        }
        public ActionResult Delete(int ID)
        {
            if (User.Identity.IsAuthenticated)
            {
                service.AppUserService.Remove(ID);
                return Redirect("/Admin/AppUser/List");

            }
            return Redirect("/Account/Login");


        }
    }
}