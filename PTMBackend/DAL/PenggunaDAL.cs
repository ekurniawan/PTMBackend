using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PTMBackend.Models;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace PTMBackend.DAL
{
    public class PenggunaDAL
    {
        private string GetConnString()
        {
            return ConfigurationManager.ConnectionStrings["PTMDbConnectionString"].ConnectionString;
        }

        public Pengguna GetLogin(string username,string password)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"select * from Pengguna left join TipeUser
                                  on Pengguna.IdTipeUser=TipeUser.IdTipeUser
                                  where Pengguna.Username=@Username and Pengguna.Password=@Password";

                var pengguna = conn.Query<Pengguna, TipeUser, Pengguna>(strSql, (p, t) => {
                    p.TipeUser = t;
                    return p;
                }, new { Username = username, Password = password }, splitOn: "IdTipeUser");

                return pengguna.FirstOrDefault();
            }
        } 
    }
}