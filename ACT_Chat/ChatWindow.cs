using ACT_Chat.Models.Chat;
using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ACT_Chat
{
    public partial class ChatWindow : Form
    {
        public string CommandPrefix { get; set; }
        public string Target { get; set; }

        private bool hasPotentialUnreadMessages = true;

        public ChatWindow(string targetPerson, string commandPrefix)
        {
            InitializeComponent();
            this.TopMost = true;
            this.Text = targetPerson;
            Target = targetPerson;
            CommandPrefix = commandPrefix;
        }

        private void tb_ChatInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                Clipboard.SetText($"{CommandPrefix} {tb_ChatInput.Text}");
                e.Handled = true;
                AttemptSendMessage();

                tb_ChatInput.Text = "";

                this.BringToFront();
                tb_ChatInput.Focus();
            }
        }

        private void AttemptSendMessage()
        {
            FFXIVWindowManager.FocusProcess();
            Thread.Sleep(200);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(50);
            SendKeys.Send("^{v}");
            Thread.Sleep(50);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(50);
            FFXIVWindowManager.FocusProcess(Target);
        }

        public void AddChatMessage(ChatMessage message)
        {
            this.Invoke((MethodInvoker)delegate {
                var prefix = message.Type == MessageType.SentTell ? ">> " : "  <<  ";

                tb_Chatbox.AppendText($"{Environment.NewLine}[{message.TimeStamp.ToString("HH:mm")}]{prefix}{message.Message}");
                hasPotentialUnreadMessages = true;
            });

        }

        private void btn_LoadHistory_Click(object sender, EventArgs e)
        {
            tb_Chatbox.Text = "";
            ACT_Chat.Instance.Manager.LoadChatFromFile(this);
        }

        private void ChatWindow_Activated(object sender, EventArgs e)
        {
            if (!hasPotentialUnreadMessages) return;
            
            ACT_Chat.Instance.Manager.MarkAsRead(Target);
            hasPotentialUnreadMessages = false;
        }
    }
}
