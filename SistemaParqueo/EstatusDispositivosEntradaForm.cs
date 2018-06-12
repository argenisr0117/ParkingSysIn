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
        public string adamip = Program.AdamIp;
        public int adamport = Convert.ToInt16(Program.AdamPort);
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
                Program.P.CheckPrinterStatus();  // Actualizar estatus printer

                if (Program.PrinterOffline)
                {
                    printerOnline_pic.Image = Properties.Resources.circle_error;
                    toolTip_info.SetToolTip(printerOnline_pic, Program.defaultprinter + " No está conectado o No es Printer por defecto");

                    printerStatus_pic.Image = Properties.Resources.circle_error;
                    toolTip_info.SetToolTip(printerStatus_pic, "Printer OFFLINE");

                    estadoPapel_pic.Image = Properties.Resources.circle_error;
                    toolTip_info.SetToolTip(estadoPapel_pic, "Printer OFFLINE");

                }
                else
                {
                    printerOnline_pic.Image = Properties.Resources.circle_ok;
                    toolTip_info.SetToolTip(printerOnline_pic, "Printer Online");

                    if (Program.printerHeadOpen)
                    {
                        printerStatus_pic.Image = Properties.Resources.circle_error;
                        toolTip_info.SetToolTip(printerStatus_pic, "Tapa del Printer Está abierta");
                    }
                    else if (Program.printerCutterFault)
                    {
                        printerStatus_pic.Image = Properties.Resources.circle_error;
                        toolTip_info.SetToolTip(printerStatus_pic, "Error cortador de Papel");
                    }
                    else if (Program.printerHeadTemperature)
                    {
                        printerStatus_pic.Image = Properties.Resources.circle_error;
                        toolTip_info.SetToolTip(printerStatus_pic, "Alta temperatura en Cabezal");
                    }

                    else if (Program.printerHeadThermistorOpen)
                    {
                        printerStatus_pic.Image = Properties.Resources.circle_error;
                        toolTip_info.SetToolTip(printerStatus_pic, "Termistor Cabezal Abierto");
                    }

                    else if (Program.printerPaused)
                    {
                        printerStatus_pic.Image = Properties.Resources.circle_error;
                        toolTip_info.SetToolTip(printerStatus_pic, "Printer Pausado");
                    }

                    else if (Program.printerPresenterNotRunning)
                    {
                        printerStatus_pic.Image = Properties.Resources.circle_error;
                        toolTip_info.SetToolTip(printerStatus_pic, "Presenter no esta avanzando");
                    }

                    else if (Program.printerError)
                    {
                        printerStatus_pic.Image = Properties.Resources.circle_error;
                        toolTip_info.SetToolTip(printerStatus_pic, "Error en Printer (general)");
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

                    else if (Program.printerPaperFeedError)
                    {
                        estadoPapel_pic.Image = Properties.Resources.circle_error;
                        toolTip_info.SetToolTip(estadoPapel_pic, "Error Alimentador de Papel");
                    }


                    else
                    {
                        estadoPapel_pic.Image = Properties.Resources.circle_ok;
                        toolTip_info.SetToolTip(estadoPapel_pic, "Papel OK");
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
