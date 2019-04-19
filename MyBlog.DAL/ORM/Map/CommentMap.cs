using MyBlog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL.ORM.Map
{
   public class CommentMap:BaseMap<Comment>
    {
        public CommentMap()
        {
            ToTable("Comments");
            Property(x => x.Header).IsRequired();
            Property(x => x.Content).IsOptional();
            Property(x => x.CommentNumber).IsOptional();

            HasRequired(x => x.AppUser).WithMany(x => x.Comments).HasForeignKey(x => x.AppUserID).WillCascadeOnDelete(false);

            HasRequired(x => x.Article).WithMany(x => x.Comments).HasForeignKey(x => x.ArticleID).WillCascadeOnDelete(false);


        }
    }
}
