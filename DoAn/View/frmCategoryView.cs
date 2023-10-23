using DoAn.Database;
using DoAn.Model;
using Microsoft.Build.Framework.XamlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DoAn.MainClass;

namespace DoAn.View
{
    public partial class frmCategoryView : SampleView
    {
        public frmCategoryView()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            using (var context = new MyDbContext())
            {
                var categories = context.Categories.ToList();
                dgvCategory.DataSource = categories;
            }
        }


        private void frmCategoryView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmCategoryAdd fm = new frmCategoryAdd();   
            fm.ShowDialog();
            LoadData();
        }

        public override void textBox1_TextChanged(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                var keyword = textBox1.Text;
                var categories = context.Categories.Where(c => c.catName.Contains(keyword)).ToList();
                dgvCategory.DataSource = categories;
            }
            LoadData();
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvCategory.Columns["dgvEdit"].Index)
                {
                    // Xử lý chức năng sửa
                    int catID = (int)dgvCategory.Rows[e.RowIndex].Cells["CatID"].Value;
                    // Mở form sửa với catID
                }
                else if (e.ColumnIndex == dgvCategory.Columns["dgvDelete"].Index)
                {
                    // Xử lý chức năng xóa
                    int catID = (int)dgvCategory.Rows[e.RowIndex].Cells["CatID"].Value;
                    // Xóa danh mục với catID
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count > 0)
            {
                // Lấy giá trị catID từ dòng đã chọn
                int catID = Convert.ToInt32(dgvCategory.SelectedRows[0].Cells["CatID"].Value);

                // Tạo form chỉnh sửa với catID
                frmCategoryEdit editForm = new frmCategoryEdit(catID);
                editForm.ShowDialog();

                // Sau khi chỉnh sửa, nạp lại dữ liệu
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count > 0)
            {
                // Lấy giá trị catID từ dòng đã chọn
                int catID = Convert.ToInt32(dgvCategory.SelectedRows[0].Cells["CatID"].Value);

                // Xóa danh mục với catID
                using (var context = new MyDbContext())
                {
                    var category = context.Categories.FirstOrDefault(c => c.catID == catID);
                    if (category != null)
                    {
                        context.Categories.Remove(category);
                        context.SaveChanges();
                    }
                }

                // Sau khi xóa, nạp lại dữ liệu
                LoadData();
            }
        }
    }
}
