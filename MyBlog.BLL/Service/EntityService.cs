﻿using MyBlog.BLL.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BLL.Service
{
    public class EntityService
    {
        public EntityService()
        {
            _categoryService = new CategoryRepository();
            _commentService = new CommentRepository();
            _appUserService = new AppUserRepository();
            _articleService = new ArticleRepository();
            
        }

        private CategoryRepository _categoryService;

        public CategoryRepository CategoryService
        {
            get { return _categoryService; }
            set { _categoryService = value; }
        }

        private ArticleRepository _articleService;

        public ArticleRepository ArticleService
        {
            get { return _articleService; }
            set { _articleService = value; }
        }

        private AppUserRepository _appUserService;

        public AppUserRepository AppUserService
        {
            get { return _appUserService; }
            set { _appUserService = value; }
        }

        private CommentRepository _commentService;

        public CommentRepository CommentService
        {
            get { return _commentService; }
            set { _commentService = value; }
        }

        
    }
}
