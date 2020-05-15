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
        private readonly UHSToolDBContext _dbContext;
        public LoginRepository(UHSToolDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<object> GetUser(UT_Admin_User loginUser)
        {
            UHSUtil _Util = new UHSUtil();
            //return await _dbContext.UT_Admin_User
            //                        .Where(db => db.vc_password == _Util.EncryptString(loginUser.vc_password) && db.vc_username == loginUser.vc_username.ToUpper())
            //                        .FirstOrDefaultAsync();

            

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

            //var result = GetDynamicResult(" exec Ut_admin_getuserdetails @vc_username, @vc_password ", new SqlParameter("@vc_username", loginUser.vc_username.ToUpper()), new SqlParameter("@vc_password", _Util.EncryptString(loginUser.vc_password)));

            object user1 =null;
            return user1;
        }

        public void GetResetPwd(UT_Admin_User loginUser)
        {
            //UHSUtil _Util = new UHSUtil();
            //_dbContext.UT_Admin_User
            //                        .Update(loginUser);
        }

        //Dynamically get data
        public IEnumerable<dynamic> GetDynamicResult(string commandText, params SqlParameter[] parameters)
        {
            // Get the connection from DbContext
            var connection = _dbContext.Database.GetDbConnection();

            // Open the connection if isn't open
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = commandText;
                command.Connection = connection;

                if (parameters?.Length > 0)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }

                using (var dataReader = command.ExecuteReader())
                {
                    // List for column names
                    var names = new List<string>();

                    if (dataReader.HasRows)
                    {
                        // Add column names to list
                        for (var i = 0; i < dataReader.VisibleFieldCount; i++)
                        {
                            names.Add(dataReader.GetName(i));
                        }

                        while (dataReader.Read())
                        {
                            // Create the dynamic result for each row
                            var result = new ExpandoObject() as IDictionary<string, object>;

                            foreach (var name in names)
                            {
                                // Add key-value pair
                                // key = column name
                                // value = column value
                                result.Add(name, dataReader[name]);
                            }

                            yield return result;
                        }
                    }
                }
            }
        }

    }
}
