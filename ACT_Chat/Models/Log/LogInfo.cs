using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT_Chat.Models.Log
{
    public class LogInfo
    {
        public LogInfo(string logLine, DateTime? timeStamp)
        {
            LogLine = logLine;
            TimeStamp = timeStamp;

            if(logLine.ToUpper().Contains(":000D:") || logLine.Contains(":000C:"))
            {
                Type = LogLineType.TellMessage;
            }
        }

        public LogInfo()
        {
        }

        public string LogLine { get; set; }
        public DateTime? TimeStamp { get; set; }
        public LogLineType Type { get; set; }
    }
}
