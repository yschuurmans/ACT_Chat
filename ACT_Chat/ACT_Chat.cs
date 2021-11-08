using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.IO;
using System.Reflection;
using System.Xml;
using ACT_FFXIV.Aetherbridge;
using ACT_Chat.ACT;
using ACT_Chat.Models.Chat;
using ACT_Chat.Models.Log;
using ACT_Chat.Logic;

[assembly: AssemblyTitle("ACT_Chat")]
[assembly: AssemblyDescription("ACT_Chat plugin, improving the FFXIV chat system one chatbox at a time")]
[assembly: AssemblyCompany("yschuurmans")]
[assembly: AssemblyVersion("0.1.0.0")]

namespace ACT_Chat
{
    public class ACT_Chat : UserControl, IActPluginV1
    {
        public CheckBox config_cb_MinimizeOnClose;
        public CheckBox config_cb_OpenOnStartup;
        public TextBox config_tb_ChatButtonLoc;
        public TextBox config_tb_ChatListLoc;

        private Button btn_OpenChatList;
        private Label lbl_CurrentWorldDesc;
        private TextBox tb_CurrentWorld;
        private Button btn_SpoofMsg;
        private Label lbl_Title;
        private Label lbl_Settings;

        #region Designer Created Code (Avoid editing)
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public static ACT_Chat Instance { get; private set; }

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
            this.lbl_Title = new System.Windows.Forms.Label();
            this.btn_OpenChatList = new System.Windows.Forms.Button();
            this.config_cb_OpenOnStartup = new System.Windows.Forms.CheckBox();
            this.lbl_CurrentWorldDesc = new System.Windows.Forms.Label();
            this.tb_CurrentWorld = new System.Windows.Forms.TextBox();
            this.config_cb_MinimizeOnClose = new System.Windows.Forms.CheckBox();
            this.btn_SpoofMsg = new System.Windows.Forms.Button();
            this.config_tb_ChatButtonLoc = new System.Windows.Forms.TextBox();
            this.lbl_Settings = new System.Windows.Forms.Label();
            this.config_tb_ChatListLoc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Location = new System.Drawing.Point(3, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(273, 13);
            this.lbl_Title.TabIndex = 0;
            this.lbl_Title.Text = "WIMFFF -- WoW Instant Messager but For Final Fantasy";
            // 
            // btn_OpenChatList
            // 
            this.btn_OpenChatList.Location = new System.Drawing.Point(6, 54);
            this.btn_OpenChatList.Name = "btn_OpenChatList";
            this.btn_OpenChatList.Size = new System.Drawing.Size(126, 23);
            this.btn_OpenChatList.TabIndex = 1;
            this.btn_OpenChatList.Text = "Open Chat List";
            this.btn_OpenChatList.UseVisualStyleBackColor = true;
            this.btn_OpenChatList.Click += new System.EventHandler(this.btn_OpenChatList_Click);
            // 
            // config_cb_OpenOnStartup
            // 
            this.config_cb_OpenOnStartup.AutoSize = true;
            this.config_cb_OpenOnStartup.Location = new System.Drawing.Point(6, 121);
            this.config_cb_OpenOnStartup.Name = "config_cb_OpenOnStartup";
            this.config_cb_OpenOnStartup.Size = new System.Drawing.Size(117, 17);
            this.config_cb_OpenOnStartup.TabIndex = 2;
            this.config_cb_OpenOnStartup.Text = "Open list on startup";
            this.config_cb_OpenOnStartup.UseVisualStyleBackColor = true;
            // 
            // lbl_CurrentWorldDesc
            // 
            this.lbl_CurrentWorldDesc.AutoSize = true;
            this.lbl_CurrentWorldDesc.Location = new System.Drawing.Point(6, 35);
            this.lbl_CurrentWorldDesc.Name = "lbl_CurrentWorldDesc";
            this.lbl_CurrentWorldDesc.Size = new System.Drawing.Size(75, 13);
            this.lbl_CurrentWorldDesc.TabIndex = 3;
            this.lbl_CurrentWorldDesc.Text = "Current World:";
            // 
            // tb_CurrentWorld
            // 
            this.tb_CurrentWorld.Enabled = false;
            this.tb_CurrentWorld.Location = new System.Drawing.Point(87, 32);
            this.tb_CurrentWorld.Name = "tb_CurrentWorld";
            this.tb_CurrentWorld.ReadOnly = true;
            this.tb_CurrentWorld.Size = new System.Drawing.Size(189, 20);
            this.tb_CurrentWorld.TabIndex = 5;
            this.tb_CurrentWorld.Text = "[NotDetectedYet]";
            // 
            // config_cb_MinimizeOnClose
            // 
            this.config_cb_MinimizeOnClose.AutoSize = true;
            this.config_cb_MinimizeOnClose.Location = new System.Drawing.Point(547, 322);
            this.config_cb_MinimizeOnClose.Name = "config_cb_MinimizeOnClose";
            this.config_cb_MinimizeOnClose.Size = new System.Drawing.Size(124, 17);
            this.config_cb_MinimizeOnClose.TabIndex = 6;
            this.config_cb_MinimizeOnClose.Text = "cb_MinimizeOnClose";
            this.config_cb_MinimizeOnClose.UseVisualStyleBackColor = true;
            this.config_cb_MinimizeOnClose.Visible = false;
            // 
            // btn_SpoofMsg
            // 
            this.btn_SpoofMsg.Location = new System.Drawing.Point(547, 345);
            this.btn_SpoofMsg.Name = "btn_SpoofMsg";
            this.btn_SpoofMsg.Size = new System.Drawing.Size(111, 23);
            this.btn_SpoofMsg.TabIndex = 7;
            this.btn_SpoofMsg.Text = "SpoofMessage";
            this.btn_SpoofMsg.UseVisualStyleBackColor = true;
            this.btn_SpoofMsg.Visible = false;
            this.btn_SpoofMsg.Click += new System.EventHandler(this.btn_SpoofMsg_Click);
            // 
            // config_tb_ChatButtonLoc
            // 
            this.config_tb_ChatButtonLoc.Location = new System.Drawing.Point(547, 275);
            this.config_tb_ChatButtonLoc.Name = "config_tb_ChatButtonLoc";
            this.config_tb_ChatButtonLoc.Size = new System.Drawing.Size(100, 20);
            this.config_tb_ChatButtonLoc.TabIndex = 8;
            this.config_tb_ChatButtonLoc.Visible = false;
            // 
            // lbl_Settings
            // 
            this.lbl_Settings.AutoSize = true;
            this.lbl_Settings.Location = new System.Drawing.Point(3, 105);
            this.lbl_Settings.Name = "lbl_Settings";
            this.lbl_Settings.Size = new System.Drawing.Size(45, 13);
            this.lbl_Settings.TabIndex = 9;
            this.lbl_Settings.Text = "Settings";
            // 
            // config_tb_ChatListLoc
            // 
            this.config_tb_ChatListLoc.Location = new System.Drawing.Point(547, 296);
            this.config_tb_ChatListLoc.Name = "config_tb_ChatListLoc";
            this.config_tb_ChatListLoc.Size = new System.Drawing.Size(100, 20);
            this.config_tb_ChatListLoc.TabIndex = 10;
            this.config_tb_ChatListLoc.Visible = false;
            // 
            // ACT_Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.config_tb_ChatListLoc);
            this.Controls.Add(this.lbl_Settings);
            this.Controls.Add(this.config_tb_ChatButtonLoc);
            this.Controls.Add(this.btn_SpoofMsg);
            this.Controls.Add(this.config_cb_MinimizeOnClose);
            this.Controls.Add(this.tb_CurrentWorld);
            this.Controls.Add(this.lbl_CurrentWorldDesc);
            this.Controls.Add(this.config_cb_OpenOnStartup);
            this.Controls.Add(this.btn_OpenChatList);
            this.Controls.Add(this.lbl_Title);
            this.Name = "ACT_Chat";
            this.Size = new System.Drawing.Size(686, 384);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        #endregion
        public ACT_Chat()
        {
            Instance = this;
            InitializeComponent();
            OpenChatWindows = new Dictionary<string, ChatWindow>();
        }

        Label lblStatus;    // The status label that appears in ACT's Plugin tab
        string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\ACT_Chat.config.xml");
        SettingsSerializer xmlSettings;

        private IACTWrapper _actWrapper;
        private IFFXIVACTPluginWrapper _ffxivACTPluginWrapper;

        public ChatManager Manager { get; set; }
        public Dictionary<string, ChatWindow> OpenChatWindows { get; set; }
        public ChatList ChatList { get; set; }
        public ChatButton ChatButton { get; set; }

        #region IActPluginV1 Members
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            lblStatus = pluginStatusText;   // Hand the status label's reference to our local var
            pluginScreenSpace.Controls.Add(this);   // Add this UserControl to the tab ACT provides
            this.Dock = DockStyle.Fill; // Expand the UserControl to fill the tab's client space
            xmlSettings = new SettingsSerializer(this); // Create a new settings serializer and pass it this instance
            LoadSettings();

            Init();

            // Create some sort of parsing event handler.  After the "+=" hit TAB twice and the code will be generated for you.
            //ActGlobals.oFormActMain.AfterCombatAction += new CombatActionDelegate(oFormActMain_AfterCombatAction);

            lblStatus.Text = "Plugin Started";
        }
        public void DeInitPlugin()
        {
            // Unsubscribe from any events you listen to when exiting!
            //ActGlobals.oFormActMain.AfterCombatAction -= oFormActMain_AfterCombatAction;
            DeInit();
            SaveSettings();
            lblStatus.Text = "Plugin Exited";
        }
        #endregion

        void Init()
        {
            // Init Services
            _actWrapper = ACTWrapper.GetInstance();
            FFXIVACTPluginWrapper.Initialize(_actWrapper);
            _ffxivACTPluginWrapper = FFXIVACTPluginWrapper.GetInstance();

            //Init Manager
            var savedWorld = World.FindWorld(tb_CurrentWorld.Text);
            if (savedWorld == null)
                tb_CurrentWorld.Text = "[NotDetectedYet]";
            Manager = new ChatManager(savedWorld ?? Worlds.Odin);

            //Register to Loglines
            ActGlobals.oFormActMain.OnLogLineRead += OnLogLineRead;

            //Time-unsensitive tasks
            if (config_cb_OpenOnStartup.Checked)
            {
                OpenChatButton();
            }

#if DEBUG
            btn_SpoofMsg.Visible = true;
            config_tb_ChatButtonLoc.Visible = true;
            config_cb_OpenOnStartup.Visible = true;
#endif
        }

        void DeInit()
        {
            ActGlobals.oFormActMain.OnLogLineRead -= OnLogLineRead;
            CloseAllWindows();
        }

        private void OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            var logline = new LogInfo(logInfo.logLine, logInfo.detectedTime);

            if (logline.Type == LogLineType.TellMessage)
            {
                UpdateCurrentWorld();
                Manager.ProcessLogLine(logline);
            }
        }

        public void UpdateCurrentWorld()
        {
            var player = _ffxivACTPluginWrapper.GetCurrentCombatant();
            if (tb_CurrentWorld.Text != player.WorldName)
            {
                tb_CurrentWorld.Text = player.WorldName;
                Manager.UpdateDefaultWorld(World.FindWorld(player.WorldName) ?? Worlds.Odin);
            }
        }

        void LoadSettings()
        {
            // Add any controls you want to save the state of
            //xmlSettings.AddControlSetting(textBox1.Name, textBox1);
            xmlSettings.AddControlSetting(config_cb_OpenOnStartup.Name, config_cb_OpenOnStartup);
            xmlSettings.AddControlSetting(tb_CurrentWorld.Name, tb_CurrentWorld);
            xmlSettings.AddControlSetting(config_cb_MinimizeOnClose.Name, config_cb_MinimizeOnClose); 
            xmlSettings.AddControlSetting(config_tb_ChatButtonLoc.Name, config_tb_ChatButtonLoc); 
            xmlSettings.AddControlSetting(config_tb_ChatListLoc.Name, config_tb_ChatListLoc); 

            if (File.Exists(settingsFile))
            {
                FileStream fs = new FileStream(settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlTextReader xReader = new XmlTextReader(fs);

                try
                {
                    while (xReader.Read())
                    {
                        if (xReader.NodeType == XmlNodeType.Element)
                        {
                            if (xReader.LocalName == "SettingsSerializer")
                            {
                                xmlSettings.ImportFromXml(xReader);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error loading settings: " + ex.Message;
                }
                xReader.Close();
            }
        }
        void SaveSettings()
        {
            FileStream fs = new FileStream(settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8);
            xWriter.Formatting = Formatting.Indented;
            xWriter.Indentation = 1;
            xWriter.IndentChar = '\t';
            xWriter.WriteStartDocument(true);
            xWriter.WriteStartElement("Config");    // <Config>
            xWriter.WriteStartElement("SettingsSerializer");    // <Config><SettingsSerializer>
            xmlSettings.ExportToXml(xWriter);   // Fill the SettingsSerializer XML
            xWriter.WriteEndElement();  // </SettingsSerializer>
            xWriter.WriteEndElement();  // </Config>
            xWriter.WriteEndDocument(); // Tie up loose ends (shouldn't be any)
            xWriter.Flush();    // Flush the file buffer to disk
            xWriter.Close();
        }

        private void btn_OpenChatList_Click(object sender, EventArgs e)
        {
            OpenChatList();
        }

        public void OpenChatList()
        {
            if (ChatList == null || ChatList.IsDisposed)
            {
                ChatList = null;
            }
            else
            {
                ChatList.Show();
                ChatList.WindowState = FormWindowState.Normal;
                return;
            }

            ChatList = new ChatList();
            ChatList.TopMost = true;
            ChatList.Show();

            var chatListLoc = Instance.config_tb_ChatListLoc.Text.ToLocation();
            if (chatListLoc != null)
            {
                ChatList.Location = chatListLoc.Value;
            }
            else
            {
                ChatList.Location = MousePosition;

            }
        }

        public void OpenChatButton()
        {
            if (ChatButton == null || ChatButton.IsDisposed)
            {
                ChatButton = null;
            }
            else
            {
                ChatButton.Show();
                return;
            }

            ChatButton = new ChatButton();
            ChatButton.TopMost = true;
            ChatButton.Show();

            var chatButtonLoc = Instance.config_tb_ChatButtonLoc.Text.ToLocation();
            if (chatButtonLoc != null)
            {
                ChatButton.Location = chatButtonLoc.Value;
            }
            else
            {
                ChatButton.Location = MousePosition;
            }

            ChatButton.Size = ChatButton.MaximumSize;
        }

        private void CloseAllWindows()
        {
            if (ChatList == null || ChatList.IsDisposed)
            {
                return;
            }
            ChatList.Close();
            ChatList.Dispose();
            ChatButton.Close();
            ChatList.Dispose();
            foreach (var window in OpenChatWindows)
            {
                window.Value.Close();
                window.Value.Dispose();
            }
        }

        private void btn_SpoofMsg_Click(object sender, EventArgs e)
        {
            Manager.ProcessLogLine(new LogInfo("[00:27:08.000] 00:000d:▲John Doe:test test", DateTime.Now));
        }
    }
}
