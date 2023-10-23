using DoAn.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class frmTableEdit : Form
    {
        private table tableToEdit;
        public frmTableEdit(int tID)
        {
            InitializeComponent();
            using (var context = new Model1())
            {
                this.tableToEdit = context.tables.FirstOrDefault(c => c.tid == tID);
            }

            // Hiển thị thông tin danh mục trong các thành phần giao diện
            txtTableName.Text = tableToEdit.tname;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tableToEdit.tname = txtTableName.Text;

            using (var context = new Model1()) // Thay thế "MyDbContext" bằng lớp dẫn xuất từ cơ sở dữ liệu của bạn
            {
                context.Entry(tableToEdit).State = EntityState.Modified;
                context.SaveChanges();
            }

            MessageBox.Show("Danh mục đã được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn hủy!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
