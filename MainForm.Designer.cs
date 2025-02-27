﻿namespace ComPortSender
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox groupBoxSender;
        private System.Windows.Forms.GroupBox groupBoxReceiver;
        private System.Windows.Forms.ComboBox comboBoxSenderPorts;
        private System.Windows.Forms.ComboBox comboBoxReceiverPorts;
        private System.Windows.Forms.TextBox textBoxSenderBaudRate;
        private System.Windows.Forms.TextBox textBoxReceiverBaudRate;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.TextBox textBoxSendInterval;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonListen;
        private System.Windows.Forms.ListBox listBoxReceivedMessages;
        private System.Windows.Forms.Label labelSenderPort;
        private System.Windows.Forms.Label labelReceiverPort;
        private System.Windows.Forms.Label labelBaudRateSender;
        private System.Windows.Forms.Label labelBaudRateReceiver;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label labelSendInterval;
        private System.Windows.Forms.Label labelReceivedMessages;

        private System.Windows.Forms.ListBox listBoxLogs;

        private System.Windows.Forms.CheckBox checkBoxAltSatiraGec;

        private System.Windows.Forms.Button buttonClearLogs;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBoxSender = new System.Windows.Forms.GroupBox();
            this.groupBoxReceiver = new System.Windows.Forms.GroupBox();
            this.comboBoxSenderPorts = new System.Windows.Forms.ComboBox();
            this.comboBoxReceiverPorts = new System.Windows.Forms.ComboBox();
            this.textBoxSenderBaudRate = new System.Windows.Forms.TextBox();
            this.textBoxReceiverBaudRate = new System.Windows.Forms.TextBox();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.textBoxSendInterval = new System.Windows.Forms.TextBox();
            this.listBoxReceivedMessages = new System.Windows.Forms.ListBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonListen = new System.Windows.Forms.Button();
            this.labelSenderPort = new System.Windows.Forms.Label();
            this.labelReceiverPort = new System.Windows.Forms.Label();
            this.labelBaudRateSender = new System.Windows.Forms.Label();
            this.labelBaudRateReceiver = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.labelSendInterval = new System.Windows.Forms.Label();
            this.labelReceivedMessages = new System.Windows.Forms.Label();
            this.listBoxLogs = new System.Windows.Forms.ListBox();
            
            
            // buton eventHandler
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            this.buttonListen.Click += new System.EventHandler(this.ButtonListen_Click);


            // Menü Çubuğu (MenuStrip) Tanımla
            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem helpMenu = new ToolStripMenuItem("Yardım");
            ToolStripMenuItem aboutMenuItem = new ToolStripMenuItem("Hakkında");

            // "Hakkında" menü öğesine tıklama olayını ekle
            aboutMenuItem.Click += new EventHandler(AboutMenuItem_Click);

            // Menü çubuğuna ekleme
            helpMenu.DropDownItems.Add(aboutMenuItem);
            menuStrip.Items.Add(helpMenu);

            // Menü çubuğunu forma ekleme
            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;


            // Logları Temizleme Butonu
            this.buttonClearLogs = new System.Windows.Forms.Button();
            this.buttonClearLogs.Text = "Logları Temizle";
            this.buttonClearLogs.Size = new System.Drawing.Size(120, 30);
            this.buttonClearLogs.Location = new System.Drawing.Point(20, 420); // Konumu ihtiyaca göre ayarla
            this.buttonClearLogs.Click += new System.EventHandler(this.ButtonClearLogs_Click);
            this.Controls.Add(this.buttonClearLogs);


            // CheckBox: Alt Satıra Geç
            this.checkBoxAltSatiraGec = new System.Windows.Forms.CheckBox();
            this.checkBoxAltSatiraGec.Text = "Alt Satıra Geç";
            this.checkBoxAltSatiraGec.AutoSize = true;
            this.checkBoxAltSatiraGec.Location = new System.Drawing.Point(20, 190);
            this.checkBoxAltSatiraGec.Checked = true; // Varsayılan olarak işaretli
            this.groupBoxSender.Controls.Add(this.checkBoxAltSatiraGec);

                        
            // listBoxLogs
            this.listBoxLogs = new System.Windows.Forms.ListBox();
            this.listBoxLogs.FormattingEnabled = true;
            this.listBoxLogs.ItemHeight = 15;
            this.listBoxLogs.Location = new System.Drawing.Point(12, 250);
            this.listBoxLogs.Name = "listBoxLogs";
            this.listBoxLogs.Size = new System.Drawing.Size(250, 150);
            this.listBoxLogs.TabIndex = 5;
            this.Controls.Add(this.listBoxLogs);


            // Gönderici Alanı
            this.groupBoxSender.Text = "Gönderici";
            this.groupBoxSender.Location = new System.Drawing.Point(20, 20);
            this.groupBoxSender.Size = new System.Drawing.Size(250, 250);
            
            this.labelSenderPort.Text = "Port:";
            this.labelSenderPort.Location = new System.Drawing.Point(20, 30);
            this.comboBoxSenderPorts.Location = new System.Drawing.Point(120, 30);
            
            this.labelBaudRateSender.Text = "Baud Rate:";
            this.labelBaudRateSender.Location = new System.Drawing.Point(20, 60);
            this.textBoxSenderBaudRate.Location = new System.Drawing.Point(120, 60);
            this.textBoxSenderBaudRate.Text = "9600";
            
            this.labelMessage.Text = "Mesaj:";
            this.labelMessage.Location = new System.Drawing.Point(20, 90);
            this.textBoxMessage.Location = new System.Drawing.Point(120, 90);
            
            this.labelSendInterval.Text = "Gönderim Sıklığı:";
            this.labelSendInterval.Location = new System.Drawing.Point(20, 120);
            this.textBoxSendInterval.Location = new System.Drawing.Point(120, 120);
            this.textBoxSendInterval.Text = "1000";
            
            this.buttonSend.Text = "Yayınla";
            this.buttonSend.Location = new System.Drawing.Point(20, 160);
            
            this.buttonStop.Text = "Durdur";
            this.buttonStop.Location = new System.Drawing.Point(120, 160);
            
            this.groupBoxSender.Controls.Add(this.labelSenderPort);
            this.groupBoxSender.Controls.Add(this.comboBoxSenderPorts);
            this.groupBoxSender.Controls.Add(this.labelBaudRateSender);
            this.groupBoxSender.Controls.Add(this.textBoxSenderBaudRate);
            this.groupBoxSender.Controls.Add(this.labelMessage);
            this.groupBoxSender.Controls.Add(this.textBoxMessage);
            this.groupBoxSender.Controls.Add(this.labelSendInterval);
            this.groupBoxSender.Controls.Add(this.textBoxSendInterval);
            this.groupBoxSender.Controls.Add(this.buttonSend);
            this.groupBoxSender.Controls.Add(this.buttonStop);
            
            // Alıcı Alanı
            this.groupBoxReceiver.Text = "Alıcı";
            this.groupBoxReceiver.Location = new System.Drawing.Point(300, 20);
            this.groupBoxReceiver.Size = new System.Drawing.Size(250, 250);
            
            this.labelReceiverPort.Text = "Port:";
            this.labelReceiverPort.Location = new System.Drawing.Point(20, 30);
            this.comboBoxReceiverPorts.Location = new System.Drawing.Point(120, 30);
            
            this.labelBaudRateReceiver.Text = "Baud Rate:";
            this.labelBaudRateReceiver.Location = new System.Drawing.Point(20, 60);
            this.textBoxReceiverBaudRate.Location = new System.Drawing.Point(120, 60);
            this.textBoxReceiverBaudRate.Text = "9600";
            
            this.labelReceivedMessages.Text = "Alınan Mesajlar:";
            this.labelReceivedMessages.Location = new System.Drawing.Point(20, 90);

            this.listBoxReceivedMessages = new System.Windows.Forms.ListBox();
            this.listBoxReceivedMessages.FormattingEnabled = true;
            this.listBoxReceivedMessages.ItemHeight = 15;
            this.listBoxReceivedMessages.Location = new System.Drawing.Point(20, 190); // Yeni konum
            this.listBoxReceivedMessages.Name = "listBoxReceivedMessages";
            this.listBoxReceivedMessages.Size = new System.Drawing.Size(220, 400);
            this.Controls.Add(this.listBoxReceivedMessages);
            
            this.buttonListen.Text = "Dinlemeye Başla";
            this.buttonListen.Location = new System.Drawing.Point(20, 115);
            this.buttonListen.Size = new System.Drawing.Size(200, 30);
            
            this.groupBoxReceiver.Controls.Add(this.labelReceiverPort);
            this.groupBoxReceiver.Controls.Add(this.comboBoxReceiverPorts);
            this.groupBoxReceiver.Controls.Add(this.labelBaudRateReceiver);
            this.groupBoxReceiver.Controls.Add(this.textBoxReceiverBaudRate);
            this.groupBoxReceiver.Controls.Add(this.labelReceivedMessages);
            this.groupBoxReceiver.Controls.Add(this.listBoxReceivedMessages);
            this.groupBoxReceiver.Controls.Add(this.buttonListen);
            
            // Form'a ekleme
            this.Controls.Add(this.groupBoxSender);
            this.Controls.Add(this.groupBoxReceiver);
            
           // Form Boyutu Büyütme
            this.ClientSize = new System.Drawing.Size(800, 500); // Yeni genişlik ve yükseklik

            this.Text = "COM Port Veri Aktarımı";
        }
    }
}
