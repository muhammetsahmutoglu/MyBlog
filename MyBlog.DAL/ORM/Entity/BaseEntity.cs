using MyBlog.DAL.ORM.Enum;
using MyBlog.DAL.ORM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL.ORM.Entity
{
    public class BaseEntity : IBaseEntity
    {
        public int ID { get; set; }

        private DateTime _addDate = DateTime.Now;
        public DateTime AddDate { get { return _addDate; } set { _addDate = value; } }

        private DateTime _modifiedDate = DateTime.Now;
        public DateTime ModifiedDate { get { return _modifiedDate; } set { _modifiedDate = value; } }

        private DateTime _deleteDate = DateTime.Now;
        public DateTime DeleteDate { get { return _deleteDate; } set { _deleteDate = value; } }

        private Status _status = MyBlog.DAL.ORM.Enum.Status.Active;
        public Status Status { get { return _status; } set { _status = value; } }
    }
}
