using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn.Database;
using DoAn.View;

namespace DoAn
{
    public partial class frmStaffEdit : Form
    {
        private Staff staffToEdit;
        public frmStaffEdit(string iD)
        {
            InitializeComponent();
            using (var context = new Model1())
            {
                this.staffToEdit = context.Staffs.FirstOrDefault(c => c.ID == iD);
                // Hiển thị thông tin danh mục trong các thành phần giao diện
                
                txtName.Text = staffToEdit.Name;
                txtPhone.Text = staffToEdit.Phone;
                comboBox1.Text = staffToEdit.Role;
                txtAdress.Text = staffToEdit.Address;
            }

            
        }

        public void btnSave_Click(object sender, EventArgs e)
        {

            staffToEdit.Name = txtName.Text;
            staffToEdit.Phone = txtPhone.Text;
            staffToEdit.Role = comboBox1.Text.ToString();
            staffToEdit.Address = txtAdress.Text;

            using (var context = new Model1()) // Thay thế "MyDbContext" bằng lớp dẫn xuất từ cơ sở dữ liệu của bạn
            {
                context.Entry(staffToEdit).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }

            MessageBox.Show("Danh mục đã được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát không!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
