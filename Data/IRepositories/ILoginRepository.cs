using Database.Entities.Modules.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepositories
{
    public interface ILoginRepository : IRepository<UT_Admin_User>
    {
        Task<object> GetUser(UT_Admin_User loginUser);
        void GetResetPwd(UT_Admin_User loginUser);
    }
}
