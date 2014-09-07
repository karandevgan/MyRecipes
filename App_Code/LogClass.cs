using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// This helper class contains a function which writes error in the log file
/// </summary>

public class LogClass
{
    static public void WriteLog(string LogText)
    {
        StreamWriter log;

        if (!File.Exists(@"~\AdminFiles\logfile.txt"))
        {
            log = new StreamWriter(@"~\AdminFiles\logfile.txt");
        }
        else
        {
            log = File.AppendText(@"~\AdminFiles\logfile.txt");
        }

        // Write to the file:
        log.WriteLine("--------------------------------------------------------------");
        log.WriteLine("--------------------------------------------------------------");
        log.WriteLine(DateTime.Now);
        log.WriteLine();
        log.WriteLine(LogText);
        log.WriteLine();
        log.WriteLine("--------------------------------------------------------------");
        log.WriteLine("--------------------------------------------------------------");
        
        // Close the stream:
        log.Close();
    }
}