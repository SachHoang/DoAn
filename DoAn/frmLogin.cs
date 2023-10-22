using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn.Database;

namespace DoAn
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void ShowGiaodien() //Viết 1 hàm không trả về giá trị và không đối số thực hiện việc hiển thị form 2

        {
            frmMain gd = new frmMain();
            gd.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = "admin";
            string password = "123";

            // Lấy tên người dùng và mật khẩu được nhập
            string inputUsername = txtUser.Text;
            string inputPassword = txtPass.Text;

            if (MainClass.UserHelper.IsValidUser(inputUsername, inputPassword))
            {
                MessageBox.Show("Bạn nhập sai TK hoặc MK mời nhập lại ");
                return;
            }
            else
            {
                Thread thread = new Thread(new ThreadStart(ShowGiaodien)); // Khởi tạo luồng mới
                thread.Start(); //Khởi chạy luôngf
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
