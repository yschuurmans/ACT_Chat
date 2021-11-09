using ACT_Chat.Models.Chat;
using ACT_Chat.Models.Log;
using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ACT_Chat.Logic
{
    public class ChatManager
    {

        public ChatManager(Worlds world)
        {
            ChatParser = new ChatParser(world);
            SavedChatMessages = new Dictionary<string, List<ChatMessage>>();
        }

        public Dictionary<string, List<ChatMessage>> SavedChatMessages { get; set; }
        public ChatParser ChatParser { get; set; }

        private string chatlogFolder = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "ACT_Chat");

        internal bool HasUnreadMessages(string label) =>
            SavedChatMessages.ContainsKey(label) && SavedChatMessages[label].Any(x => x.Unread);


        public void DistributeChatMessage(ChatMessage message)
        {
            if (!SavedChatMessages.ContainsKey(message.Target.FullName))
            {
                SavedChatMessages.Add(message.Target.FullName, new List<ChatMessage>());
            }
            SavedChatMessages[message.Target.FullName].Add(message);

            if (ACT_Chat.Instance.OpenChatWindows.ContainsKey(message.Target.FullName) && !ACT_Chat.Instance.OpenChatWindows[message.Target.FullName].IsDisposed)
            {
                ACT_Chat.Instance.OpenChatWindows[message.Target.FullName].AddChatMessage(message);
            }

            if(ACT_Chat.Instance.ChatList != null && !ACT_Chat.Instance.ChatList.IsDisposed)
            {
                ACT_Chat.Instance.ChatList.AddNameToList(message.Target.FullName);
            }
        }


        public void LoadAllMessagesToView(ChatWindow view)
        {
            if (!SavedChatMessages.ContainsKey(view.Target))
                return;

            foreach (ChatMessage item in SavedChatMessages[view.Target])
            {
                view.AddChatMessage(item);
            }
        }

        internal void UpdateDefaultWorld(Worlds world)
        {
            ChatParser.DefaultWorld = world;
        }

        internal void MarkAsRead(string target)
        {
            if (!SavedChatMessages.ContainsKey(target))
                return;

            SavedChatMessages[target]
                .Where(x => x.Unread).ToList()
                .ForEach(x => x.Unread = false);

            RefreshUnread();
        }

        internal void ProcessLogLine(LogInfo logline)
        {
            var message = ChatParser.Parse(logline);
            if (message.Type == MessageType.ReceivedTell)
                message.Unread = true;
            DistributeChatMessage(message);
            SaveMessageToFile(message);

            RefreshUnread();
        }

        private void RefreshUnread()
        {
            int amountUnread =
                SavedChatMessages
                .Where(x=>x.Value.Last().Unread)
                .SelectMany(x=>x.Value)
                .Where(x=>x.Unread)
                .Count();

            ACT_Chat.Instance?.ChatButton?.SetMessageCount(amountUnread);
        }

        private void SaveMessageToFile(ChatMessage message)
        {
            if (!Directory.Exists(chatlogFolder))
            {
                Directory.CreateDirectory(chatlogFolder);
            }
            string path = Path.Combine(chatlogFolder, $"{message.Target.FullName}.txt");

            if (File.Exists(path) && File.ReadAllLines(path).Last().Contains(message.Message))
                return;

            File.AppendAllText(path,
                Environment.NewLine + message.ToString());
        }

        public void LoadChatFromFile(ChatWindow view)
        {
            if (!Directory.Exists(chatlogFolder))
            {
                return;
            }
            if (!File.Exists(Path.Combine(chatlogFolder, $"{view.Target}.txt")))
            {
                return;
            }

            var allLines = File.ReadAllLines(Path.Combine(chatlogFolder, $"{view.Target}.txt"));
            foreach (string line in allLines)
            {
                if (line.Length <= 0) continue;

                var message = ChatParser.Parse(new LogInfo(line, null));
                view.AddChatMessage(message);
            }
        }

        public void LoadChatTargetsFromFiles(ChatList view)
        {
            if (!Directory.Exists(chatlogFolder))
            {
                return;
            }
            DirectoryInfo info = new DirectoryInfo(chatlogFolder);
            FileInfo[] files = info.GetFiles().OrderBy(p => p.LastWriteTime).ToArray();
            foreach (FileInfo file in files)
            {
                view.AddNameToList(file.Name.Replace(".txt", ""));
            }
        }
    }
}
