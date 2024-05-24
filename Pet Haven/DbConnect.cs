using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pet_Haven
{
    class DbConnect
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        private string con;

        public string connection()
        {
            con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kurai\Downloads\Pet Haven V3\Pet Haven\Pet Haven\dbPetHaven.mdf;Integrated Security=True";
            return con;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connection());
        }

        public void executeQuery(string sql)
        {
            try
            {
                cn.ConnectionString = connection();
                cn.Open();
                cm = new SqlCommand(sql, cn);
                cm.ExecuteNonQuery();
                cn.Close();

            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public void executeParameterizedQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

    }
}
