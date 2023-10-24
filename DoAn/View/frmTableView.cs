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
using DoAn.Model;

namespace DoAn.View
{
    public partial class frmTableView : SampleView
    {
        public frmTableView()
        {
            InitializeComponent();
        }
        private void LoadData(List<table> sv1)
        {

            dgvTable.Rows.Clear();
            foreach (var sv in sv1)
            {
                for (int i = 0; i < dgvTable.Rows.Count; i++)
                {
                    dgvTable.Rows[i].Cells[0].Value = i + 1;
                }
                int index = dgvTable.Rows.Add();
                for (int i = 0; i < dgvTable.Rows.Count; i++)
                {
                    dgvTable.Rows[i].Cells[0].Value = i + 1;
                }
                dgvTable.Rows[index].Cells[1].Value = sv.tid;
                dgvTable.Rows[index].Cells[2].Value = sv.tname;
            }
        }

        private void frmTableView_Load(object sender, EventArgs e)
        {
            
            Model1 context = new Model1();
            List<table> cat = context.tables.ToList();
            LoadData(cat);
        }
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<table> cat = context.tables.ToList();
            frmTableAdd fm = new frmTableAdd();
            fm.ShowDialog();
            LoadData(context.tables.ToList());
        }
        private bool foundResult = false;
        public override void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text.ToLower();
            foundResult = false; // Đặt lại biến bool khi bạn bắt đầu tìm kiếm

            foreach (DataGridViewRow row in dgvTable.Rows)
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

                if (row.Index != dgvTable.NewRowIndex) // Kiểm tra dòng không phải là dòng mới chưa được lưu
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


        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<table> cat = context.tables.ToList();
            if (dgvTable.SelectedRows.Count > 0)
            {
                // Lấy giá trị catID từ dòng đã chọn
                int tID = Convert.ToInt32(dgvTable.SelectedRows[0].Cells[1].Value);

                // Tạo form chỉnh sửa với catID
                frmTableEdit editForm = new frmTableEdit(tID);
                editForm.ShowDialog();

                // Sau khi chỉnh sửa, nạp lại dữ liệu
                
            }
            LoadData(context.tables.ToList());
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            Model1 s = new Model1();
            List<category> cat = s.categories.ToList();
            DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rs == DialogResult.Yes)
            {
                if (dgvTable.SelectedRows.Count > 0)
                {
                    // Lấy giá trị catID từ dòng đã chọn
                    int tID = Convert.ToInt32(dgvTable.SelectedRows[0].Cells[1].Value);

                    // Xóa danh mục với catID
                    using (var context = new Model1())
                    {
                        var category = context.tables.FirstOrDefault(c => c.tid == tID);
                        if (category != null)
                        {
                            context.tables.Remove(category);
                            MessageBox.Show("Xoá Thành Công!");
                            context.SaveChanges();
                        }
                    }

                    // Sau khi xóa, nạp lại dữ liệu
                    LoadData(s.tables.ToList());
                }
                
            }
            else
            {   
                return;
            }
        }
    }
}
