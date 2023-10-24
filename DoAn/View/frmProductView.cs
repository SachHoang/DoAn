﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn.Database;
using DoAn.Model;
namespace DoAn.View
{
    public partial class frmProductView : SampleView
    {
        public frmProductView()
        {
            InitializeComponent();
        }
        public int ProductID = 0;

        private void LoadData(List<Product> products)
        {

            dgvProduct.Rows.Clear();
            foreach (var pro in products)
            {
                int index = dgvProduct.Rows.Add();

                dgvProduct.Rows[index].Cells[0].Value = pro.ProductID;

                dgvProduct.Rows[index].Cells[1].Value = pro.pName;
                dgvProduct.Rows[index].Cells[2].Value = pro.Price;
               
                dgvProduct.Rows[index].Cells[3].Value = pro.category.catName;
            
            }
        }

        private void frmProductView_Load(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<Product> products = context.Products.ToList();
            LoadData(products);
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<Product> pro = context.Products.ToList();
            frmProductAdd fm = new frmProductAdd();
            fm.ShowDialog();
            LoadData(context.Products.ToList());
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
