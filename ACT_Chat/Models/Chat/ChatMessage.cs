using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACT_Chat.Models.Chat
{
    public class ChatMessage
    {
        public Player Target { get; set; }
        public MessageType Type { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Unread { get; set; }

        public string RawMessage { get; set; }

        public override string ToString()
        {
            string typestring = Type == MessageType.ReceivedTell ? "000d" 
                : Type == MessageType.SentTell ? "000c" 
                : "0000";
            return $"[{TimeStamp.ToString("dd/MM/yyyy HH:mm:ss")}] 00:{typestring}:{Target.FullName}:{Message}";
        }
    }
}
