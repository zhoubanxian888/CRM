using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model.Search
{
    public class UserInfoSearch : BaseSearch
    {
        public string UserName { get; set; }

        public string UserRemark { get; set;  }
    }
}
