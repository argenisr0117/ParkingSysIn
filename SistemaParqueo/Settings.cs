using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SistemaParqueo
{
    class Settings
    {
        private Conexion C = new Conexion();

        string MentSal;
        string MdefaultPrinter;
        bool MbyPassLoop;
        bool MbyPassBrazo;
        bool MbyPassAdam;
        bool MbyPassPapelPresenter;
        string MadamIp;
        int MadamPort;
        string MestacionNombre;
        string MestacionNumero;
        string MestacionAnterior;
        string MinputLoop;
        string MinputPushButton;
        string MinputLoopBrazo;
        string MoutputAbrirBrazo;




        public string EntSal
        {
            get { return MentSal; }
            set { MentSal = value; }
        }
        public string defaultprinter
        {
            get { return MdefaultPrinter; }
            set { MdefaultPrinter = value; }
        }

        public bool byPassloop
        {
            get { return MbyPassLoop; }
            set { MbyPassLoop = value; }
        }

        public bool byPassBrazo
        {
            get { return MbyPassBrazo; }
            set { MbyPassBrazo = value; }
        }

        public bool byPassAdam
        {
            get { return MbyPassAdam; }
            set { MbyPassAdam = value; }
        }

        public string adamIp
        {
            get { return MadamIp; }
            set { MadamIp = value; }
        }

        public int adamPort
        {
            get { return MadamPort; }
            set { MadamPort = value; }
        }
        public string estacionNombre
        {
            get { return MestacionNombre; }
            set { MestacionNombre = value; }
        }

        public string estacionNumero
        {
            get { return MestacionNumero; }
            set { MestacionNumero = value; }
        }

        public string estacionAnterior
        {
            get { return MestacionAnterior; }
            set { MestacionAnterior = value; }
        }

        public string InputLoop
        {
            get { return MinputLoop; }
            set {MinputLoop = value; }
        }

        public string InputPushButton
        {
            get { return MinputPushButton; }
            set { MinputPushButton = value; }
        }

        public string InputLoopBrazo
        {
            get { return MinputLoopBrazo; }
            set { MinputLoopBrazo = value; }
        }

        public string OutputAbrirBrazo
        {
            get { return MoutputAbrirBrazo; }
            set { MoutputAbrirBrazo = value; }
        }

        public bool byPassPaperPresenter
        {
            get { return MbyPassPapelPresenter; }
            set { MbyPassPapelPresenter = value; }
        }


        public bool SaveSettings()
        {

            List<clsParametros> lst = new List<clsParametros>();
            lst.Add(new clsParametros("@mensaje", "", SqlDbType.Bit, ParameterDirection.Output, 50));
            lst.Add(new clsParametros("@entrada_salida", MentSal));
            lst.Add(new clsParametros("@defaultPrinter", MdefaultPrinter));
            lst.Add(new clsParametros("@bypassAdam", MbyPassAdam));
            lst.Add(new clsParametros("@byPassLoop", MbyPassLoop));
            lst.Add(new clsParametros("@bypassBrazo", MbyPassBrazo));
            lst.Add(new clsParametros("@adamIp", MadamIp));
            lst.Add(new clsParametros("@adamPort", MadamPort));
            lst.Add(new clsParametros("@estacionNombre", MestacionNombre));
            lst.Add(new clsParametros("@estacionNumero", MestacionNumero));
            lst.Add(new clsParametros("@estacionAnterior", MestacionAnterior));
            lst.Add(new clsParametros("@inputLoop", MinputLoop));
            lst.Add(new clsParametros("@inputPushButton", MinputPushButton));
            lst.Add(new clsParametros("@inputLoopBrazo", MinputLoopBrazo));
            lst.Add(new clsParametros("@outputAbrirBrazo", MoutputAbrirBrazo));
            lst.Add(new clsParametros("@byPassPaperPresenter", MbyPassPapelPresenter));

            C.EjecutarSP("SAVE_SETTINGS", ref lst);
            bool mensaje = Convert.ToBoolean(lst[0].Valor);
            return mensaje;
        }
        public void GetSettings()
        {
            DataTable dt = new DataTable();
            List<clsParametros> lst = new List<clsParametros>();
            lst.Add(new clsParametros("@estacion", MestacionNumero));
            lst.Add(new clsParametros("@entrada_salida", MentSal));
            dt = C.Listado("GET_SETTINGS", lst);
            Program.defaultprinter = dt.Rows[0]["defaultPrinter"].ToString();
            Program.byPassLoopEntrada = Convert.ToBoolean(dt.Rows[0]["byPassLoopEntrada"]);
            Program.byPassBrazo = Convert.ToBoolean(dt.Rows[0]["byPassBrazoEntrada"]);
            Program.byPassAdam = Convert.ToBoolean(dt.Rows[0]["byPassAdam"]);
            Program.AdamIp = dt.Rows[0]["AdamIp"].ToString();
            Program.AdamPort = Convert.ToInt16(dt.Rows[0]["AdamPort"]);
            Program.EstacionNombre = dt.Rows[0]["EstacionNombre"].ToString();
            Program.EstacionNumero = dt.Rows[0]["EstacionNumero"].ToString();
            Properties.Settings.Default.Estacion = Program.EstacionNumero;
            Program.SuperUserPass = dt.Rows[0]["SuperUserPass"].ToString();
            
            Program.LoopEntradaInput = dt.Rows[0]["InputLoopEntrada"].ToString();
            Program.PushButtonInput = dt.Rows[0]["InputPushButton"].ToString();
            Program.LoopBrazoInput = dt.Rows[0]["InputLoopBrazo"].ToString();
            Program.AbrirBrazoOutput = dt.Rows[0]["OutputAbrirBrazo"].ToString();
            Program.byPassPapelPresenter = Convert.ToBoolean(dt.Rows[0]["byPassPaperPresenter"]);
        }

        public DataTable GetEstaciones()
        {
            DataTable dt = new DataTable();
            List<clsParametros> lst = new List<clsParametros>();
            lst.Add(new clsParametros("@entrada_salida", MentSal));
            return dt = C.Listado("GET_ESTACIONES", lst);
        }

        public bool CheckIfSoftwareActivated()
        {
            bool mensaje;
            List<clsParametros> lst = new List<clsParametros>();
            lst.Add(new clsParametros("@mensaje", "", SqlDbType.Bit, ParameterDirection.Output, 50));
            C.EjecutarSP("GET_IF_SOFTWARE_ACTIVATED", ref lst);
            mensaje = Convert.ToBoolean(lst[0].Valor);
            return mensaje;
        }
    }
}
