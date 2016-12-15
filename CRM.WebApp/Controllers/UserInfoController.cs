using CRM.Model.EnumType;
using CRM.Model.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.WebApp.Controllers
{
    public class UserInfoController : Controller
    {
        IBLL.IUserInfoServices UserInfoServices = new BLL.UserInfoServices();
        // GET: UserInfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddUser()
        {
            return View();
        }

        #region 展示用户数据
        public ActionResult GetUserInfoList()
        {
            string UserName = Request["name"];
            string UserRemark = Request["remark"];
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 10;
            int totalCount = 0;
            short DelFlag = (short)DeleteEnumType.Normal;
            UserInfoSearch UserInfoSearch = new UserInfoSearch()
            {
                UserName = UserName,
                UserRemark = UserRemark,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount
            };
            var userinfolist = UserInfoServices.LoadSearchEntities(UserInfoSearch, DelFlag);
            var temp = from u in userinfolist
                       select new
                       {
                           ID = u.ID,
                           UName = u.UName,
                           PWD = u.UPwd,
                           Remark = u.Remark,
                           SubTime = u.SubTime
                       };
            return Content("ok");
        }
        #endregion
    }
}