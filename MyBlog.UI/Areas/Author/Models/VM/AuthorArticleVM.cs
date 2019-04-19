using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Admin.Models.DTO;
using MyBlog.UI.Areas.Author.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.UI.Areas.Author.Models.VM
{
    public class AuthorArticleVM
    {
        public AuthorArticleVM()
        {
            Categories = new List<Category>();
            appUser = new AppUser();
            articles = new List<AuthorArticleDTO>();
            article = new AuthorArticleDTO();
        }



        public List<Category> Categories { get; set; }
        public AppUser appUser { get; set; }
        public List<AuthorArticleDTO> articles { get; set; }
        public AuthorArticleDTO article { get; set; }
    }
}