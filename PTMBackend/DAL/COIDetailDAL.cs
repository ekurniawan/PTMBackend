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


        public IEnumerable<COIDetail> GetCOIByStatus(string id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                var strSql = @"select * from COIDetail left join TipeStatus
                               on COIDetail.IdTipeStatus=TipeStatus.IdTipeStatus
                               where COIDetail.IdTipeStatus=@IdTipeStatus";

                var param = new { IdTipeStatus = id };
                var results = conn.Query<COIDetail, TipeStatus, COIDetail>(strSql, (c, t) =>
                {
                    c.TipeStatus = t;
                    return c;
                }, param, splitOn: "IdTipeStatus");

                return results;
            }
        }


        public COIDetail GetCOIById(string coiNumber)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                var strSql = @"select * from COIDetail where COINumber=@COINumber";
                var param = new { COINumber = coiNumber };
                var results = conn.Query<COIDetail>(strSql, param);

                if (results.Count() > 0)
                    return results.FirstOrDefault();
                else
                    return null;
            }
        }

        public void Update(string id,COIDetail model)
        {
            var result = GetCOIById(id);
            if(result!=null)
            {
                using (SqlConnection conn = new SqlConnection(GetConnString()))
                {
                    var strSql = @"update COIDetail set IdTipeStatus=@IdTipeStatus 
                                   where COINumber=@COINumber";
                    try
                    {
                        var param = new
                        {
                            IdTipeStatus = model.IdTipeStatus,
                            COINumber = id
                        };
                        conn.Execute(strSql, param);
                    }
                    catch (SqlException sqlEx)
                    {
                        throw new Exception(sqlEx.Message);
                    }
                }
            }
            else
            {
                throw new Exception("Data Not Found !");
            }
        }
    }
}