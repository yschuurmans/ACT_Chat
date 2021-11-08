using ACT_Chat.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACT_Chat
{
    public partial class ChatList : Form
    {
        private Dictionary<string, ChatWindow> _openChatWindows;

        public ChatList()
        {
            InitializeComponent();

            cb_MinimizeOnClose.Checked = ACT_Chat.Instance.config_cb_MinimizeOnClose.Checked;

            _openChatWindows = ACT_Chat.Instance.OpenChatWindows;

            lb_recentTells.DrawMode = DrawMode.OwnerDrawFixed;
        }

        private void lb_recentTells_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || lb_recentTells.Items.Count <= 0)
                return;

            Font f = e.Font;
            string label = lb_recentTells.Items[e.Index].ToString();
            if (ACT_Chat.Instance.Manager.HasUnreadMessages(label)) //TODO: Your condition to make text bold
                f = new Font(e.Font, FontStyle.Bold);
            e.DrawBackground();
            e.Graphics.DrawString(((ListBox)(sender)).Items[e.Index].ToString(), f, new SolidBrush(e.ForeColor), e.Bounds);
            e.DrawFocusRectangle();
        }

        private void ChatList_Load(object sender, EventArgs e)
        {
            foreach (var name in ACT_Chat.Instance.Manager.SavedChatMessages.Keys)
            {
                lb_recentTells.Items.Add(name);
            }
        }

        private void lb_recentTells_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_recentTells.SelectedItem != null)
            {
                btn_openChat.Enabled = true;
            }
            else
            {
                btn_openChat.Enabled = false;
            }
        }

        internal void AddNameToList(string fullName)
        {
            if(lb_recentTells.Items.Contains(fullName))
            {
                lb_recentTells.Items.Remove(fullName);
            }
            lb_recentTells.Items.Insert(0, fullName);
        }

        private void btn_openChat_Click(object sender, EventArgs e)
        {
            var targetedPerson = lb_recentTells.SelectedItem.ToString();
            if (_openChatWindows.ContainsKey(targetedPerson))
            {
                if (_openChatWindows[targetedPerson] == null || _openChatWindows[targetedPerson].IsDisposed)
                {
                    _openChatWindows.Remove(targetedPerson);
                }
                else
                {
                    _openChatWindows[targetedPerson].Show();
                    _openChatWindows[targetedPerson].WindowState = FormWindowState.Normal;
                    _openChatWindows[targetedPerson].Location = MousePosition;
                    return;
                }
            }


            ChatWindow view = new ChatWindow(targetedPerson, $"/tell {targetedPerson}");
            view.TopMost = true;
            view.Show();

            _openChatWindows.Add(targetedPerson, view);
            ACT_Chat.Instance.Manager.LoadAllMessagesToView(view);
        }

        private void btn_LoadHistory_Click(object sender, EventArgs e)
        {
            ACT_Chat.Instance.Manager.LoadChatTargetsFromFiles(this);
        }

        private void cb_MinimizeOnClose_CheckedChanged(object sender, EventArgs e)
        {
            ACT_Chat.Instance.config_cb_MinimizeOnClose.Checked = cb_MinimizeOnClose.Checked;
        }

        private void ChatList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Location != null)
            {
                ACT_Chat.Instance.config_tb_ChatListLoc.Text = this.Location.ToSimpleString();
            }

            if (cb_MinimizeOnClose.Checked)
            {
                ACT_Chat.Instance.OpenChatButton();
                this.Hide();
                e.Cancel = true;
            }
            FFXIVWindowManager.FocusProcess();
        }
    }
}
