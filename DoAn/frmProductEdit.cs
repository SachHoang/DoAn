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
    public partial class frmProductEdit : Form
    {
        private Product productToEdit;
        public frmProductEdit(int id)
        {
            InitializeComponent();
            using (var context = new Model1())
            {
                this.productToEdit = context.Products.FirstOrDefault(c => c.ProductID == id);
                // Hiển thị thông tin danh mục trong các thành phần giao diện

                txtID.Text =id.ToString();
                txtName.Text = productToEdit.pName;
                txtPrice.Text = productToEdit.Price.ToString();
               
            }

        }
        public void FillCombobox(List<category> categories)
        {
            this.cmbCategory.DataSource = categories;
            this.cmbCategory.DisplayMember = "catName";
            this.cmbCategory.ValueMember = "catID";
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            productToEdit.pName = txtName.Text;
            productToEdit.Price = int.Parse(txtPrice.Text);
            productToEdit.catID = Convert.ToInt32(cmbCategory.SelectedValue);

            using (var context = new Model1()) // Thay thế "MyDbContext" bằng lớp dẫn xuất từ cơ sở dữ liệu của bạn
            {
                context.Entry(productToEdit).State = System.Data.Entity.EntityState.Modified;
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

        private void frmProductEdit_Load(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<category> categories = context.categories.ToList();
            FillCombobox(categories);
        }
    }
}
