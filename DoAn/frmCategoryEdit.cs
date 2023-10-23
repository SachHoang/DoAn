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
using static DoAn.MainClass;
using DoAn.View;

namespace DoAn
{
    public partial class frmCategoryEdit : Form
    {
        private category categoryToEdit;

        public frmCategoryEdit(int catID)
        {
            InitializeComponent();
            using (var context = new Model1())
            {
                this.categoryToEdit = context.categories.FirstOrDefault(c => c.catID == catID);
            }

            // Hiển thị thông tin danh mục trong các thành phần giao diện
            txtCatName.Text = categoryToEdit.catName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            categoryToEdit.catName = txtCatName.Text;

            using (var context = new Model1()) // Thay thế "MyDbContext" bằng lớp dẫn xuất từ cơ sở dữ liệu của bạn
            {
                context.Entry(categoryToEdit).State = EntityState.Modified;
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
