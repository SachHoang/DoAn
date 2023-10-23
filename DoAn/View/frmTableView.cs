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
namespace DoAn.View
{
    public partial class frmTableView : SampleView
    {
        public frmTableView()
        {
            InitializeComponent();
        }
        private void LoadData(List<category> sv1)
        {

            dgvCategory.Rows.Clear();
            foreach (var sv in sv1)
            {
                for (int i = 0; i < dgvCategory.Rows.Count; i++)
                {
                    dgvCategory.Rows[i].Cells[0].Value = i + 1;
                }
                int index = dgvCategory.Rows.Add();
                for (int i = 0; i < dgvCategory.Rows.Count; i++)
                {
                    dgvCategory.Rows[i].Cells[0].Value = i + 1;
                }
                //dgvCategory.Rows[index].Cells[1].Value = sv.catID;
                dgvCategory.Rows[index].Cells[1].Value = sv.catName;
            }
        }
    }
}
