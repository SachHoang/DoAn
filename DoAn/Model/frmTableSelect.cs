using DoAn.Database;
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
    public partial class frmTableSelect : Form
    {
        public string TableName;
        public frmTableSelect()
        {
            InitializeComponent();
        }


        private void frmTableSelect_Load(object sender, EventArgs e)
        {
            using (Model1 context = new Model1())
            {
                // Truy vấn dữ liệu từ bảng "tables" sử dụng Entity Framework
                var tables = context.tables.ToList();

                foreach (var table in tables)
                {
                   Button button = new Button();
                    button.Text = table.tname;
                    button.Width = 150;
                    button.Height = 50;
                    
                    // Xử lý sự kiện khi nút được nhấn
                    button.Click += new EventHandler(b_Click);

                    flowLayoutPanel1.Controls.Add(button);
                }
            }
        }
        private void b_Click(object sender, EventArgs e)
        {
            TableName = (sender as Button).Text.ToString();
            this.Close();
        }

    }
}
