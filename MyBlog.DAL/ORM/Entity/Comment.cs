using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL.ORM.Entity
{
    public class Comment : BaseEntity
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public short CommentNumber { get; set; }

        public int ArticleID { get; set; }
        public virtual Article Article { get; set; }

        public int AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
