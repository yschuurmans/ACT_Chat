using ACT_Chat.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACT_Chat
{
    public partial class ChatButton : Form
    {
        private Point? mouseOffset = null;
        private Point? draggingStart = null;
        private bool isDragging = false;
        private int lastMessageCount = -1;

        public ChatButton()
        {
            InitializeComponent();
        }

        private void btn_OpenChat_Click(object sender, EventArgs e)
        {
            if (isDragging) return;
            Debug.Print("btn_OpenChat_Click");

            ACT_Chat.Instance.OpenChatList();
            this.Close();
        }

        private void btn_OpenChat_MouseDown(object sender, MouseEventArgs e)
        {
            Debug.Print("btn_OpenChat_MouseDown");
            var xOffset = this.Location.X - Cursor.Position.X;
            var yOffset = this.Location.Y - Cursor.Position.Y;
            mouseOffset = new Point(xOffset, yOffset);
            draggingStart = e.Location;
        }

        private void btn_OpenChat_MouseUp(object sender, MouseEventArgs e)
        {
            Debug.Print("btn_OpenChat_MouseUp");
            mouseOffset = null;
            draggingStart = null;
            isDragging = false;
        }

        private void btn_OpenChat_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseOffset == null) return;
            Debug.Print("btn_OpenChat_MouseMove");
            if (!isDragging && calculateDistanceSqrt(draggingStart.Value, e.Location) > 25)
            {
                isDragging = true;
            }
            if (isDragging)
            {
                this.Location = new Point(Cursor.Position.X + mouseOffset.Value.X, Cursor.Position.Y + mouseOffset.Value.Y);
            }
        }

        private int calculateDistanceSqrt(Point point1, Point point2)
        {
            return ((point2.X - point1.X) * (point2.X - point1.X)) + ((point2.Y - point1.Y) * (point2.Y - point1.Y));
        }

        public void SetMessageCount(int messageCount)
        {
            if (lastMessageCount == messageCount)
                return;
            Debug.Print("SetMessageCount");

            if (this.IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lbl_MessageCount.Visible = messageCount > 0;
                    lbl_MessageCount.Text = messageCount.ToString();
                    lastMessageCount = messageCount;

                    this.Refresh();
                });
            }
        }

        private void ChatButton_FormClosing(object sender, FormClosingEventArgs e)
        {
            Debug.Print("ChatButton_FormClosing");
            if (this.Location != null)
            {
                var simpleString = this.Location.ToSimpleString();
                ACT_Chat.Instance.config_tb_ChatButtonLoc.Text = simpleString;
            }
            ACT_Chat.Instance.ChatButton = null;
            this.Dispose();
        }
    }
}
