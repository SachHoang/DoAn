using DoAn.Database;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using static DoAn.MainClass;

namespace DoAn
{
    internal class MainClass
    {
        /*public static readonly string con_string = "Data Source=localhost;Initial Catalog=DoAN;Integrated Security=True";  
        public static SqlConnection con = new SqlConnection(con_string);
        public  static bool IsValidUser(string user, string pass)
        {
            bool isValid = false;

            string qry = @"Select * from users where username = '"+user+ "' and upass ='"+pass+"'";
            SqlCommand cmd = new SqlCommand(qry,con );
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                isValid = true;
            }
            return isValid;
        }*/
        public class MyContext : DbContext
        {
            public DbSet<User> Users { get; set; }
        }

        public class User
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Upass { get; set; }
        }

        public static class UserHelper
        {
            public static bool IsValidUser(string user, string pass)
            {
                using (var context = new MyContext())
                {
                    return context.Users.Any(u => u.Username == user && u.Upass == pass);
                }
                bool isValid = UserHelper.IsValidUser(user, pass);
            }
        }
       

    }
}
