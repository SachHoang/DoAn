using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn.Database;

namespace DoAn.Model
{
    public partial class frmProductAdd : SampleAdd
    {
        public frmProductAdd()
        {
            InitializeComponent();
        }
        public int ProductID = 0;

        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<category> categories = context.categories.ToList();
            FillCombobox(categories);
        }
       
      
        public void FillCombobox(List<category> categories)
        {
            this.cmbCategory.DataSource = categories;
            this.cmbCategory.DisplayMember = "catName";
            this.cmbCategory.ValueMember = "catID";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (var context = new Model1())
            {
                Product pro = new Product();
                {
                    


                    pro.pName = txtName.Text;
                    pro.Price = int.Parse(txtPrice.Text);
                    pro.catID = Convert.ToInt32(cmbCategory.SelectedIndex);
                   
                };

                context.Products.Add(pro);
                MessageBox.Show("Thêm Thành Công!");
                context.SaveChanges();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void btnBrowser_Click(object sender, EventArgs e)
        {
           
        }
    }
}
