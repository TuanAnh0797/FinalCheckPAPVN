using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCheck.DataBase
{
    public class DbConnect
    {
       
        public  DataTable StoreFillDT(string query_object, CommandType type, params object[] obj)
        {
            using (SqlConnection conn = new SqlConnection(StaticData.connection_string))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query_object, conn);
                cmd.CommandType = type;
                SqlCommandBuilder.DeriveParameters(cmd);
                for (int i = 1; i <= obj.Length; i++)
                {
                    cmd.Parameters[i].Value = obj[i - 1];
                }
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                conn.Close();
                return dt;
            }
        }
        public DataSet StoreFillDS(string query_object, CommandType type, params object[] obj)
        {
            using (SqlConnection conn = new SqlConnection(StaticData.connection_string))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query_object, conn);
                cmd.CommandType = type;
                SqlCommandBuilder.DeriveParameters(cmd);
                for (int i = 1; i <= obj.Length; i++)
                {
                    cmd.Parameters[i].Value = obj[i - 1];
                }
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                dap.Fill(dt);
                conn.Close();
                return dt;
            }
        }
        public  object getscalra(string query_object, CommandType type, params object[] obj)
        {
            using (SqlConnection conn = new SqlConnection(StaticData.connection_string))
            {
                Object data;
                conn.Open();
                SqlCommand cmd = new SqlCommand(query_object, conn);
                cmd.CommandType = type;
                SqlCommandBuilder.DeriveParameters(cmd);
                for (int i = 1; i <= obj.Length; i++)
                {
                    cmd.Parameters[i].Value = obj[i - 1];
                }
                data = cmd.ExecuteScalar();
                conn.Close();
                return data;
            }
        }
        public  int exnonquery(string query_object, CommandType type, params object[] obj)
        {
            using (SqlConnection conn = new SqlConnection(StaticData.connection_string))
            {
                int data;
                conn.Open();
                SqlCommand cmd = new SqlCommand(query_object, conn);
                cmd.CommandType = type;
                SqlCommandBuilder.DeriveParameters(cmd);
                for (int i = 1; i <= obj.Length; i++)
                {
                    cmd.Parameters[i].Value = obj[i - 1];
                }
                data = cmd.ExecuteNonQuery();
                conn.Close();
                return data;
            }
        }
    }
}
