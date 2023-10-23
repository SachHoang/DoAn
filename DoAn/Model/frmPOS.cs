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

namespace DoAn.Model
{
    public partial class frmPOS : Form
    {
        public frmPOS()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            AddCategory();
            
            ProductPanel.Controls.Clear();
            LoadProducts();
        }

        /*private void AddCategory()
        {
            string qry = "Select * form Category";
            SqlCommand cmd = new SqlCommand(qry, Mainclass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Fill.(dt);

            CategoryPanel.Controls.Clear();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row  int dt.Rows);
                Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                b.FillColor = Color.FromArgb(50, 55, 89);
                b.Size = new Size(134, 45);
                b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                b.Text = row["catName"].ToString();

                CategoryPanel.Controls.Add(b);
            }
        }*/

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
                }
            }
        }

        private void AddItems(int id, string name, string cat, string price, Image pimage)
        {
            var w = new ucProduct()
            {
                PName = name,
                PPrice = price,
                PCategory = cat,
                PImage = pimage,
                id = Convert.ToInt32(id)


            };
            ProductPanel.Controls.Add(w);
            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucProduct)ss;
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (Convert.ToInt32(item.Cells["dgvid"].Value) == wdg.id)
                    {
                        item.Cells["dgvQty"].Value = int.Parse(item.Cells["dgvQty"].ToString() + 1);
                        item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvQty"].ToString()) *
                                                        double.Parse(item.Cells["dvgPrice"].ToString());
                    }
                    dataGridView1.Rows.Add(new object[] { 0, wdg.id, wdg.PName, 1, wdg.PPrice, wdg.PPrice, wdg.PPrice });
                }
            };
        }

        private void LoadProducts()
        {
            using (var context = new Model1()) // Thay "MyDbContext" bằng tên lớp kế thừa từ DbContext của bạn
            {
                var query = from product in context.products
                            join category in context.categories on product.CategoryID equals category.catID
                            select new
                            {
                                ProductID = product.pID,
                                ProductName = product.pName,
                                CategoryName = category.catID,
                                ProductPrice = product.pPrice,
                                ProductImage = product.pImage
                            };

                foreach (var item in query)
                {
                    // Chèn item vào danh sách hoặc hiển thị nó trực tiếp trên giao diện
                    AddItems(item.ProductID, item.ProductName, item.CategoryName.ToString(), item.ProductPrice.ToString(), ByteArrayToImage(item.ProductImage));
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
    }
}
