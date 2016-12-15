using CRM.DAL;
using CRM.IDAL;
using CRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DALFactory
{
    public class DBSession : IDBSession
    {
        // TZMCEntities Db = new TZMCEntities();
        public DbContext Db
        {
            get
            {
                return DBContextFactory.CreateDBContext();
            }
        }
        private IUserInfoDAL _UserInfoDAL;
        public IUserInfoDAL UserInfoDAL
        {
            get
            {
                if (_UserInfoDAL == null)
                {
                    //_UserInfoDAL = new UserInfoDAL();
                    _UserInfoDAL = AbstractFactory.CreateUserInfoDAL();//通过抽象工厂，封装了类的实例创建
                }
                return _UserInfoDAL;
            }
            set
            {
                _UserInfoDAL = value;
            }
        }

        public bool SaveChanges()
        {
            return Db.SaveChanges() > 0;
        }

    }
}
