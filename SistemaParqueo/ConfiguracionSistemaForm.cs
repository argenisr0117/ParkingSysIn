using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaParqueo
{
    public partial class ConfiguracionSistemaForm : Form
    {
        
        public ConfiguracionSistemaForm()
        {
            InitializeComponent();
        }

        private void ConfiguracionSistemaForm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                printerList_cb.Items.Add(printer.ToString());
            }

            printerList_cb.Text = Properties.Settings.Default.DefaultPrinter.ToString();

            byPassLoopEntrada_chbox.Checked = Properties.Settings.Default.ByPassLoopEntrada;
            byPassLoopBrazoEntrada_chbox.Checked = Properties.Settings.Default.ByPassLoopBrazoEntrada;
          
            byPassAdam_chbox.Checked = Properties.Settings.Default.ByPassAdam;

            adamIp_txt.Text = Properties.Settings.Default.AdamIp;
            adamPort_txt.Text = Convert.ToString(Properties.Settings.Default.AdamPort);

            estacionNombre.Text = Properties.Settings.Default.EstacionNombre;
            estacionNumero_txt.Text = Properties.Settings.Default.EstacionNumero;

            baseDatosConexion_txt.Text = Properties.Settings.Default.Conexion;

            

            if (Program.adamOnline)
            {
                EntradaSalida_button.Enabled = true;
            }
            else
            {
                EntradaSalida_button.Enabled = false;
            }

            timer1.Enabled = true;

            configuracionesToolTip.SetToolTip(labelBaseDatos, "Usar Siguiente Formato: Data Source=IPMACHINE;Initial Catalog=NOMBREBD;User ID=NOMBREUSER;Password=PASSWOORDBD;Encrypt=False;Column Encryption Setting=Disabled");

        }

        private void saveSettings_button_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultPrinter = printerList_cb.SelectedItem.ToString();
            if (byPassLoopEntrada_chbox.Checked)
            {
                Properties.Settings.Default.ByPassLoopEntrada = true;
            }
            else
            {
                Properties.Settings.Default.ByPassLoopEntrada = false;
            }

            if (byPassAdam_chbox.Checked)
            {
                Properties.Settings.Default.ByPassAdam = true;
            }
            else
            {
                Properties.Settings.Default.ByPassAdam = false;
            }

            if (byPassLoopBrazoEntrada_chbox.Checked)
            {
                Properties.Settings.Default.ByPassLoopBrazoEntrada = true;
            }
            else
            {
                Properties.Settings.Default.ByPassLoopBrazoEntrada = false;
            }
            Properties.Settings.Default.AdamIp = adamIp_txt.Text;
            Properties.Settings.Default.AdamPort =Convert.ToInt32( adamPort_txt.Text);

            Properties.Settings.Default.EstacionNombre = estacionNombre.Text ;
            Properties.Settings.Default.EstacionNumero = estacionNumero_txt.Text;

            

            Properties.Settings.Default.Save();
            MessageBox.Show("Configuración Guardada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EntradaSalida_button_Click(object sender, EventArgs e)
        {
            EntradasSalidasAdamForm form = new EntradasSalidasAdamForm();
            form.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            if (Program.adamOnline)
            {
                EntradaSalida_button.Enabled = true;
            }
            else
            {
                EntradaSalida_button.Enabled = false;
            }

            timer1.Enabled = true;
        }

        private void ConfiguracionSistemaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void EntradaSalida_button_Click_1(object sender, EventArgs e)
        {
            EntradasSalidasAdamForm form = new EntradasSalidasAdamForm();
            form.Show();
        }
    }
}
