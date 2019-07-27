using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CommonDAL obj = new CommonDAL();
            //DataTable dtb = obj.GetDataTable("select * from DM_DonVi");

            //if (dtb.Rows.Count > 0)
            //{
            //    MessageBox.Show("Đơn giá phải là số");
            //}
        //    BaoCao1 bc = new BaoCao1();
        //    bc.Show();
            Form2 form = new Form2();
            form.Show();
        }
    }
}
