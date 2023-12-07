using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCheck.Model
{
    public class Config
    {
        public DataBase DataBase { get; set; }
        public TimmerConfig TimmerConfig { get; set; }
        public LogFile LogFile { get; set; }
    }
    public class DataBase
    {
        public string ConnectionString { get; set; }
    }
    public class TimmerConfig
    {
        public int TimerCheck { get; set; }
        public int TimerUpdateUI { get; set; }
    }
    public class LogFile
    {
        public string FilePathOK { get; set; }
        public string FilePathNG { get; set; }
    }
}
