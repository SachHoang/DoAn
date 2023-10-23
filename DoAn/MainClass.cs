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
using DoAn.View;
namespace DoAn
{
    internal class MainClass
    {
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
            //public DbSet<category> Categories { get; set; }
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
    }
}
