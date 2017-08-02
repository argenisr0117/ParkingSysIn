using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParqueo
{
    class UpdateStatusOnDB
    {
        private Conexion C = new Conexion();

        bool MprinterOffline;
        bool MprinterPaperJammed;
        bool MprinterOutOfPaper;
        bool MprinterDoorOpened;
        bool MprinterPrinting;
        bool MadamOnline;
        bool MadamInput1;
        bool MadamInput2;
        bool MadamInput3;
        bool MadamInput4;
        bool MadamInput5;
        bool MadamInput6;
        DateTime MupdateDate;
 
        

        public bool printerOffline
        {
            get { return MprinterOffline; }
            set { MprinterOffline = value; }
        }
        public bool printerPaperJammed
        {
            get { return MprinterPaperJammed; }
            set { MprinterPaperJammed = value; }
        }

        public bool printerOutOfPaper
        {
            get { return MprinterOutOfPaper; }
            set { MprinterOutOfPaper = value; }
        }

        public bool printerDoorOpened
        {
            get { return MprinterDoorOpened; }
            set { MprinterDoorOpened = value; }
        }

        public bool printerPrinting
        {
            get { return MprinterPrinting; }
            set { MprinterPrinting = value; }
        }

        public bool adamOnline
        {
            get { return MadamOnline; }
            set { MadamOnline = value; }
        }

        public bool adamInput1
        {
            get { return MadamInput1; }
            set { MadamInput1 = value; }
        }

        public bool adamInput2
        {
            get { return MadamInput2; }
            set { MadamInput2 = value; }
        }

        public bool adamInput3
        {
            get { return MadamInput3; }
            set { MadamInput3 = value; }
        }

        public bool adamInput4
        {
            get { return MadamInput4; }
            set { MadamInput4 = value; }
        }

        public bool adamInput5
        {
            get { return MadamInput5; }
            set { MadamInput5 = value; }
        }

        public bool adamInput6
        {
            get { return MadamInput6; }
            set { MadamInput6 = value; }
        }


        public DateTime updateDate
        {
            get { return MupdateDate; }
            set { MupdateDate = value; }
        }

        
        public void UpdateStatus()
        {
            //string mensaje = "";
            List<clsParametros> lst = new List<clsParametros>();
            lst.Add(new clsParametros("@p_offline", MprinterOffline));
            lst.Add(new clsParametros("@p_paperjammed", MprinterPaperJammed));
            lst.Add(new clsParametros("@p_outofpaper", MprinterOutOfPaper));
            lst.Add(new clsParametros("@p_dooropened", MprinterDoorOpened));
            lst.Add(new clsParametros("@p_printing", MprinterPrinting));
            lst.Add(new clsParametros("@a_online", MadamOnline));
            lst.Add(new clsParametros("@a_input1", MadamInput1));
            lst.Add(new clsParametros("@a_input2", MadamInput2));
            lst.Add(new clsParametros("@a_input3", MadamInput3));
            lst.Add(new clsParametros("@a_input4", MadamInput4));
            lst.Add(new clsParametros("@a_input5", MadamInput5));
            lst.Add(new clsParametros("@a_input6", MadamInput6));
            lst.Add(new clsParametros("@dateupdated", MupdateDate));
            //lst.Add(new clsParametros("@mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
            C.EjecutarSP("updateStatusEntrada", ref lst);
            //mensaje = lst[2].Valor.ToString();
            //return mensaje;
        }
    }
}
