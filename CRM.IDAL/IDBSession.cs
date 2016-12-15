using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.IDAL
{
    public interface IDBSession
    {
        DbContext Db { get; }
        IUserInfoDAL UserInfoDAL { get; set; }

        bool SaveChanges();

    }
}
