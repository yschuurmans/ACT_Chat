
namespace ACT_Chat
{
    partial class ChatWindow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_Chatbox = new System.Windows.Forms.TextBox();
            this.tb_ChatInput = new System.Windows.Forms.TextBox();
            this.btn_LoadHistory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_Chatbox
            // 
            this.tb_Chatbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Chatbox.Location = new System.Drawing.Point(13, 41);
            this.tb_Chatbox.MaxLength = 999999999;
            this.tb_Chatbox.Multiline = true;
            this.tb_Chatbox.Name = "tb_Chatbox";
            this.tb_Chatbox.ReadOnly = true;
            this.tb_Chatbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Chatbox.Size = new System.Drawing.Size(359, 178);
            this.tb_Chatbox.TabIndex = 0;
            // 
            // tb_ChatInput
            // 
            this.tb_ChatInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_ChatInput.Location = new System.Drawing.Point(12, 229);
            this.tb_ChatInput.Name = "tb_ChatInput";
            this.tb_ChatInput.Size = new System.Drawing.Size(360, 20);
            this.tb_ChatInput.TabIndex = 1;
            this.tb_ChatInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ChatInput_KeyPress);
            // 
            // btn_LoadHistory
            // 
            this.btn_LoadHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_LoadHistory.AutoSize = true;
            this.btn_LoadHistory.Location = new System.Drawing.Point(293, 12);
            this.btn_LoadHistory.Name = "btn_LoadHistory";
            this.btn_LoadHistory.Size = new System.Drawing.Size(79, 23);
            this.btn_LoadHistory.TabIndex = 2;
            this.btn_LoadHistory.Text = "Load History";
            this.btn_LoadHistory.UseVisualStyleBackColor = true;
            this.btn_LoadHistory.Click += new System.EventHandler(this.btn_LoadHistory_Click);
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.btn_LoadHistory);
            this.Controls.Add(this.tb_ChatInput);
            this.Controls.Add(this.tb_Chatbox);
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "ChatWindow";
            this.Activated += new System.EventHandler(this.ChatWindow_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Chatbox;
        private System.Windows.Forms.TextBox tb_ChatInput;
        private System.Windows.Forms.Button btn_LoadHistory;
    }
}
