using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace AuthenticationDemo.Models
{
    public class CustomerDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public CustomerDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public List<Customer> GetAllProducts()
        {
            List<Customer> list = new List<Customer>();
            string str = "Select * from Product";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())

                {
                    Customer p = new Customer();
                    p.Id = Convert.ToInt32(dr["Id"]);
                    p.Name = dr["Name"].ToString();
                    p.Price = Convert.ToDouble(dr["Price"]);
                    list.Add(p);
                }
                con.Close();
                return list;
            }
            else
            {
                return list;
            }
        }
    }
}
