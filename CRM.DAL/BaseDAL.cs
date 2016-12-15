using CRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL
{
    public class BaseDAL<T> where T : class, new()
    {
        //TZMCEntities Db = new TZMCEntities();
        DbContext Db = DAL.DBContextFactory.CreateDBContext();

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntity(T entity)
        {
            Db.Set<T>().Add(entity);
            Db.SaveChanges();
            return entity;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            return Db.SaveChanges() > 0;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool EditEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return Db.SaveChanges() > 0;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="wherelambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> wherelambda)
        {
            return Db.Set<T>().Where<T>(wherelambda);
        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="wherelambda"></param>
        /// <param name="orderbylambda"></param>
        /// <param name="IsAsc"></param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> wherelambda, System.Linq.Expressions.Expression<Func<T, s>> orderbylambda, bool IsAsc)
        {
            var temp = Db.Set<T>().Where<T>(wherelambda);
            totalCount = temp.Count();
            if (IsAsc)
            {
                temp = temp.OrderBy<T, s>(orderbylambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, s>(orderbylambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;
        }
    }
}
