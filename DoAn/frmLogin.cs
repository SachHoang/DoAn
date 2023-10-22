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

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (MainClass.UserHelper.IsValidUser(txtUser.Text, txtPass.Text) == true)
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

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
