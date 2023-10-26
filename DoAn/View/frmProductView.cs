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
    public partial class frmProductView : SampleView
    {
        public frmProductView()
        {
            InitializeComponent();
        }
       

        private void LoadData(List<Product> products)
        {

            dgvProduct.Rows.Clear();
            int stt = 1; // Bắt đầu với STT là 1
            foreach (var sv in products)
            {
                int index = dgvProduct.Rows.Add();
                dgvProduct.Rows[index].Cells[0].Value = stt; // Cập nhật STT cho dòng hiện tại
                dgvProduct.Rows[index].Cells[1].Value = sv.pName;
                dgvProduct.Rows[index].Cells[2].Value = sv.Price;
                dgvProduct.Rows[index].Cells[3].Value = sv.category.catName;
                stt++; // Tăng STT cho dòng tiếp theo
            }
        }

        private void frmProductView_Load(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<Product> products = context.Products.ToList();
            LoadData(products);
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<Product> pro = context.Products.ToList();
            frmProductAdd fm = new frmProductAdd();
            fm.ShowDialog();
            LoadData(context.Products.ToList());
        }

       

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<Product> pro = context.Products.ToList();
            if (dgvProduct.SelectedRows.Count > 0)
            {
                // Lấy giá trị ID từ dòng đã chọn
                int id = Convert.ToInt32(dgvProduct.SelectedRows[0].Cells[0].Value);

                // Tạo form chỉnh sửa với ID
                frmProductEdit editForm = new frmProductEdit(id);
                editForm.ShowDialog();

                // Sau khi chỉnh sửa, nạp lại dữ liệu
                
            }
            LoadData(context.Products.ToList());

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Model1 s = new Model1();
            List<Product> pro = s.Products.ToList();
            DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rs == DialogResult.Yes)
            {
                if (dgvProduct.SelectedRows.Count > 0)
                {
                    // Lấy giá trị ID từ dòng đã chọn
                    int ID = Convert.ToInt32(dgvProduct.SelectedRows[0].Cells[0].Value);

                    // Xóa danh mục với ID
                    using (var context = new Model1())
                    {
                        var product = context.Products.FirstOrDefault(c => c.ProductID == ID);
                        if (product != null)
                        {
                            context.Products.Remove(product);
                            MessageBox.Show("Xoá Thành Công!");
                            context.SaveChanges();
                        }
                    }

                    // Sau khi xóa, nạp lại dữ liệu
                    LoadData(s.Products.ToList());
                }
            }
            else
            {
                return;
            }
        }
        private bool foundResult = false;
        public override void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text.ToLower();
            foundResult = false; // Đặt lại biến bool khi bạn bắt đầu tìm kiếm

            foreach (DataGridViewRow row in dgvProduct.Rows)
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

                if (row.Index != dgvProduct.NewRowIndex) // Kiểm tra dòng không phải là dòng mới chưa được lưu
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

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;            
               
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
