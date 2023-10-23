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
            /* string qry = "";
             if (id == 0)
             {
                 qry = "Insert into category Values(@Name)";

             }
             else
             {
                 qry = "Update category Set catName =  @Name where catID = @id";
             }

             Hashtable ht = new Hashtable();
             ht.Add("@id", id);
             ht.Add("@Name", txtName.Text);

             if (MainClass.SQL(qry, ht) > 0)
             {
                 MessageBox.Show("Lưu Thành Công...");
                 id = 0;
                 txtName.Focus();
             }*/


            using (var context = new MyDbContext())
            {
                category newCategory = new category
                {
                    catName = txtName.Text
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();
            }

            /*using (var context = new MyDbContext())
            {
                Category category = new Category();
                category.CatName = txtName.Text;

                if (id == 0)
                {
                    context.Categories.Add(category);
                }
                else
                {
                    context.Categories.Attach(category);
                    context.Entry(category).State = EntityState.Modified;
                }

                context.SaveChanges();
            }*/

        }

      
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
