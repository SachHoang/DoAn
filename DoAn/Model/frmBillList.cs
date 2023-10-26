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
    public partial class frmBillList : SampleAdd
    {
        public frmBillList()
        {
            InitializeComponent();

        }
        private void LoadData(List<tblMain> sv1)
        {

            dgvBill.Rows.Clear();
            foreach (var sv in sv1)
            {
               
                int index = dgvBill.Rows.Add();
                dgvBill.Rows[index].Cells[0].Value = sv.MainID;
                dgvBill.Rows[index].Cells[1].Value = sv.TableName;
                dgvBill.Rows[index].Cells[2].Value = sv.total;
            }
        }


        private void frmBillList_Load(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<tblMain> sv1 = context.tblMains.ToList();
            LoadData(sv1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
