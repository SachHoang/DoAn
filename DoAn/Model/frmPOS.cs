using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static DoAn.MainClass;
using DoAn.Database;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Linq;

namespace DoAn.Model
{
    public partial class frmPOS : Form
    {
        public frmPOS()
        {
            InitializeComponent();
        }
        public int MainID = 0;
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            AddCategory();
            // Load product
            ProductPanel.Controls.Clear();
           LoadProducts();
        }

        private void AddCategory()
        {
            using (var context = new Model1()) // Thay thế "MyDbContext" bằng tên của DbContext của bạn
            {
                var categories = context.categories.ToList();

                CategoryPanel.Controls.Clear();

                foreach (var category in categories)
                {
                    Button button = new Button();
                    button.Text = category.catName;
                    button.Size = new Size(134, 45);
                 //   button.Location = new Point(x, y); // Thay x và y bằng vị trí cụ thể trên giao diện
                    CategoryPanel.Controls.Add(button);
                    //event for click
                    button.Click += new EventHandler(b_Click);
                }
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            Button button = new Button();  
            foreach (var item in ProductPanel.Controls)
            {
                var pro = (ucProduct)item;
                pro.Visible = pro.PName.ToLower().Contains(button.Text.Trim().ToLower());
            }
        }

        private void AddItems(int id, string name, string cat, string price /*, Image pimage*/)
        {
            var w = new ucProduct()
            {
                PName = name,
                PPrice = price,
                PCategory = cat,
               /* PImage = pimage,*/
                id = Convert.ToInt32(id)


            };
            ProductPanel.Controls.Add(w);

            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucProduct)ss;
                // Tìm sản phẩm có sẵn trong DataGridView
                bool productExists = false;
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (Convert.ToInt32(item.Cells["dgvid"].Value) == wdg.id)
                    {
                        productExists = true;
                        // Tăng số lượng và cập nhật tổng tiền
                        int currentQty = int.Parse(item.Cells["dgvQty"].Value.ToString());
                        item.Cells["dgvQty"].Value = currentQty + 1;
                        item.Cells["dgvAmount"].Value = (currentQty + 1) * double.Parse(item.Cells["dgvPrice"].Value.ToString());
                        break;
                    }
                }

                // Nếu sản phẩm chưa tồn tại, thêm nó vào DataGridView
                if (!productExists)
                {
                    dataGridView1.Rows.Add(new object[] { 0, wdg.id, wdg.PName, 1, wdg.PPrice, wdg.PPrice, wdg.PPrice });
                }

                // Tính toán tổng tiền
                GetTotal();
            };

        }

        private void LoadProducts()
        {
            using (var context = new Model1()) // Thay "MyDbContext" bằng tên lớp kế thừa từ DbContext của bạn
            {
                var query = from product in context.Products
                            join category in context.categories on product.catID equals category.catID
                            select new
                            {
                                ProductID = product.ProductID,
                                ProductName = product.pName,
                                CategoryName = category.catID,
                                ProductPrice = product.Price,
                              /*  ProductImage = product.pImage*/
                            };

                foreach (var item in query)
                {
                    // Chèn item vào danh sách hoặc hiển thị nó trực tiếp trên giao diện
                    AddItems(item.ProductID, item.ProductName, item.CategoryName.ToString(), item.ProductPrice.ToString() /*, ByteArrayToImage(item.ProductImage)*/);
                }
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in ProductPanel.Controls)
            {
                var pro = (ucProduct)item;
                pro.Visible = pro.PName.ToLower().Contains(txtSearch.Text.Trim().ToLower());
            }
        }


        //Hien thi ben dataridview
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                count ++;
                row.Cells[0].Value = count; 
            }
        }

        private  void GetTotal()
        {
            double tot = 0;
            lblTotal.Text = "";
            foreach(DataGridViewRow item in dataGridView1.Rows)
            {
                tot += double.Parse(item.Cells["dgvAmount"].Value.ToString());
            }

            lblTotal.Text = tot.ToString("N2");
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTBL.Text = "";
           // lblWaiter.Text = "";
            txtTBL.Visible = true;
          //  lblWaiter.Visible = false;
            dataGridView1.Rows.Clear();
            MainID = 0;
            lblTotal.Text = "0,00";
        }

        public void AddControl(Form f)
        {

            f.Show();
        }
      
        private void btnDin_Click(object sender, EventArgs e)
        {         

            // Tạo form để chọn bàn
            frmTableSelect frm = new frmTableSelect();

            if (frm.ShowDialog() == DialogResult.OK) // Đảm bảo rằng bạn đã chọn bàn và nhấn OK trên frmTableSelect
            {
                string selectedTable = frm.TableName; // Lấy tên bàn đã chọn

                if (!string.IsNullOrEmpty(selectedTable))
                {
                    txtTBL.Text = selectedTable; // Gán tên bàn vào TextBox txtTBL
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một bàn trước khi lưu hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {           

            if (string.IsNullOrEmpty(txtTBL.Text))
            {
                MessageBox.Show("Vui lòng chọn một bàn trước khi lưu hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new Model1())
            {
                tblMain main = new tblMain
                {
                    TableName = txtTBL.Text,
                    total = double.Parse(lblTotal.Text)
                };

                context.tblMains.Add(main);

                context.SaveChanges();
                MessageBox.Show("Thêm Thành Công!");
            }

        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            AddControl(new frmBillList());
        }
    }
}
