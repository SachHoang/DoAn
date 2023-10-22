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
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using DoAn.Model;
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
                USER = dt.Rows[0][uName].ToString();
            }
            return isValid;
        }*/




        /*public class MyContext : DbContext
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

                if()
            }
        }

        public static string user;
        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }
        public static int SQL(string qry, Hashtable ht)
         {
             int res = 0;
             try
             {

                 SqlCommand cmd = new SqlCommand(qry, con);
                 cmd.CommandType = CommandType.Text;

                 foreach (DictionaryEntry item in ht)
                 {
                     cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);

                 }
                 if (con.State == ConnectionState.Closed) { con.Open(); }
                 res = cmd.ExecuteNonQuery();
                 if (con.State == ConnectionState.Open) { con.Close(); }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.ToString());
                 con.Close();
             }

             return res;

         }
         public static string LoadData(string qry, DataGridView gv, ListBox lb)
         {
             try
             {
                 SqlCommand cmd = new SqlCommand(qry, con);
                 cmd.CommandType = CommandType.Text;
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                 DataTable dt = new DataTable();
                 da.Fill(dt);

                 for (int i = 0; i < lb.Items.Count; i++)
                 {
                     string colNam1 = ((DataGridViewColumn)lb.Items[i]).Name;
                     gv.Columns[colNam1].DataPropertyName = dt.Columns[1].ToString();
                 }

                 gv.DataSource = dt;
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.ToString());
                 con.Close();
             }  
       */



        public class User
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class MyDbContext : DbContext
        {
            public MyDbContext() : base("Data Source=localhost;Initial Catalog=DoAN;Integrated Security=True")
            {
            }

            public DbSet<User> Users { get; set; }
        }

        public static bool IsValidUser(string user, string pass)
        {
            using (Model1 context = new Model1())
            {
                var userEntity = context.users.SingleOrDefault(u => u.username == user && u.upass == pass);
                if (userEntity != null)
                {
                    USER = userEntity.uName;
                    return true;
                }
            }
            USER = null;
            return false;
        }
        public static string user;
        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }


        public static int SQL(string qry, Hashtable ht)
        {
            using (var context = new MyDbContext())
            {
                var connection = (SqlConnection)context.Database.Connection;
                connection.Open(); // Mở kết nối

                // Tạo một đối tượng SqlCommand mới             
                var cmd = new SqlCommand(qry, connection);
                // Thêm các tham số vào đối tượng SqlCommand
                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }

                // Thực thi câu lệnh SQL
                int result = cmd.ExecuteNonQuery();

                //connection.Close(); // Đóng kết nối

                return result;
            }
        }




        public static string LoadData(string qry, DataGridView gv, ListBox lb)
        {
            using (var context = new MyDbContext())
            {
                // Tạo một đối tượng SqlDataAdapter mới
                var da = new SqlDataAdapter(qry, (SqlConnection)context.Database.Connection);

                // Điền dữ liệu vào một đối tượng DataTable
                var dt = new DataTable();
                da.Fill(dt);

                // Liên kết dữ liệu từ đối tượng DataTable đến DataGridView
                gv.DataSource = dt;

                // Liên kết các cột của DataGridView với các thuộc tính của đối tượng Entity
                for (int i = 0; i < lb.Items.Count; i++)
                {
                    var colNam1 = ((DataGridViewColumn)lb.Items[i]).Name;
                    gv.Columns[colNam1].DataPropertyName = dt.Columns[i].ToString();
                }

                return gv.ToString();
            }

        }     
    }
}
