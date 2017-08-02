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

namespace SistemaParqueo
{
    public partial class ScreenMonitorForm : Form
    {
        
        public string adamip = Properties.Settings.Default.AdamIp;
        public int adamport = Convert.ToInt16(Properties.Settings.Default.AdamPort);
        PrinterStatus printer = new PrinterStatus();

        public ScreenMonitorForm()
        {
            InitializeComponent();
        }

        private void ScreenMonitorForm_Load(object sender, EventArgs e)
        {

            screenMonitor_timer.Enabled = true;
            updateStatusOnDb_timer.Enabled = true;
        }

        private void screenMonitor_timer_Tick(object sender, EventArgs e)
        {

            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync(); // read adam
            }


            printer.PrinterState(Properties.Settings.Default.DefaultPrinter); // upadate printer status
            CondicionesGenerarTicketEntrada();
            upadateScreenMsj();

        }

        private void ScreenMonitorForm_Click(object sender, EventArgs e)
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

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        


        private void upadateScreenMsj()
        {

            if (Program.printerOffline || Program.printerOutOfPaper || Program.printerPaperJammed || Program.printerDoorOpened && Program.PushButtonPressed)
            {
                MonitorTextToShow_lbl.Text = "Ticket Manual";
            }
            else if (!Program.PushButtonPressed && !Program.LoopTicketEntrada)
            {
                MonitorTextToShow_lbl.Text = "Nombre Establecimiento";

            }

            else if (Program.LoopTicketEntrada && !Program.PushButtonPressed)
            {
                MonitorTextToShow_lbl.Text = "Presione Botón";
            }

            else if ((Program.PushButtonPressed || Program.printerPrinting) && !Program.PrinterFinishedFlag)
            {   
                if (!Program.SendJobToPrinterFlag)
                {
                    Program.SendJobToPrinterFlag = true;
                    ImprimirTicket();
                    
                }
                
                MonitorTextToShow_lbl.Text = "Imprimiendo Ticket...";
                timer1.Enabled = true;
                
            }
            else if (Program.TicketStillOnPrinter)
            {
                MonitorTextToShow_lbl.Text = "Favor Retirar Ticket";
                Program.TicketRetiredFlag = true;
            }
            else 
            {

                MonitorTextToShow_lbl.Text = "Favor Avanzar";
                if (!Program.SendPulseToOpenArmFlag)
                {
                    AbrirBrazoEntrada();
                    Program.SendPulseToOpenArmFlag = true;
                }
                
            }
            
        }

        private void CondicionesGenerarTicketEntrada()
        {
            if (Program.PushButton && !Program.PushButtonPressed)
            {
                if (Program.LoopTicketEntrada || Properties.Settings.Default.ByPassLoopEntrada)
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
                    Program.TicketRetiredFlag = false;
                    Program.PrinterFinishedFlag = false;
                    Program.SendJobToPrinterFlag = false;
                    Program.SendPulseToOpenArmFlag = false;
                }

            }
            
        }

        private void GenerarTicketEntrada()
        {
            if (!Program.printerPrinting)
            {
                
                // if ticket printed correctly
                
            }
            if (!Program.TicketStillOnPrinter && Program.PushButtonPressed)
            {
               
            } 
        }

        private void AbrirBrazoEntrada()
        {
            pulsoAbrirBrazo_timer.Enabled = true;
            Program.adam_func.AdamWrite(Program.adam6060, 17, true);
            
        }

        private void ImprimirTicket()
        {
            string barcodeData = DateTime.Now.ToString("yyMMddHHmmss");
            barcodeData = Properties.Settings.Default.EstacionNumero + barcodeData;
            string fecha = DateTime.Now.ToString();
            string hora = DateTime.Now.ToString("HH:mm:ss");
            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBox1.Image = barcode.Draw(barcodeData, 20);           
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            DatosTicket D = new DatosTicket();
            D.Estacion = Properties.Settings.Default.EstacionNumero.ToString();
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
            ConfiguracionSistemaForm form = new ConfiguracionSistemaForm();
            
            form.Show();
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
            u.printerOffline = Program.printerOffline;
            u.printerDoorOpened = Program.printerDoorOpened;
            u.printerOutOfPaper = Program.printerOutOfPaper;
            u.printerPaperJammed = Program.printerPaperJammed;
            u.printerPrinting = Program.printerPrinting;
            u.adamOnline = Program.adamOnline;
            u.adamInput1 = Program.PushButton;
            u.adamInput2 = Program.LoopTicketEntrada;
            u.adamInput3 = Program.LoopBrazoEntrada;
            u.adamInput4 = Program.AdamInput4;
            u.adamInput5 = Program.AdamInput5;
            u.adamInput6 = Program.AdamInput6;
            u.updateDate = DateTime.Now;
            u.UpdateStatus();
        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            Program.adamOnline = Program.adam_func.connectAdam(Program.adam6060, adamip, adamport);
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Program.loopBrazoLecturaAnterior = Program.LoopBrazoEntrada;
            Program.adam_func.AdamInputRead(Program.adam6060);
            Program.adam_func.AdamOutputRead(Program.adam6060);
            if (Program.loopBrazoLecturaAnterior == true && Program.LoopBrazoEntrada == false)
            {
                Program.CarPassed = true;

            }
        }

        private void pulsoAbrirBrazo_timer_Tick(object sender, EventArgs e)
        {
            pulsoAbrirBrazo_timer.Enabled = false;
            Program.adam_func.AdamWrite(Program.adam6060, 17, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.TicketStillOnPrinter)
            {
                Program.TicketStillOnPrinter = false;
            }

            else
            {
                Program.TicketStillOnPrinter = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Program.PrinterFinishedFlag = true;
            timer1.Enabled = false;
        }
    }
}
