﻿using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Admin.Models.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.UI.Areas.Admin.Models.DTO
{
    public class ArticleDTO : BaseDTO
    {
        public string Header { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public DateTime? PublishDate { get; set; }

        public int CategoryID { get; set; }
        public int AppUserID { get; set; }



    }
}