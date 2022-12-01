using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class LogWriter
{
    static StreamWriter streamWriter;
    static LogWriter()
    {
        streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory+"/log.txt");
        streamWriter.AutoFlush= true;
    }
    public static void Write(string message)
    {
        DateTime dateTime= DateTime.Now;
        streamWriter.WriteLine(string.Format("Data:{0},Message:{1}", dateTime.ToShortTimeString(), message));
    }
}
