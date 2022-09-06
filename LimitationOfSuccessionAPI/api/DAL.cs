using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace maghriby.Helpers
{
    public class DAL
    {
        //public static string connectionString = @"Server=217.61.22.15\SQLEXPRESS2017;initial catalog = MagribiWebPortal; user id = sa; password=acc-2017;";
        public static string connectionString = @"Server=SQL5079.site4now.net;initial catalog = db_a838af_limitation; user id = db_a838af_limitation_admin; password=7ammodeh12072611;";
        //public static string connectionString = "Data Source =.; Initial Catalog = limitation_of_succession_web; Integrated Security = True;";
        public DataTable selectdata(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    return dt;

                }
                catch (Exception ex)
                {
                    return null;
                }
        
            }
        }
        public async Task<DataTable> selectdataasync(string q)
        {
            try
            {
                //con = new SqlConnection(constring);
                DataTable tab1 = new DataTable("tab1");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(q, con);
                    await Task.Run(() => da.Fill(tab1));
                    con.Close();
                    return tab1;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int insertdata(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand comando = new SqlCommand(query, con))
                    {
                        con.Open();
                 
                       var id = (int)comando.ExecuteScalar();
                        con.Close();

                        return id;
                    }

                }
                catch (Exception ex)
                {

                }
            }
            return -1;

        }

        public async Task insertdataasync(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand comando = new SqlCommand(query, con))
                    {
                      await  con.OpenAsync();
                      await  comando.ExecuteNonQueryAsync();
                        con.Close();
                    }

                }
                catch (Exception ex)
                {

                }
            }

        }

        public void updatedata(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand comando = new SqlCommand(query, con))
                    {
                        con.Open();
                        comando.ExecuteNonQuery();
                        con.Close();
                    }

                }
                catch (Exception ex)
                {

                }
            }

        }
        public void deletedata(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand comando = new SqlCommand(query, con))
                    {
                        con.Open();
                        comando.ExecuteNonQuery();
                        con.Close();
                    }

                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}

/*
  var row = '<tr>' +
            '<td><input type="text" class="form-control" name="Caliber_name" ></td>' +
            '<td><input type="number" step="0.01" class="form-control" name="Caliber_size" value="55" ></td>' +
            '<td><input type="number" step="0.01" class="form-control" name="Interprice" ></td>' +
              '<td><input type="number" step="0.01" class="form-control" name="Salemargin" ></td>' +
              '<td><input type="number" step="0.01" class="form-control" name="Buymargin" ></td>' +
              '<td><input type="number" step="0.01" class="form-control" name="Saleprice" ></td>' +
              '<td><input type="number" step="0.01" class="form-control" name="Buyprice"></td>' +
            '<td>' + actions + '</td>' +
        '</tr>';*/
