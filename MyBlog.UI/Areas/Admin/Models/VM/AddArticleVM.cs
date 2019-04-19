using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Admin.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.UI.Areas.Admin.Models.VM
{
    public class AddArticleVM
    {
        public AddArticleVM()
        {
            Categories = new List<Category>();
            AppUsers = new List<AppUser>();
            Articles = new ArticleDTO();
        }



        public List<Category> Categories { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public ArticleDTO Articles { get; set; }
    }
}