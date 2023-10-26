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
    public partial class frmStaffView : SampleView
    {
        public frmStaffView()
        {
            InitializeComponent();
        }

        private void LoadData(List<Staff> staffs)
        {           
            dgvStaff.Rows.Clear();
            int sff = 1; // Bắt đầu với STT là 1
            foreach (var sv in staffs)
            {
                int index = dgvStaff.Rows.Add();
                dgvStaff.Rows[index].Cells[0].Value = sff; // Cập nhật STT cho dòng hiện tại
                dgvStaff.Rows[index].Cells[1].Value = sv.Name;
                dgvStaff.Rows[index].Cells[2].Value = sv.Phone;
                dgvStaff.Rows[index].Cells[3].Value = sv.Role;
                dgvStaff.Rows[index].Cells[4].Value = sv.Address;
                sff++; // Tăng STT cho dòng tiếp theo
            }
        }

        private void frmStaffView_Load(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<Staff> staffs = context.Staffs.ToList();
            LoadData(staffs);
        }

        public void btnUpdate_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<Staff> sff = context.Staffs.ToList();
            if (dgvStaff.SelectedRows.Count > 0)
            {
                // Lấy giá trị catID từ dòng đã chọn
                string ID = dgvStaff.SelectedRows[0].Cells[0].Value.ToString();

                // Tạo form chỉnh sửa với ID
                frmStaffEdit editForm = new frmStaffEdit(ID);
                editForm.ShowDialog();

                // Sau khi chỉnh sửa, nạp lại dữ liệu
                LoadData(sff);

            }
           
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<Staff> sff = context.Staffs.ToList();
            frmStaffAdd fm = new frmStaffAdd();
            fm.ShowDialog();
            LoadData(context.Staffs.ToList());
        }

        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex ==-1)
            {
                return;
            }
        }

        private bool foundResult = false;
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text.ToLower();
            foundResult = false; // Đặt lại biến bool khi bạn bắt đầu tìm kiếm

            foreach (DataGridViewRow row in dgvStaff.Rows)
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

                if (row.Index != dgvStaff.NewRowIndex) // Kiểm tra dòng không phải là dòng mới chưa được lưu
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Model1 s = new Model1();
            List<Staff> staff = s.Staffs.ToList();
            DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rs == DialogResult.Yes)
            {
                if (dgvStaff.SelectedRows.Count > 0)
                {
                    // Lấy giá trị ID từ dòng đã chọn
                    string iD = (dgvStaff.SelectedRows[0].Cells[0].Value).ToString();

                    // Xóa danh mục với ID
                    using (var context = new Model1())
                    {
                        var sff = context.Staffs.FirstOrDefault(c => c.ID == iD);

                        if (sff != null)
                        {
                            context.Staffs.Remove(sff);
                            MessageBox.Show("Xoá Thành Công!");
                            context.SaveChanges();
                            // Sau khi xóa, nạp lại dữ liệu
                            LoadData(context.Staffs.ToList());

                        }
                    }
                }

                    
            }
        }
           
            
            
    }
}

