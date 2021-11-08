using ACT_Chat.Models.Log;
using System;
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
            DateTime timestamp = logInfo.TimeStamp ?? DateTime.Parse(matches.Groups[1].Value);


            if (logline.Contains(":000c:"))
                type = MessageType.SentTell;
            if (logline.Contains(":000d:"))
                type = MessageType.ReceivedTell;

            return new ChatMessage
            {
                RawMessage = logInfo.LogLine,
                TimeStamp = timestamp,
                Target = new Player(matches.Groups[3].Value, DefaultWorld),
                Message = matches.Groups[4].Value,
                Type = type
            };
        }
    }
}
