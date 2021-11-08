
namespace ACT_Chat
{
    partial class ChatList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_recentTells = new System.Windows.Forms.ListBox();
            this.btn_openChat = new System.Windows.Forms.Button();
            this.btn_LoadHistory = new System.Windows.Forms.Button();
            this.cb_MinimizeOnClose = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lb_recentTells
            // 
            this.lb_recentTells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_recentTells.FormattingEnabled = true;
            this.lb_recentTells.Location = new System.Drawing.Point(12, 41);
            this.lb_recentTells.Name = "lb_recentTells";
            this.lb_recentTells.Size = new System.Drawing.Size(210, 173);
            this.lb_recentTells.TabIndex = 6;
            this.lb_recentTells.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lb_recentTells_DrawItem);
            this.lb_recentTells.SelectedIndexChanged += new System.EventHandler(this.lb_recentTells_SelectedIndexChanged);
            // 
            // btn_openChat
            // 
            this.btn_openChat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_openChat.Enabled = false;
            this.btn_openChat.Location = new System.Drawing.Point(12, 226);
            this.btn_openChat.Name = "btn_openChat";
            this.btn_openChat.Size = new System.Drawing.Size(210, 23);
            this.btn_openChat.TabIndex = 5;
            this.btn_openChat.Text = "Open Chat Window";
            this.btn_openChat.UseVisualStyleBackColor = true;
            this.btn_openChat.Click += new System.EventHandler(this.btn_openChat_Click);
            // 
            // btn_LoadHistory
            // 
            this.btn_LoadHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_LoadHistory.AutoSize = true;
            this.btn_LoadHistory.Location = new System.Drawing.Point(146, 12);
            this.btn_LoadHistory.Name = "btn_LoadHistory";
            this.btn_LoadHistory.Size = new System.Drawing.Size(76, 23);
            this.btn_LoadHistory.TabIndex = 7;
            this.btn_LoadHistory.Text = "Load History";
            this.btn_LoadHistory.UseVisualStyleBackColor = true;
            this.btn_LoadHistory.Click += new System.EventHandler(this.btn_LoadHistory_Click);
            // 
            // cb_MinimizeOnClose
            // 
            this.cb_MinimizeOnClose.AutoSize = true;
            this.cb_MinimizeOnClose.Location = new System.Drawing.Point(13, 13);
            this.cb_MinimizeOnClose.Name = "cb_MinimizeOnClose";
            this.cb_MinimizeOnClose.Size = new System.Drawing.Size(109, 17);
            this.cb_MinimizeOnClose.TabIndex = 8;
            this.cb_MinimizeOnClose.Text = "Minimize on close";
            this.cb_MinimizeOnClose.UseVisualStyleBackColor = true;
            this.cb_MinimizeOnClose.CheckedChanged += new System.EventHandler(this.cb_MinimizeOnClose_CheckedChanged);
            // 
            // ChatList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 261);
            this.Controls.Add(this.cb_MinimizeOnClose);
            this.Controls.Add(this.btn_LoadHistory);
            this.Controls.Add(this.lb_recentTells);
            this.Controls.Add(this.btn_openChat);
            this.MinimumSize = new System.Drawing.Size(230, 173);
            this.Name = "ChatList";
            this.Text = "ChatList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatList_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChatList_FormClosed);
            this.Load += new System.EventHandler(this.ChatList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_recentTells;
        private System.Windows.Forms.Button btn_openChat;
        private System.Windows.Forms.Button btn_LoadHistory;
        private System.Windows.Forms.CheckBox cb_MinimizeOnClose;
    }
}