using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Printing;
using System.Drawing.Printing;

namespace SistemaParqueo
{
    class PrinterStatus
    {
        public void PrinterState(string printerName)
        {
            
            var server = new LocalPrintServer();


            PrintQueue queue = server.DefaultPrintQueue;
            

            if (queue.FullName.ToString() == printerName)
            {
                Program.printerOffline = queue.IsOffline;
                Program.printerOutOfPaper = queue.IsOutOfPaper;
                Program.printerPaperJammed = queue.IsPaperJammed;
                Program.printerQuequeStatus = queue.QueueStatus.ToString();
                Program.printerDoorOpened = queue.IsDoorOpened;
                Program.printerPrinting = queue.IsPrinting;    
            }

            else
            {
                Program.printerOffline = true;
            }

            
        }

        public void anotherPrinter()
        {
            string printerName = "Microsoft Print to PDF";
            string query = string.Format("SELECT * from Win32_Printer WHERE Name LIKE '%{0}'", printerName);

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            using (ManagementObjectCollection coll = searcher.Get())
            {
                try
                {
                    foreach (ManagementObject printer in coll)
                    {
                        foreach (PropertyData property in printer.Properties)
                        {
                            Console.WriteLine(string.Format("{0}: {1}", property.Name, property.Value));
                        }
                    }
                }
                catch (ManagementException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        
       
    }
}
