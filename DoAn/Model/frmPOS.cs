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
        }

        /* private  void AddCategory()
         {
             string qry = "Select * form Category";
             SqlCommand cmd = new  SqlCommand(qry, Mainclass.con );
             SqlDataAdapter da = new SqlDataAdapter (cmd);
              DataTable dt = new DataTable();
             dt.Fill.(dt);

             CategoryPanel.Controls.Clear();

             if(dt.Rows.Count > 0)
             {
                 foreach(DataRow row  int dt.Rows);
                 Guna.UI2.WinForms.Guna2Button b =new Guna.UI2.WinForms.Guna2Button();
                 b.FillColor = Color.FromArgb(50, 55, 89);
                 b.Size = new Size(134, 45);
                 b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                 b.Text = row["catName"].ToString();

                 CategoryPanel.Controls.Add(b);
             }
     }


     private void AndItems(int id, string name, string cat, string cat, string price, Image pimage)
     {
         var w = new ucProduct();
         {
             PName = name,
                       PPrice = price,
                       PCategory = cat,
                       PImage = pimage,
                       id = Convert.ToInt32(id)


                 };
         Product.Panel.Controls.Add(w);
         w.onSelect += (ss, ee) =>
         {
             var wdg = (ucProduct)ss;
             foreach (DataGridView item in guan2DataGridView1.Rows)
             {
                 if (Convert.ToInt32(item.Cells["dgvid"].Values) == wdg.id)
                     item.Cells["dgvQty"].Value = int.Parse(item.Cells["dgvQty"].ToString() + 1);
                 item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvQty"].ToString()) *
                                                        double.Parse(item.Cells["dvgPrice"].Tostring());
             }
         }
                 guna2DataGridView1.Rows.Add(new object[] { 0, wdg.id, wdg.PName, 1, wdg.PPrice, wdg.PPrice, wdg.PPrice });

     }*/
    }
}
