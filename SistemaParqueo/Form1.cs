using Advantech.Adam;
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
using System.IO;

namespace SistemaParqueo
{
    public partial class Form1 : Form
    {
        
        AdamSocket adam6060 = new AdamSocket();
        AdamDevice adam_func = new AdamDevice();
        public string adamip = Properties.Settings.Default.AdamIp;
        public int adamport = Convert.ToInt16(Properties.Settings.Default.AdamPort);
        PrinterStatus printer = new PrinterStatus();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            printerAdamStatusRead_timer.Enabled = true;
            
        }
        private void ReadPrinterStatus()
        {
            try
            {
                string[] Status = printer.PrinterState(Properties.Settings.Default.DefaultPrinter.ToString());
                if (Convert.ToBoolean(Status[4]))
                {
                    printerOnline_pic.Image = Properties.Resources.circle_error;
                    toolTip_info.SetToolTip(printerOnline_pic, Status[5] + " No está conectado o No es Printer por defecto");
                }
                else
                {
                    printerOnline_pic.Image = Properties.Resources.circle_ok;
                    toolTip_info.SetToolTip(printerOnline_pic, "Printer Online");
                }

                if (Convert.ToBoolean(Status[3]))
                {
                    printerStatus_pic.Image = Properties.Resources.circle_error;
                    if (Convert.ToBoolean(Status[4]))
                    {
                        toolTip_info.SetToolTip(printerStatus_pic, "Printer OFFLINE");
                    }
                    else
                    {
                        toolTip_info.SetToolTip(printerStatus_pic, "Tapa del Printer Está abierta");
                    }

                }
                else
                {
                    printerStatus_pic.Image = Properties.Resources.circle_ok;
                    toolTip_info.SetToolTip(printerStatus_pic, "Printer Status OK");
                }

                if (Convert.ToBoolean(Status[0]))
                {
                    estadoPapel_pic.Image = Properties.Resources.circle_error;
                    if (Convert.ToBoolean(Status[4]))
                    {
                        toolTip_info.SetToolTip(estadoPapel_pic, "Printer OFFLINE");
                    }
                    else
                    {
                        toolTip_info.SetToolTip(estadoPapel_pic, "Printer No tiene Papel");
                    }

                }
                else if (Convert.ToBoolean(Status[1]))
                {
                    estadoPapel_pic.Image = Properties.Resources.circle_error;
                    if (Convert.ToBoolean(Status[4]))
                    {
                        toolTip_info.SetToolTip(estadoPapel_pic, "PRINTER OFFLINE");
                    }

                    else
                    {
                        toolTip_info.SetToolTip(estadoPapel_pic, "Papel Atascado");
                    }

                }
                else
                {
                    estadoPapel_pic.Image = Properties.Resources.circle_ok;
                    toolTip_info.SetToolTip(estadoPapel_pic, "Papel OK");
                }
                if (Convert.ToBoolean(Status[6]))
                {
                    Program.printerPrinting = true;
                    if (notifyIcon1.Visible == false)
                    {
                        notifyIcon1.Visible = true;
                        notifyIcon1.Icon = SystemIcons.Information;
                        notifyIcon1.BalloonTipText = "Imprimiendo Ticket";
                        notifyIcon1.ShowBalloonTip(19000);
                    }
                }
                else
                {
                    Program.printerPrinting = false;
                    notifyIcon1.Visible = false;

                }

            }
            catch (Exception ex)
            {

            }
        }
        private void readAdamStatus()
        {

            if (Program.adamOnline)
            {

                adamOnline_pic.Image = Properties.Resources.circle_ok;
                toolTip_info.SetToolTip(adamOnline_pic, "Adam Online");
                adam_func.AdamInputRead(adam6060);
                if (Program.AdamInputErrorRead)
                {

                    adamLectura_pic.Image = Properties.Resources.circle_error;
                    toolTip_info.SetToolTip(adamLectura_pic, "Error al leer Entradas Adam");
                }
                else
                {
                    adamLectura_pic.Image = Properties.Resources.circle_ok;
                    toolTip_info.SetToolTip(adamLectura_pic, "Lectura Adam OK");
                }

                adam_func.AdamOutputRead(adam6060);
                if (Program.AdamOutputErrorRead)
                {
                    adamLectura_pic.Image = Properties.Resources.circle_error;
                    toolTip_info.SetToolTip(adamLectura_pic, "Error al leer Salidas Adam");
                }
                else
                {
                    adamLectura_pic.Image = Properties.Resources.circle_ok;
                    toolTip_info.SetToolTip(adamLectura_pic, "Lectura Adam OK");
                }
            }
            else
            {
                adamOnline_pic.Image = Properties.Resources.circle_error;
                toolTip_info.SetToolTip(adamOnline_pic, "Adam Offline");
                adamLectura_pic.Image = Properties.Resources.circle_error;
                toolTip_info.SetToolTip(adamLectura_pic, "Adam Offline");
            }
        }
        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracionSistemaForm form = new ConfiguracionSistemaForm();
            form.ShowDialog();
        }

        private void printerAdamStatusRead_timer_Tick(object sender, EventArgs e)
        {
            Program.loopBrazoLecturaAnterior = Program.LoopBrazoEntrada;
            printerAdamStatusRead_timer.Enabled = false;
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            printerAdamStatusRead_timer.Enabled = true;

        }
        private void ReadDevices()
        {
            ReadPrinterStatus();
            readAdamStatus();
            if (Program.loopBrazoLecturaAnterior == true && Program.LoopBrazoEntrada == false)
            {
                Program.CarPassed = true;
                
            }
           
            CondicionesGenerarTicketEntrada();        
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Program.adamOnline = adam_func.connectAdam(adam6060, adamip, adamport);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ReadDevices();
        }

        private void CondicionesGenerarTicketEntrada()
        {
            if (Program.PushButton && !Program.PushButtonPressed )
            {
                if (Program.LoopTicketEntrada || Properties.Settings.Default.ByPassLoopEntrada)
                {
                    Program.PushButtonPressed = true;
                    GenerarTicketEntrada();
                }
                else
                {
                    if (Program.CarPassed)
                    {
                        Program.PushButtonPressed = false;
                        Program.CarPassed = false;
                    }
                    
                }
            }            
        }

        private void GenerarTicketEntrada()
        {
            if (!Program.printerPrinting)
            {
                // if ticket printed correctly
                AbrirBrazoEntrada();
            } 
        }

        private void AbrirBrazoEntrada()
        {
            adam_func.AdamWrite(adam6060, 17, true);
            PulsoAbrirBrazoEntrada_timer.Enabled = true;
        }

        private void PulsoAbrirBrazoEntrada_timer_Tick(object sender, EventArgs e)
        {
            adam_func.AdamWrite(adam6060, 17, false);
            PulsoAbrirBrazoEntrada_timer.Enabled = false;
        }

        private void ImprimirTicket()
        {
            string fecha = DateTime.Now.ToString();
            string hora = DateTime.Now.ToString("HH:mm:ss");
            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBox1.Image = barcode.Draw(10+ "-" + fecha + "-" + hora, 50);
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            DatosTicket D = new DatosTicket();
            D.Estacion = "10";
            D.Fecha = Convert.ToDateTime(fecha);
            D.Hora = TimeSpan.Parse(hora);
            D.Pic = ms.ToArray();
            D.RegistrarTicket();
        }

        private void iMPRESIÓNMANUALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImprimirTicket();
            frmTicket obj = new frmTicket();
            obj.ShowDialog();
        }
    }
}
