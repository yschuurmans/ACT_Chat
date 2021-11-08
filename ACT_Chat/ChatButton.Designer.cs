namespace ACT_Chat
{
    partial class ChatButton
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
            this.btn_OpenChat = new System.Windows.Forms.Button();
            this.lbl_MessageCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_OpenChat
            // 
            this.btn_OpenChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OpenChat.BackgroundImage = global::ACT_Chat.Properties.Resources.chat_icon_png_8;
            this.btn_OpenChat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_OpenChat.Location = new System.Drawing.Point(0, 0);
            this.btn_OpenChat.Name = "btn_OpenChat";
            this.btn_OpenChat.Size = new System.Drawing.Size(50, 50);
            this.btn_OpenChat.TabIndex = 0;
            this.btn_OpenChat.UseVisualStyleBackColor = true;
            this.btn_OpenChat.Click += new System.EventHandler(this.btn_OpenChat_Click);
            this.btn_OpenChat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_OpenChat_MouseDown);
            this.btn_OpenChat.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_OpenChat_MouseMove);
            this.btn_OpenChat.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_OpenChat_MouseUp);
            // 
            // lbl_MessageCount
            // 
            this.lbl_MessageCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_MessageCount.AutoSize = true;
            this.lbl_MessageCount.BackColor = System.Drawing.Color.Firebrick;
            this.lbl_MessageCount.ForeColor = System.Drawing.Color.White;
            this.lbl_MessageCount.Location = new System.Drawing.Point(30, 10);
            this.lbl_MessageCount.Name = "lbl_MessageCount";
            this.lbl_MessageCount.Size = new System.Drawing.Size(16, 13);
            this.lbl_MessageCount.TabIndex = 1;
            this.lbl_MessageCount.Text = "-1";
            this.lbl_MessageCount.Visible = false;
            // 
            // ChatButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(50, 50);
            this.Controls.Add(this.lbl_MessageCount);
            this.Controls.Add(this.btn_OpenChat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(50, 50);
            this.Name = "ChatButton";
            this.Text = "ChatButton";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OpenChat;
        private System.Windows.Forms.Label lbl_MessageCount;
    }
}