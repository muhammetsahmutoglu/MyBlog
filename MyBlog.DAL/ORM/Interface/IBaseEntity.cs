using MyBlog.DAL.ORM.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL.ORM.Interface
{
    public interface IBaseEntity
    {
       int ID { get; set; }
        DateTime AddDate { get; set; }
        DateTime ModifiedDate { get; set; }
        DateTime DeleteDate { get; set; }
        Status Status { get; set; }
    }
}
