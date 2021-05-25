
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace DapperMVC.Models
{
    public static class DapperORM
    {
        private static string connectionstring = @"Data Source=DESKTOP-VCF6MOP;Initial Catalog=Dapperdb;Integrated Security=True";
        public static void ExecuteWithoutReturn(string ProcedureName,DynamicParameters param=null)
        {
            using (SqlConnection sqlcon=new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                sqlcon.Execute(ProcedureName, param, commandType: CommandType.StoredProcedure);
            }
        }
        public static T ExecutetReturnscalar<T>(string ProcedureName, DynamicParameters param=null)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                return (T) Convert.ChangeType(sqlcon.Execute(ProcedureName, param, commandType: CommandType.StoredProcedure),typeof(T));
            }
        }
        public static IEnumerable<T> ReturnList<T>(string ProcedureName, DynamicParameters param=null)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                return sqlcon.Query<T>(ProcedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

    }
}