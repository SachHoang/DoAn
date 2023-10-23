using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DoAn.Database;
using DoAn.View;

namespace DoAn
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void ShowGiaodien() //Viết 1 hàm không trả về giá trị và không đối số thực hiện việc hiển thị form 2

        {
            frmLogin gd = new frmLogin();
            gd.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn đăng xuất!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                Thread thread = new Thread(new ThreadStart(ShowGiaodien));
                thread.Start();
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            label2.Text = MainClass.USER;
        }

        public  void AddControl(Form f)
        {
            CenterPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            CenterPanel.Controls.Add(f);
            f.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AddControl(new Home());
            label2.Text = btnHome.Text;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            AddControl(new frmCategoryView());
            label2.Text = btnCategory.Text;
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            AddControl(new frmStaffView());
            label2.Text = btnStaff.Text;
        }
    }
}
