using CRM.Model;
using CRM.Model.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.IBLL
{
    public interface IUserInfoServices : IBaseServices<UserInfo>
    {
        bool DeleteEntities(List<int> list);

        IQueryable<UserInfo> LoadSearchEntities(UserInfoSearch UserInfoSearch, short DelFlag);

        //bool SetUserRoleInfo(int userId, List<int> roleIdList);

        //bool SetUserActionInfo(int actionId, int userId, bool isPass);

    }
}
