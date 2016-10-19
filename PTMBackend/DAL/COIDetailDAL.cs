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
    public class COIDetailDAL
    {
        private string GetConnString()
        {
            return ConfigurationManager.ConnectionStrings["PTMDbConnectionString"].ConnectionString;
        }

        public IEnumerable<CIStatusView> GetCOIStatus()
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                var strSql = @"select TipeStatus.NamaTipe, Count(*) as Jumlah 
                               from TipeStatus left join COIDetail 
                               on COIDetail.IdTipeStatus = TipeStatus.IdTipeStatus
                               group by TipeStatus.NamaTipe";

                var results = conn.Query<CIStatusView>(strSql);
                return results;
            }
        }
    }
}