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

        public static string LoopEntradaInput;
        public static string LoopBrazoInput;
        public static string PushButtonInput;
        public static string AbrirBrazoOutput;

        public static string defaultprinter;
        public static bool byPassLoopEntrada;
        public static bool byPassAdam;
        public static bool byPassBrazo;
        public static bool byPassPapelPresenter;
        public static string AdamIp;
        public static int AdamPort;
        public static string EstacionNombre;
        public static string EstacionNumero;
        public static string SuperUserPass;

        public static AdamSocket adam6060 = new AdamSocket();
       
        public static AdamDevice adam_func = new AdamDevice();

        public static PrinterStatus P = new PrinterStatus();

        public static bool printerError;
        public static bool printerPaused;
        public static bool PrinterOffline;
        public static bool printerHeadTemperature;
        public static bool printerHeadThermistorOpen;
        public static bool printerPaperJammed;
        public static bool printerOutOfPaper;
        public static bool printerHeadOpen;
        public static bool printerCutterFault;
        public static bool printerPresenterNotRunning;
        public static bool printerPaperFeedError;
        public static bool printerPaperInPresenter;

        public static bool adamOnline;
        public static bool PushButtonPressed;
        public static bool PrinterFinishedFlag = false;
        public static bool SendJobToPrinterFlag;
        public static bool SendPulseToOpenArmFlag;

        public static bool PaperPresenterByPassFlag;

        public static bool CarPassed;
        public static bool loopBrazoLecturaAnterior;
        

        public static bool AdamInput1; //push
        public static bool AdamInput2; // ticket entrada
        public static bool AdamInput3; // Brazo Entrada
        public static bool AdamInput4; 
        public static bool AdamInput5;
        public static bool AdamInput6;
        public static bool AdamInputErrorRead; 

        public static bool AdamOutput1; // Abrir brazo entrada
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
