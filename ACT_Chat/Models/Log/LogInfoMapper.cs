using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT_Chat.Models.Log
{
    public static class LogInfoMapper
    {

        public static LogInfo ToLogInfo(this LogLineEventArgs logLineEvent)
            => new LogInfo
            {
                LogLine = logLineEvent.logLine,
                TimeStamp = logLineEvent.detectedTime
            };
    }
}
