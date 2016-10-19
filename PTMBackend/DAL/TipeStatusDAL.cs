using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PTMBackend.Models;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.Data;

namespace PTMBackend.DAL
{
    public class TipeStatusDAL
    {
        private string GetConnString()
        {
            return ConfigurationManager.ConnectionStrings["PTMDbConnectionString"].ConnectionString;
        }

        public IEnumerable<TipeStatus> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSQL = @"SP_GetAllTipeStatus";

                var results = conn.Query<TipeStatus>(strSQL, 
                    commandType:CommandType.StoredProcedure);

                return results;


                /*List<TipeStatus> lstTipe = new List<TipeStatus>();
                SqlCommand cmd = new SqlCommand(strSQL,conn);
                SqlDataReader dr = cmd.ExecuteReader();

                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        lstTipe.Add(new TipeStatus
                        {
                            IdTipeStatus = Convert.ToInt32(dr["IdTipeStatus"]),
                            NamaTipe = dr["NamaTipe"].ToString()
                        });
                    }
                }
                return lstTipe;*/
            }
        }

        public TipeStatus GetById(string id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                var strSql = @"SP_GetByIdTipeStatus";

                var param = new { IdTipeStatus = id };

                var results = conn.Query<TipeStatus>(strSql,
                  param, commandType: CommandType.StoredProcedure);

                return results.FirstOrDefault(); 
            }
        }

        public void Insert(TipeStatus tipestatus)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                var strSql = @"insert into TipeStatus(IdTipeStatus,NamaTipe) 
                               values(@IdTipeStatus,@NamaTipe)";

                var param = new
                {
                    IdTipeStatus = tipestatus.IdTipeStatus,
                    NamaStatus = tipestatus.NamaTipe
                };

                try
                {
                    conn.Execute(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
            }
        }

        public void Update(TipeStatus tipestatus)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                var strSql = @"update TipeStatus set NamaTipe=@NamaTipe 
                               where IdTipeStatus=@IdTipeStatus";

                var param = new
                {
                    NamaTipe = tipestatus.NamaTipe,
                    IdTipeStatus = tipestatus.IdTipeStatus
                };

                try
                {
                    conn.Execute(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
            }
        }

        public void Delete(TipeStatus tipestatus)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                var strSql = @"delete from TipeStatus 
                               where IdTipeStatus=@IdTipeStatus";

                var param = new { IdTipeStatus = tipestatus.IdTipeStatus };
                try
                {
                    conn.Execute(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
            }
        }
    }
}