using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SistemaParqueo
{
    public class DatosTicket
    {
        private Conexion C = new Conexion();

        string Mestacion;
        string Mbarcode;
        DateTime Mfecha;
        TimeSpan Mhora;
        byte[] Mpic;
        string MtipoTicket;

        public string Estacion
        {
            get { return Mestacion; }
            set { Mestacion = value; }
        }
        public string Barcode
        {
            get { return Mbarcode; }
            set { Mbarcode = value; }
        }

        public DateTime Fecha
        {
            get { return Mfecha; }
            set { Mfecha = value; }
        }

        public TimeSpan Hora
        {
            get { return Mhora; }
            set { Mhora = value; }
        }
        public byte[] Pic
        {
            get { return Mpic; }
            set { Mpic = value; }
        }

        public string tipoTicket
        {
            get { return MtipoTicket; }
            set { MtipoTicket = value; }
        }

        public void RegistrarTicket()
        {
            //string mensaje = "";
            List<clsParametros> lst = new List<clsParametros>();
            lst.Add(new clsParametros("@estacion", Mestacion));
            lst.Add(new clsParametros("@fecha", Mfecha));
            lst.Add(new clsParametros("@hora", Mhora));
            lst.Add(new clsParametros("@barcode", Mbarcode));
            lst.Add(new clsParametros("@image", Mpic));
            lst.Add(new clsParametros("@tipoTicket", MtipoTicket));
            //lst.Add(new clsParametros("@mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
            C.EjecutarSP("INS_TICKET", ref lst);
            //mensaje = lst[2].Valor.ToString();
            //return mensaje;
        }
    }
}
