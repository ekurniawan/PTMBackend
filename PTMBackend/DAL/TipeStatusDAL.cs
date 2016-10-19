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
                string strSQL = @"select * from TipeStatus order by NamaTipe asc";

                var results = conn.Query<TipeStatus>(strSQL);
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
    }
}