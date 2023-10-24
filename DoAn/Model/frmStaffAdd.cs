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
    public partial class frmStaffAdd : SampleAdd
    {
        public frmStaffAdd()
        {
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (var context = new Model1())
            {
                Staff sff = new Staff();
                {

                    sff.ID = txtID.Text;
                    sff.Name = txtName.Text;
                    sff.Phone = txtPhone.Text;
                    sff.Role = comboBox1.Text;
                    sff.Address = txtAddress.Text;
                };

                context.Staffs.Add(sff);
                MessageBox.Show("Thêm Thành Công!");
                context.SaveChanges();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStaffAdd_Load(object sender, EventArgs e)
        {

        }

    }
}
