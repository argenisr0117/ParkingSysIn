using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Zebra.Printing;

namespace SistemaParqueo
{
    class PrinterStatus
    {
        public void CheckPrinterStatus()
        {
            var printerStatusCommand = Encoding.GetEncoding(850).GetBytes(@"~HQES");
            try
            {
                var zebraConnection = new ZebraUsbStream();

                zebraConnection.Write(printerStatusCommand, 0, printerStatusCommand.Length);

                var statusReturn = new byte[800];
                var bytesRead = zebraConnection.Read(statusReturn, 0, 800);

                if (bytesRead >= 132)
                {
                    string stringResult = Encoding.Default.GetString(statusReturn.ToArray());
                    Console.WriteLine(stringResult);
                    stringResult = Regex.Replace(stringResult, "[^0-9.]", "");

                    if (stringResult[0].ToString() == "1") // flag printer error
                    {
                        Program.printerError = true;
                    }
                    else
                    {
                        Program.printerError = false;
                    }

                    if (stringResult[12].ToString() == "1") // flag printer Paused
                    {
                        Program.printerPaused = true;
                    }
                    else
                    {
                        Program.printerPaused = false;
                    }

                    if (stringResult[15].ToString() == "1") // flag printer Head Over temperature
                    {
                        Program.printerHeadTemperature = true;
                    }
                    else
                    {
                        Program.printerHeadTemperature = false;
                    }

                    if (stringResult[14].ToString() == "2") // flag printer Head Thermistor Open
                    {
                        Program.printerHeadThermistorOpen = true;
                    }
                    else
                    {
                        Program.printerHeadThermistorOpen = false;
                    }

                    if (stringResult[13].ToString() == "1") // flag printer Paper Jam
                    {
                        Program.printerPaperJammed = true;
                    }
                    else
                    {
                        Program.printerPaperJammed = false;
                    }

                    if (stringResult[16].ToString() == "1") // flag printer Out Of Paper
                    {
                        Program.printerOutOfPaper = true;
                    }
                    else
                    {
                        Program.printerOutOfPaper = false;
                    }

                    if (stringResult[16].ToString() == "4") // flag printer Head Open
                    {
                        Program.printerHeadOpen = true;
                    }
                    else
                    {
                        Program.printerHeadOpen = false;
                    }

                    if (stringResult[16].ToString() == "8") // flag printer Cutter Fault
                    {
                        Program.printerCutterFault = true;
                    }
                    else
                    {
                        Program.printerCutterFault = false;
                    }

                    if (stringResult[13].ToString() == "2") // flag printer Presenter Not Running
                    {
                        Program.printerPresenterNotRunning = true;
                    }
                    else
                    {
                        Program.printerPresenterNotRunning = false;
                    }

                    if (stringResult[12].ToString() == "4") // flag printer paper feed error
                    {
                        Program.printerPaperFeedError = true;
                    }
                    else
                    {
                        Program.printerPaperFeedError = false;
                    }

                    if (stringResult[31].ToString() == "7") // flag printer paper IN PRESENTER
                    {
                        Program.printerPaperInPresenter = true;
                    }
                    else
                    {
                        Program.printerPaperInPresenter = false;
                    }



                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

    }
}
