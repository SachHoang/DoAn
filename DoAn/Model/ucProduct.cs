using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn.Model
{
    public partial class ucProduct : UserControl
    {
        public event EventHandler onSelect = null;
        public ucProduct()
        {
            InitializeComponent();
        }

        public int id { get; set; }
        public String PPrice 
        {  
            get {  return lblPrice.Text; }
            set { lblPrice.Text = value ; }
        }


        public string PCategory { get; set; }
        public string PName
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
           
        }
        

       /* public Image PImage
        {
            get { return txtImage.Image; }
            set { txtImage.Image = value; }
        }*/

        private void txtImage_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }
    }
}
