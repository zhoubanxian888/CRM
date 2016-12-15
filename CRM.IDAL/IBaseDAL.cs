using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.IDAL
{
    public interface IBaseDAL<T> where T : class, new()
    {
        IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> wherelambda);

        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> wherelambda, System.Linq.Expressions.Expression<Func<T, s>> orderbylambda, bool IsAsc);

        bool DeleteEntity(T entity);

        bool EditEntity(T entity);

        T AddEntity(T entity);
    }
}
