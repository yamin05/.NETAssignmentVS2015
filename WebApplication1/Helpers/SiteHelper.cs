using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using WebApplication1.Exceptions;

namespace WebApplication1.Helpers
{
    public class SiteHelper
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        private string sql = null;

        //open database
        public void OpenConnection()
        {
            conn.ConnectionString = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "";

            conn.Open();
        }


        //add new client to database
        public int AddNewClient(string name, string address, string district)
        {
            OpenConnection();

            sql = "insert into Clients(ClinetName,ClientAddress,ClientDistrict) values('" + name + "','" + address + "','" + district + "')";
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            //return a value to check non query
            int count = cmd.ExecuteNonQuery();
            conn.Closed();
            return count;
        }


        //add new intervention to database
        public int AddNewIntervention(string interventionName, decimal hours, decimal cost)
        {
            OpenConnection();

            sql = "";
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            //return a value to check non query
            int count = cmd.ExecuteNonQuery();

            conn.Closed();
            return count;

        }


        // base on the sql, load textbook to list information
        public void LoadDatabase()
        {
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                //textbox.Text = read.GetString(dr.GetOrdinal("Name"));
            }

        }


        //select different districts to display Clients list
        public string SelectDistricts(string district)
        {
            OpenConnection();

            sql = "select......";
            cmd = new SqlCommand(sql, conn);

            //load data
            LoadDatabase();

            conn.Close();

        }

       

        //select different Clients to display interventions
        public int SelectClients()
        {
            OpenConnection();

            sql = "";
            cmd = new SqlCommand(sql, conn);

            LoadDatabase();

            conn.Close();
        }

        
    }
}