﻿
//-------------------------------
// ZebraUsbStream.cs
//-------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SistemaParqueo;
using Zebra.Printing;

using System.Printing;

namespace SistemaParqueo
{
    class ZebraUsbStream : Stream
    {
        UsbPrinterConnector usb;
        

        public ZebraUsbStream(string port)
        {
            
            usb = new UsbPrinterConnector(port);
            usb.IsConnected = true;
            base.ReadTimeout = usb.ReadTimeout;
            base.WriteTimeout = usb.WriteTimeout;
        }

        public ZebraUsbStream()
        {
           
            System.Collections.Specialized.NameValueCollection devs =
            UsbPrinterConnector.EnumDevices(true, true, false);


            if (devs.Count < 1)
                try
                {
                    throw new Exception("No Zebra printers found");

                }
                catch (Exception ex)
                {
                    Program.PrinterOffline = true;
                }
            else
            {
                Program.PrinterOffline = false;
                if (LocalPrintServer.GetDefaultPrintQueue().FullName != Program.defaultprinter)
                {
                    Program.PrinterOffline = true;
                }
                usb = new UsbPrinterConnector(devs[0].ToString());
                usb.IsConnected = true;
                
              
            }


        }


        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override bool CanTimeout
        {
            get { return true; }
        }

        public override void Flush()
        {
            ;
        }

        public override long Length
        {
            get { throw new NotSupportedException(); }
        }

        public override long Position
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (usb != null)
                return usb.Read(buffer, offset, count);
            else
            {
                //_form1.textBox1.Text = "Printer Desconectado";
                //_form1.textBox2.Text = "Printer Desconectado";
                return 0;

            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (usb != null)
            {
                Program.PrinterOffline= false;
                if (LocalPrintServer.GetDefaultPrintQueue().FullName != Program.defaultprinter)
                {
                    Program.PrinterOffline = true;
                }
                usb.Send(buffer, offset, count);
            }
                
            else
            {
                Program.PrinterOffline = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (usb != null)
                usb.IsConnected = false;
        }

        public override void Close()
        {
            base.Close();
            if (usb != null)
                if (usb.IsConnected)
                    usb.IsConnected = false;
        }

        public override int ReadTimeout
        {
            get
            {
                return usb.ReadTimeout;
            }
            set
            {
                usb.ReadTimeout = value;
            }
        }

        public override int WriteTimeout
        {
            get
            {
                return usb.WriteTimeout;
            }
            set
            {
                usb.WriteTimeout = value;
            }
        }
    }
}
