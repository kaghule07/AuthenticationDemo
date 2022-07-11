using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
namespace AuthenticationDemo.Models
{
    public class CartDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        List<Customer> list = new List<Customer>();
        public CartDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public List<Cart> GetCart(string UserId)
        {
            List<Cart> list = new List<Cart>();
           
            string str = "select * from CartTable where userid=@uid";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@userid", UserId);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while (dr.Read())
                {
                    Cart c = new Cart();
                    c.CartId = Convert.ToInt32(dr["CartId"]);
                    c.ProductId = Convert.ToInt32(dr["ProductId"]);
                    c.Quantity = Convert.ToInt32(dr["Quantity"]);
                    list.Add(c);
                }
                con.Close();
                return list;
                
            }
            else

            {
                con.Close();
                return list;
            }
        }
        public int PlaceOrder(int ProductId,string UserId,int Quantity)
        {
            string str = "insert into OrderTable values (@productid,@userid,@quantity)";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@productid", ProductId);
            cmd.Parameters.AddWithValue("@userid", UserId);
            cmd.Parameters.AddWithValue("@quantity", Quantity);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }

        public int EmptyCart(string UserId)
        {
            string str = "delete from CartTable where UserId=@UserId";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@UserId",UserId );
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

    }
}
