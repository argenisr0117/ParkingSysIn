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
        Settings S = new Settings();
        public ConfiguracionSistemaForm()
        {
            InitializeComponent();
        }

        private void ConfiguracionSistemaForm_Load(object sender, EventArgs e)
        {

            try
            {

                //TopMost = true;
                

                DataTable dt = new DataTable();
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    printerList_cb.Items.Add(printer.ToString());
                }
                FillComboEstaciones();
                printerList_cb.Text = Program.defaultprinter;

                byPassLoopEntrada_chbox.Checked = Program.byPassLoopEntrada;
                byPassLoopBrazoEntrada_chbox.Checked = Program.byPassBrazo;
                byPassPapelPresenter_chbox.Checked = Program.byPassPapelPresenter;

                byPassAdam_chbox.Checked = Program.byPassAdam;

                adamIp_txt.Text = Program.AdamIp;
                adamPort_txt.Text = Convert.ToString(Program.AdamPort);

                estacionNombre.Text = Program.EstacionNombre;
                estacionNumero_txt.Text = Program.EstacionNumero;

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
                loopEntrada_cb.Text = Program.LoopEntradaInput;
                pushButton_cb.Text = Program.PushButtonInput;
                loopBrazo_cb.Text = Program.LoopBrazoInput;
                abrirBrazo_cb.Text = Program.AbrirBrazoOutput;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void saveSettings_button_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (Utilidades.ValidarForm2(panel2, errorProvider1) == false)
                {
                    return;
                }
                if (Utilidades.ValidarForm2(panel3, errorProvider1) == false)
                {
                    return;
                }
                Program.defaultprinter = printerList_cb.SelectedItem.ToString();
                if (byPassLoopEntrada_chbox.Checked)
                {
                    Program.byPassLoopEntrada = true;
                }
                else
                {
                    Program.byPassLoopEntrada = false;
                }

                if (byPassAdam_chbox.Checked)
                {
                    Program.byPassAdam = true;
                }
                else
                {
                    Program.byPassAdam = false;
                }

                if (byPassLoopBrazoEntrada_chbox.Checked)
                {
                    Program.byPassBrazo = true;
                }
                else
                {
                    Program.byPassBrazo = false;
                }

                if (byPassPapelPresenter_chbox.Checked)
                {
                    Program.byPassPapelPresenter = true;
                }
                else
                {
                    Program.byPassPapelPresenter = false;
                }

                Program.LoopEntradaInput = loopEntrada_cb.Text;
                Program.PushButtonInput = pushButton_cb.Text;
                Program.LoopBrazoInput = loopBrazo_cb.Text;
                Program.AbrirBrazoOutput = abrirBrazo_cb.Text;
                Program.AdamIp = adamIp_txt.Text;
                Program.AdamPort = Convert.ToInt32(adamPort_txt.Text);

                Program.EstacionNombre = estacionNombre.Text;
                S.EntSal = "ent";
                S.defaultprinter = Program.defaultprinter;
                S.byPassloop = Program.byPassLoopEntrada;
                S.byPassBrazo = Program.byPassBrazo;
                S.byPassAdam = Program.byPassAdam;
                S.adamIp = Program.AdamIp;
                S.adamPort = Program.AdamPort;
                S.estacionNombre = Program.EstacionNombre;
                S.estacionNumero = estacionNumero_txt.Text;
                S.estacionAnterior = Program.EstacionNumero;
                S.InputLoopBrazo = Program.LoopBrazoInput;
                S.InputLoop = Program.LoopEntradaInput;
                S.InputPushButton = Program.PushButtonInput;
                S.OutputAbrirBrazo = Program.AbrirBrazoOutput;
                S.byPassPaperPresenter = Program.byPassPapelPresenter;
                bool mensaje = S.SaveSettings();
                Program.EstacionNumero = estacionNumero_txt.Text;
                Properties.Settings.Default.Estacion = Program.EstacionNumero;


                FillComboEstaciones();
                Properties.Settings.Default.Save();
                MessageBox.Show("Configuración Guardada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
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

        private void FillComboEstaciones()
        {
            S.EntSal = "ent";

            try
            {
                estaciones_cb.DataSource = S.GetEstaciones();
                estaciones_cb.DisplayMember = "EstacionNumero";
                estaciones_cb.ValueMember = "EstacionNumero";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadSetting_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Settings S = new Settings();
                S.EntSal = "ent";
                S.estacionNumero = estaciones_cb.Text;
                S.GetSettings();

                printerList_cb.Text = Program.defaultprinter;

                byPassLoopEntrada_chbox.Checked = Program.byPassLoopEntrada;
                byPassLoopBrazoEntrada_chbox.Checked = Program.byPassBrazo;

                byPassAdam_chbox.Checked = Program.byPassAdam;

                adamIp_txt.Text = Program.AdamIp;
                adamPort_txt.Text = Convert.ToString(Program.AdamPort);

                estacionNombre.Text = Program.EstacionNombre;
                estacionNumero_txt.Text = Program.EstacionNumero;
                loopEntrada_cb.Text = Program.LoopEntradaInput;
                loopBrazo_cb.Text = Program.LoopBrazoInput;
                pushButton_cb.Text = Program.PushButtonInput;
                abrirBrazo_cb.Text = Program.PushButtonInput;

                Properties.Settings.Default.Estacion = Program.EstacionNumero;
                baseDatosConexion_txt.Text = Properties.Settings.Default.Conexion;
                Properties.Settings.Default.Save();
                MessageBox.Show("Configuración Cargada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void loopEntrada_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(loopEntrada_cb.Text == pushButton_cb.Text || loopEntrada_cb.Text == loopBrazo_cb.Text)
            {
                MessageBox.Show("Entrada esta siendo usada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loopEntrada_cb.Text = Program.LoopEntradaInput;
                pushButton_cb.Text = Program.PushButtonInput;
                loopBrazo_cb.Text = Program.LoopBrazoInput;
                
            }
            
            

        }

        private void pushButton_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loopEntrada_cb.Text == pushButton_cb.Text || pushButton_cb.Text == loopBrazo_cb.Text)
            {
                MessageBox.Show("Entrada esta siendo usada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loopEntrada_cb.Text = Program.LoopEntradaInput;
                pushButton_cb.Text = Program.PushButtonInput;
                loopBrazo_cb.Text = Program.LoopBrazoInput;
            }



        }

        private void loopBrazo_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loopEntrada_cb.Text == loopBrazo_cb.Text || pushButton_cb.Text == loopBrazo_cb.Text)
            {
                MessageBox.Show("Entrada esta siendo usada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loopEntrada_cb.Text = Program.LoopEntradaInput;
                pushButton_cb.Text = Program.PushButtonInput;
                loopBrazo_cb.Text = Program.LoopBrazoInput;
            }


        }
    }
}
