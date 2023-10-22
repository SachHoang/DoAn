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
            // Lấy tên người dùng và mật khẩu từ các trường văn bản
            string username = txtUser.Text;
            string password = txtPass.Text;

            // Kiểm tra xem người dùng có hợp lệ hay không
            if (MainClass.IsValidUser(username, password))
            {
                // Người dùng hợp lệ, chuyển sang form chính
                Thread thread = new Thread(new ThreadStart(ShowGiaodien)); // Khởi tạo luồng mới
                thread.Start(); //Khởi chạy luôngf
                this.Close();
            }
            else
            {
                // Người dùng không hợp lệ, hiển thị thông báo lỗi
                MessageBox.Show("Bạn đã nhập sai Tài Khoản hoặc Mật Khẩu ! Xin hãy nhập lại", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn thoát!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }
    }
}
