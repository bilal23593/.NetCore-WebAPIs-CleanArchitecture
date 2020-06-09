using Database.Entities.Modules.Login;
using Database.Entities.Modules.Login.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepositories
{
    public interface ILoginRepository : IRepository<UT_Admin_User>
    {
        Task<IList<SP_Ut_admin_getuserdetails>> GetUser(UT_Admin_User request );
        void GetResetPwd(UT_Admin_User loginUser);
    }
}
