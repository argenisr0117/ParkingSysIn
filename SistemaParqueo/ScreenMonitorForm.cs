using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advantech.Common;
using Advantech.Protocol;
using System.Net.Sockets;
using Advantech.Adam;
using System.IO;
using System.Printing;

namespace SistemaParqueo
{
    public partial class ScreenMonitorForm : Form
    {
        
        
        public int adamport = Convert.ToInt16(Program.AdamPort);
        PrinterStatus printer = new PrinterStatus();
        ChooseInputOutputAdam IO = new ChooseInputOutputAdam();
        public ScreenMonitorForm()
        {
            InitializeComponent();
        }

        private void ScreenMonitorForm_Load(object sender, EventArgs e)
        {
            try
            {
                Settings S = new Settings();
                S.EntSal = "ent";
                S.estacionNumero = Properties.Settings.Default.Estacion;
                S.GetSettings();
                screenMonitor_timer.Enabled = true;
                updateStatusOnDb_timer.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void screenMonitor_timer_Tick(object sender, EventArgs e)
        {

            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync(); // read adam
            }

            if (!backgroundWorker2.IsBusy)
            {
                backgroundWorker2.RunWorkerAsync();
            }

            
            CondicionesGenerarTicketEntrada();
            upadateScreenMsj();

        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            Program.P.CheckPrinterStatus(); // upadate printer status
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void upadateScreenMsj()
        {

            if ((Program.PrinterOffline || Program.printerError) && !Program.PushButtonPressed)
            {
                MonitorTextToShow_lbl.Text = "Ticket Manual";
            }
            else if (!Program.PushButtonPressed && !IO.CheckInputLoopEntrada() && !Program.byPassLoopEntrada)
            {
                MonitorTextToShow_lbl.Text = Program.EstacionNombre;

            }

            else if ((Program.byPassLoopEntrada || IO.CheckInputLoopEntrada()) && !Program.PushButtonPressed)
            {
                MonitorTextToShow_lbl.Text = "Presione Botón";
            }

            else if (Program.PushButtonPressed && !Program.PrinterFinishedFlag && !Program.printerPaperInPresenter)
            {   
                if (!Program.SendJobToPrinterFlag)
                {
                    Program.SendJobToPrinterFlag = true;
                    ImprimirTicket();
                    
                }
                
                MonitorTextToShow_lbl.Text = "Imprimiendo Ticket...";
                timer1.Enabled = true;
                
            }
            else if (Program.printerPaperInPresenter || (Program.byPassPapelPresenter && !Program.PaperPresenterByPassFlag))
            {
                MonitorTextToShow_lbl.Text = "Favor Retirar Ticket";
                byPassPaperPresenter_timer.Start();

                
            }
            else 
            {

                MonitorTextToShow_lbl.Text = "Favor Avanzar";
                if (!Program.byPassAdam)
                {
                    if (!Program.SendPulseToOpenArmFlag)
                    {
                        AbrirBrazoEntrada();
                        Program.SendPulseToOpenArmFlag = true;
                    }
                    
                }

                if (Program.byPassBrazo)
                {
                    byPassBrazo_timer.Enabled = true;
                }


            }
            
        }

        private void CondicionesGenerarTicketEntrada()
        {
            if (IO.CheckInputPushButton() && !Program.PushButtonPressed)
            {
                if (IO.CheckInputLoopEntrada() || Program.byPassLoopEntrada)
                {
                    Program.PushButtonPressed = true;
                    
                }
            }
            else
            {
                if (Program.CarPassed)
                {
                    Program.PushButtonPressed = false;
                    Program.CarPassed = false;
                    Program.PrinterFinishedFlag = false;
                    Program.SendJobToPrinterFlag = false;
                    Program.SendPulseToOpenArmFlag = false;
                    Program.PaperPresenterByPassFlag = false;
                }

            }
            
        }

        private void AbrirBrazoEntrada()
        {
            pulsoAbrirBrazo_timer.Enabled = true;
            Program.adam_func.AdamWrite(Program.adam6060, 16 + IO.CheckOutputAbrirBrazo(), true);
            
        }

        private void ImprimirTicket()
        {
            string barcodeData = DateTime.Now.ToString("yyMMddHHmmss");
            barcodeData = Program.EstacionNumero + barcodeData;
            string fecha = DateTime.Now.ToString();
            string hora = DateTime.Now.ToString("HH:mm:ss");
            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBox1.Image = barcode.Draw(barcodeData, 30);           
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            DatosTicket D = new DatosTicket();
            D.Estacion = Program.EstacionNumero.ToString();
            D.Fecha = Convert.ToDateTime(fecha);
            D.Hora = TimeSpan.Parse(hora);
            D.Pic = ms.ToArray();
            D.Barcode = barcodeData;
            D.tipoTicket = "A";
            D.RegistrarTicket();

            frmTicket obj = new frmTicket();
            obj.Barcode = "";
            obj.ShowDialog();
        }

        private void imprimirTicketManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImprimirTicket();
            
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuperUserForm form = new SuperUserForm();
            form.ShowDialog();
            //EstatusDispositivosEntradaForm form = new EstatusDispositivosEntradaForm();
            //form.ShowDialog();
        }

        private void statusDispositivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EstatusDispositivosEntradaForm EstatusEntradaForm = new EstatusDispositivosEntradaForm();
            EstatusEntradaForm.Show();
        }

        private void updateStatusOnDb_timer_Tick(object sender, EventArgs e)
        {
            updateStatusOnDb_timer.Enabled = false;
            actualizarStatusDB();

            updateStatusOnDb_timer.Enabled = true;
        }

        private void actualizarStatusDB()
        {
            UpdateStatusOnDB u = new UpdateStatusOnDB();
            u.printerOffline = Program.PrinterOffline;
            u.printerDoorOpened = Program.PrinterOffline;
            u.printerOutOfPaper = Program.printerOutOfPaper;
            u.printerPaperJammed = Program.printerPaperJammed;
            u.printerError = Program.printerError;
            u.adamOnline = Program.adamOnline;
            u.adamInput1 = Program.AdamInput1;
            u.adamInput2 = IO.CheckInputLoopEntrada();
            u.adamInput3 = Program.AdamInput3;
            u.adamInput4 = Program.AdamInput4;
            u.adamInput5 = Program.AdamInput5;
            u.adamInput6 = Program.AdamInput6;
            u.updateDate = DateTime.Now;
            u.UpdateStatus();
        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            Program.adamOnline = Program.adam_func.connectAdam(Program.adam6060, Program.AdamIp, Convert.ToInt16(Program.AdamPort));
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Program.loopBrazoLecturaAnterior = IO.CheckInputLoopBrazo();
            Program.adam_func.AdamInputRead(Program.adam6060);
            Program.adam_func.AdamOutputRead(Program.adam6060);
            if (Program.loopBrazoLecturaAnterior == true && IO.CheckInputLoopBrazo() == false)
            {
                Program.CarPassed = true;

            }
        }

        private void pulsoAbrirBrazo_timer_Tick(object sender, EventArgs e)
        {
            pulsoAbrirBrazo_timer.Enabled = false;
            Program.adam_func.AdamWrite(Program.adam6060, 16 + IO.CheckOutputAbrirBrazo(), false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Program.PrinterFinishedFlag = true;
            timer1.Enabled = false;
        }

        private void MonitorTextToShow_lbl_Click(object sender, EventArgs e)
        {
            if (menuStrip1.Visible == true)
            {
                menuStrip1.Visible = false;
                //this.WindowState = FormWindowState.Maximized;

            }
            else
            {
                menuStrip1.Visible = true;
                //this.WindowState = FormWindowState.Normal;
            }
        }

        private void ScreenMonitorForm_Shown(object sender, EventArgs e)
        {
            Settings S = new Settings();
            bool mensaje = S.CheckIfSoftwareActivated();
            if (!mensaje)
            {
                MessageBox.Show("Este sistema no ha sido activado por los Administradores" + "\n" + "Nota: Software se cerrará al clickear OK o al cerrar esta ventana", "Sistema de Parqueo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try { this.Close(); }
                catch { }
                
            }
        }

        private void byPassBrazo_timer_Tick(object sender, EventArgs e)
        {
            byPassBrazo_timer.Enabled = false;
            Program.CarPassed = true;
        }

        private void byPassPaperPresenter_timer_Tick(object sender, EventArgs e)
        {
            Program.PaperPresenterByPassFlag = true;
            byPassPaperPresenter_timer.Stop();
        }
    }
}
