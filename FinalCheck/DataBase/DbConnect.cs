using MySql.Data.MySqlClient;
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
            using (MySqlConnection conn = new MySqlConnection(StaticData.connection_string))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query_object, conn);
                cmd.CommandType = type;
                MySqlCommandBuilder.DeriveParameters(cmd);
                for (int i = 1; i <= obj.Length; i++)
                {
                    cmd.Parameters[i-1].Value = obj[i - 1];
                }
                MySqlDataAdapter dap = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                conn.Close();
                return dt;
            }
        }
        public DataSet StoreFillDS(string query_object, CommandType type, params object[] obj)
        {
            using (MySqlConnection conn = new MySqlConnection(StaticData.connection_string))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query_object, conn);
                cmd.CommandType = type;
                MySqlCommandBuilder.DeriveParameters(cmd);
                for (int i = 1; i <= obj.Length; i++)
                {
                    cmd.Parameters[i-1].Value = obj[i - 1];
                }
                MySqlDataAdapter dap = new MySqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                dap.Fill(dt);
                conn.Close();
                return dt;
            }
        }
        public  object getscalra(string query_object, CommandType type, params object[] obj)
        {
            using (MySqlConnection conn = new MySqlConnection(StaticData.connection_string))
            {
                Object data;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query_object, conn);
                cmd.CommandType = type;
                MySqlCommandBuilder.DeriveParameters(cmd);
                for (int i = 1; i <= obj.Length; i++)
                {
                    cmd.Parameters[i-1].Value = obj[i - 1];
                }
                data = cmd.ExecuteScalar();
                conn.Close();
                return data;
            }
        }
        public  int exnonquery(string query_object, CommandType type, params object[] obj)
        {
            using (MySqlConnection conn = new MySqlConnection(StaticData.connection_string))
            {
                int data;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query_object, conn);
                cmd.CommandType = type;
                MySqlCommandBuilder.DeriveParameters(cmd);
                for (int i = 1; i <= obj.Length; i++)
                {
                    cmd.Parameters[i-1].Value = obj[i - 1];
                }
                data = cmd.ExecuteNonQuery();
                conn.Close();
                return data;
            }
        }
    }
}
