using Data.IRepositories;
using Data.Util;
using Database;
using Database.Entities.Modules.Login;
using Database.Entities.Modules.Login.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class LoginRepository : Repository<UT_Admin_User>, ILoginRepository
    {
        UHSUtil _Util = new UHSUtil();
        private readonly UHSToolDBContext _dbContext;
        public LoginRepository(UHSToolDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        //public LoginDto MapSP_Ut_admin_getuserdetails(IList<SP_Ut_admin_getuserdetails> UserDetails)
        //{
        //    return _mapper.Map<IList<SP_Ut_admin_getuserdetails>, LoginDto>(UserDetails);
        //}
        public async Task<IList<SP_Ut_admin_getuserdetails>> GetUser(UT_Admin_User request)
        {

            var UserDetails = _dbContext.__SP_Ut_admin_getuserdetails
                                             .FromSqlRaw("Ut_admin_getuserdetails {0}, {1}",
                                                 request.vc_username.ToUpper().ToString(),
                             _Util.EncryptString(request.vc_password).ToString()).ToList();

            ////LINQ Query 

            //var user = from t1 in _dbContext.Set<UT_Admin_User>()
            //                .Where(t1 => t1.b_isdeleted == false && 
            //                    t1.vc_username == loginUser.vc_username.ToUpper() && 
            //                    t1.vc_password == _Util.EncryptString(loginUser.vc_password)).ToList()

            //           join t2 in _dbContext.Set<UT_Admin_RoleUser>()
            //                .Where(t2 => t2.b_isdeleted == false).ToList()
            //                on t1.pki_user_id equals t2.fki_user_id

            //           join t3 in _dbContext.Set<UT_Admin_Role>()
            //                .Where(t3 => t3.b_isdeleted == false).ToList()
            //                on t2.fki_role_id equals t3.pki_role_id

            //           select new {
            //               t1.pki_user_id,
            //               t3.pki_role_id,
            //               t1.vc_name,
            //               t1.b_isreset,
            //               t3.vc_rolename,
            //               t1.vc_email,
            //               t3.vc_roledesc
            //           };
            
            return await Task.Run(() =>
            {
               return UserDetails;
            });
        }

        public void GetResetPwd(UT_Admin_User loginUser)
        {
            //UHSUtil _Util = new UHSUtil();
            //_dbContext.UT_Admin_User
            //                        .Update(loginUser);
        }


    }
}
