using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace AuthenticationDemo.Models
{
    public class AdminDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public AdminDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public List<Admin> GetAllProducts()
        {
            List<Admin> list = new List<Admin>();
            string str = "Select * from Product";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())

                {
                    Admin p = new Admin();
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
        public Admin GetProductById(int id)
        {
            Admin p = new Admin();
            string str = "select * from Product where Id=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    p.Id = Convert.ToInt32(dr["Id"]);
                    p.Name = dr["Name"].ToString();
                    p.Price = Convert.ToDouble(dr["Price"]);

                }
                con.Close();
                return p;
            }
            else
            {
                con.Close();
                return p;
            }
        }
        public int Save(Admin ad)
        {
            string str = "insert into Product values(@name,@price)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", ad.Name);
            cmd.Parameters.AddWithValue("@price", ad.Price);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Update(Admin ad)
        {
            string str = "update Product set Name=@name,Price=@price where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", ad.Id);
            cmd.Parameters.AddWithValue("@name", ad.Name);
            cmd.Parameters.AddWithValue("@price", ad.Price);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int Delete(int id)
        {
            string str = "delete from Product where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }

    }
}
