using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace WindowsFormsApplication1
{
    public partial class ShowBaoCao : Form
    {
        public ShowBaoCao()
        {
            InitializeComponent();
        }

        private void ShowBaoCao_Load(object sender, EventArgs e)
        {
            showDuLieu();
            //this.reportViewer1.RefreshReport();
        }

        private void showDuLieu()
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;

            LocalReport localReport = reportViewer1.LocalReport;

            localReport.ReportPath = "BaoCao.rdlc";

         //   DataSet dataset = new DataSet("Sales Order Detail");
            CommonDAL obj = new CommonDAL();
            DataTable dtb = obj.GetDataTable("Select * from DM_DonVi");

            ReportDataSource dsSalesOrder = new ReportDataSource();
            dsSalesOrder.Name = "DataSet1";
            dsSalesOrder.Value = dtb;

            localReport.DataSources.Add(dsSalesOrder);


            // Refresh the report  
            reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {


        }
    }
}
