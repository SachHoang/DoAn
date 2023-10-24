using DoAn.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DoAn.MainClass;

namespace DoAn.Model
{
    public partial class frmCategoryAdd : SampleAdd
    {
        public frmCategoryAdd()
        {
            InitializeComponent();
        }
        public int id = 0;

        public override void button2_Click(object sender, EventArgs e)
        {          


            using (var context = new Model1())
            {
                category newCategory = new category
                {
                    catName = txtName.Text
                };

                context.categories.Add(newCategory);
                MessageBox.Show("Thêm Thành Công!");
                context.SaveChanges();
            }

            

        }

      
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCategoryAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
