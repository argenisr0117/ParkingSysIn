using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advantech.Adam;
using Advantech.Common;
using Advantech.Protocol;
using System.Net.Sockets;

namespace SistemaParqueo
{
    static class Program
    {
        public static AdamSocket adam6060 = new AdamSocket();
        public static AdamDevice adam_func = new AdamDevice();
        public static bool printerPrinting;
        public static bool printerBusy;
        public static bool printerPaperJammed;
        public static bool printerOutOfPaper;
        public static bool printerDoorOpened;
        public static bool printerOffline;
        public static string printerQuequeStatus;

        public static bool adamOnline;
        public static bool PushButtonPressed;
        public static bool TicketStillOnPrinter = true;
        public static bool PrinterFinishedFlag = false;
        public static bool SendJobToPrinterFlag;
        public static bool SendPulseToOpenArmFlag;
        public static bool TicketRetiredFlag;
        public static bool CarPassed;
        public static bool loopBrazoLecturaAnterior;
        

        public static bool PushButton; //Input 1
        public static bool LoopTicketEntrada; // Input 2
        public static bool LoopBrazoEntrada; // Input 3
        public static bool AdamInput4; 
        public static bool AdamInput5;
        public static bool AdamInput6;
        public static bool AdamInputErrorRead; 

        public static bool AbrirBrazoEntrada; // Abrir brazo entrada
        public static bool AdamOutput2; 
        public static bool AdamOutput3;
        public static bool AdamOutput4;
        public static bool AdamOutput5;
        public static bool AdamOutput6;
        public static bool AdamOutputErrorRead;



        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ScreenMonitorForm());
        }
    }
}
