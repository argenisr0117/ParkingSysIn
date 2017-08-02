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
using System.Drawing.Printing;
using System.IO;

namespace SistemaParqueo
{
    public partial class frmTicket : Form
    {
        public string Barcode;
        public frmTicket()
        {
            InitializeComponent();
        }

        private void frmTicket_Load(object sender, EventArgs e)
        {

            TicketEntrada();
            cerrar();
        }
        private void cerrar()
        {
            this.Close();
        }
        private void TicketEntrada()
        {
            parqueoDataSet ds = new parqueoDataSet();
            parqueoDataSetTableAdapters.SEL_TICKETTableAdapter rtga = new parqueoDataSetTableAdapters.SEL_TICKETTableAdapter();          
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport lc = reportViewer1.LocalReport;
            string ruta = "Reportes\\ticket_entrada.rdlc";
            lc.ReportPath = ruta;
            rtga.Fill(ds.SEL_TICKET,Barcode);
            ReportDataSource rds = new ReportDataSource();
            reportViewer1.LocalReport.DisplayName = "TICKET ENTRADA";
            rds.Name = "DataSet1";
            rds.Value = (ds.Tables["SEL_TICKET"]);
            reportViewer1.LocalReport.DataSources.Clear();
            
            lc.DataSources.Add(rds);
            lc.PrintToPrinter();
           
        }
    }
}
