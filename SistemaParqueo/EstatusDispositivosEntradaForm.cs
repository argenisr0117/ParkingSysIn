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
    public partial class EstatusDispositivosEntradaForm : Form
    {
        
        AdamSocket adam6060 = new AdamSocket();
        AdamDevice adam_func = new AdamDevice();
        public string adamip = Properties.Settings.Default.AdamIp;
        public int adamport = Convert.ToInt16(Properties.Settings.Default.AdamPort);
        PrinterStatus printer = new PrinterStatus();

        public EstatusDispositivosEntradaForm()
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
                printer.PrinterState(Properties.Settings.Default.DefaultPrinter);  // Actualizar estatus printer

                if (Program.printerOffline)
                {
                    printerOnline_pic.Image = Properties.Resources.circle_error;
                    toolTip_info.SetToolTip(printerOnline_pic, Properties.Settings.Default.DefaultPrinter + " No está conectado o No es Printer por defecto");

                    printerStatus_pic.Image = Properties.Resources.circle_error;
                    toolTip_info.SetToolTip(printerStatus_pic, "Printer OFFLINE");

                    estadoPapel_pic.Image = Properties.Resources.circle_error;
                    toolTip_info.SetToolTip(estadoPapel_pic, "Printer OFFLINE");

                }
                else
                {
                    printerOnline_pic.Image = Properties.Resources.circle_ok;
                    toolTip_info.SetToolTip(printerOnline_pic, "Printer Online");

                    if (Program.printerDoorOpened)
                    {
                        printerStatus_pic.Image = Properties.Resources.circle_error;
                        toolTip_info.SetToolTip(printerStatus_pic, "Tapa del Printer Está abierta");
                    }
                    else
                    {
                        printerStatus_pic.Image = Properties.Resources.circle_ok;
                        toolTip_info.SetToolTip(printerStatus_pic, "Printer Status OK");
                    }


                    if (Program.printerOutOfPaper)
                    {
                        estadoPapel_pic.Image = Properties.Resources.circle_error;
                        toolTip_info.SetToolTip(estadoPapel_pic, "Printer No tiene Papel");
                    }
                    else if (Program.printerPaperJammed)
                    {
                        estadoPapel_pic.Image = Properties.Resources.circle_error;
                        toolTip_info.SetToolTip(estadoPapel_pic, "Papel Atascado");
                    }
                    else
                    {
                        estadoPapel_pic.Image = Properties.Resources.circle_ok;
                        toolTip_info.SetToolTip(estadoPapel_pic, "Papel OK");
                    }


                    if (Program.printerPrinting)
                    {
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
                        
                        notifyIcon1.Visible = false;

                    }
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
                //adam_func.AdamInputRead(adam6060);
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

                //adam_func.AdamOutputRead(adam6060);
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

        
        private void printerAdamStatusRead_timer_Tick(object sender, EventArgs e)
        {
            ReadPrinterStatus();
            readAdamStatus();

        }

    }
}
