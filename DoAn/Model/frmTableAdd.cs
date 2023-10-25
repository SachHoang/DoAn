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

namespace DoAn.Model
{
    public partial class frmTableAdd : SampleAdd
    {
        public frmTableAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        public override void button2_Click(object sender, EventArgs e)
        {


            using (var context = new Model1())
            {
                table newCategory = new table
                {
                    tname = txtName.Text
                };

                context.tables.Add(newCategory);
                MessageBox.Show("Thêm Thành Công!");
                context.SaveChanges();
            }



        }

    }
    
}
