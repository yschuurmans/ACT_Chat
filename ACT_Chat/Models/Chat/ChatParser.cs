using ACT_Chat.Models.Log;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ACT_Chat.Models.Chat
{
    public class ChatParser
    {


        private readonly Regex regex = new Regex(@"\[(.*)\] 00:(....):(.*?):(.*)");

        public ChatParser(Worlds defaultWorld)
        {
            DefaultWorld = defaultWorld;
        }

        public Worlds DefaultWorld { get; set; }

        public ChatMessage Parse(LogInfo logInfo)
        {
            string logline = logInfo.LogLine;
            var matches = regex.Match(logline);
            MessageType type = MessageType.Unknown;
            DateTime timestamp = DateTime.Now;
            if(logInfo.TimeStamp != null)
            {
                timestamp = (DateTime)logInfo.TimeStamp;
            } 
            else if (DateTime.TryParseExact(matches.Groups[1].Value, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out DateTime exactTs))
            {
                timestamp = exactTs;
            }
            else if (DateTime.TryParse(matches.Groups[1].Value, out DateTime parseTs))
            {
                timestamp = parseTs;
            }

            if (logline.Contains(":000c:"))
                type = MessageType.SentTell;
            if (logline.Contains(":000d:"))
                type = MessageType.ReceivedTell;

            return new ChatMessage
            {
                RawMessage = logInfo.LogLine,
                TimeStamp = (DateTime)timestamp,
                Target = new Player(matches.Groups[3].Value, DefaultWorld),
                Message = matches.Groups[4].Value,
                Type = type
            };
        }
    }
}
