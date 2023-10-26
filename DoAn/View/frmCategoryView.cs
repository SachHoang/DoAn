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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace DoAn.View
{
    public partial class frmCategoryView : SampleView
    {
        public frmCategoryView()
        {
            InitializeComponent();
        }


        private void LoadData(List<category> sv1)
        {
            
            dgvCategory.Rows.Clear();
            int stt = 1; // Bắt đầu với STT là 1
            foreach (var sv in sv1)
            {
                int index = dgvCategory.Rows.Add();
                dgvCategory.Rows[index].Cells[0].Value = stt; // Cập nhật STT cho dòng hiện tại
                dgvCategory.Rows[index].Cells[1].Value = sv.catID;
                dgvCategory.Rows[index].Cells[2].Value = sv.catName;
                stt++; // Tăng STT cho dòng tiếp theo
            }
        }


        private void frmCategoryView_Load(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<category> cat = context.categories.ToList();
            LoadData(cat);
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<category> cat = context.categories.ToList();
            frmCategoryAdd fm = new frmCategoryAdd();
            fm.ShowDialog();
            LoadData(context.categories.ToList());
        }
        private bool foundResult = false;
        public override void textBox1_TextChanged(object sender, EventArgs e)
        {           
            string searchTerm = textBox1.Text.ToLower();
            foundResult = false; // Đặt lại biến bool khi bạn bắt đầu tìm kiếm

            foreach (DataGridViewRow row in dgvCategory.Rows)
            {
                bool rowVisible = false;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchTerm))
                    {
                        rowVisible = true;
                        break;
                    }
                }

                if (row.Index != dgvCategory.NewRowIndex) // Kiểm tra dòng không phải là dòng mới chưa được lưu
                {
                    if (row.Visible != rowVisible)
                    {
                        row.Visible = rowVisible;
                    }
                }

                if (rowVisible)
                {
                    foundResult = true; // Đặt biến bool thành true nếu có kết quả được tìm thấy
                }
            }

        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex == -1) return;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<category> cat = context.categories.ToList();
            if (dgvCategory.SelectedRows.Count > 0)
            {
                // Lấy giá trị catID từ dòng đã chọn
                int catID = Convert.ToInt32(dgvCategory.SelectedRows[0].Cells[1].Value);

                // Tạo form chỉnh sửa với catID
                frmCategoryEdit editForm = new frmCategoryEdit(catID);
                editForm.ShowDialog();

                // Sau khi chỉnh sửa, nạp lại dữ liệu
                LoadData(context.categories.ToList());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Model1 s = new Model1();
            List<category> cat = s.categories.ToList();
            DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa!","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (rs == DialogResult.Yes)
            {
                if (dgvCategory.SelectedRows.Count > 0)
                {
                    // Lấy giá trị catID từ dòng đã chọn
                    int catID = Convert.ToInt32(dgvCategory.SelectedRows[0].Cells[1].Value);

                    // Xóa danh mục với catID
                    using (var context = new Model1())
                    {
                        var category = context.categories.FirstOrDefault(c => c.catID == catID);
                        if (category != null)
                        {
                            context.categories.Remove(category);
                            MessageBox.Show("Xoá Thành Công!");
                            context.SaveChanges();
                        }
                    }

                    // Sau khi xóa, nạp lại dữ liệu
                    LoadData(s.categories.ToList());
                }
            }
            else
            {
                return;
            }
        }
    }
}
