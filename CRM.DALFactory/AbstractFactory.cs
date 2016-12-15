using CRM.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DALFactory
{
    public class AbstractFactory
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["AssemblyPath"];
        private static readonly string NameSpace = ConfigurationManager.AppSettings["NameSpace"];
        public static IUserInfoDAL CreateUserInfoDAL()
        {
            string fullClassName = NameSpace + ".UserInfoDAL";
            return create(fullClassName) as IUserInfoDAL;
        }
        private static object create(string classname)
        {
            Assembly assembly = Assembly.Load(AssemblyPath);
            return assembly.CreateInstance(classname);
        }
    }
}
