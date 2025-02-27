using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Text.Json; 

namespace ComPortSender
{
    public partial class MainForm : Form
    {
        
        private SerialPort senderPort = new SerialPort();
        private SerialPort receiverPort = new SerialPort();

        private bool isSending = false;
        private Thread? sendThread;


        public MainForm()
        {
            InitializeComponent();
            LoadAvailablePorts();
            AddLog("✅ Form başarıyla yüklendi!"); // Açılışta log düşmeli
        
        }

    private void LoadAvailablePorts()
    {
        var ports = SerialPort.GetPortNames();
        comboBoxSenderPorts.Items.AddRange(ports);
        comboBoxReceiverPorts.Items.AddRange(ports);

        if (ports.Length > 0)
        {
            // Varsayılan olarak COM3 ve COM4 ayarla
            int com3Index = Array.IndexOf(ports, "COM3");
            int com4Index = Array.IndexOf(ports, "COM4");

            if (com3Index >= 0)
            {
                comboBoxSenderPorts.SelectedIndex = com3Index;
            }
            else
            {
                comboBoxSenderPorts.SelectedIndex = 0; // COM3 yoksa ilk port seçilsin
            }

            if (com4Index >= 0)
            {
                comboBoxReceiverPorts.SelectedIndex = com4Index;
            }
            else
            {
                comboBoxReceiverPorts.SelectedIndex = 0; // COM4 yoksa ilk port seçilsin
            }
        }
    }



    private void buttonSend_Click(object sender, EventArgs e)
    {
        if (isSending)
        {
            AddLog("⚠️ Zaten yayın yapılıyor!");
            return;
        }

       string portName = comboBoxSenderPorts.SelectedItem?.ToString() ?? "";

        if (string.IsNullOrEmpty(portName))
        {
            AddLog("❌ Port seçilmedi!");
            return;
        }

        int baudRate = int.Parse(textBoxSenderBaudRate.Text);
        int interval = int.TryParse(textBoxSendInterval.Text, out int ms) ? ms : 1000;

        try
        {
            senderPort = new SerialPort(portName, baudRate);
            senderPort.Open();

            if (!senderPort.IsOpen)
            {
                AddLog("❌ Port açılamadı! Belki başka bir uygulama kullanıyor?");
                return;
            }

            isSending = true;
            AddLog($"✅ Yayın başladı! Port: {portName}, BaudRate: {baudRate}, Interval: {interval} ms");

            sendThread = new Thread(() =>
            {
                while (isSending)
                {
                    try
                    {
                        string message = textBoxMessage.Text;

                        if (checkBoxAltSatiraGec.Checked)
    {
        // Mesajı başa \r ekleyerek gönder, böylece eski satır kaybolmaz
        senderPort.Write("\r" + textBoxMessage.Text.Trim() + "\n");
    }
    else
    {
        // Tek satırda güncelle
        senderPort.Write("\r" + textBoxMessage.Text.Trim());
    }


     AddLog($"📤 Mesaj gönderildi: {message}");
         Thread.Sleep(interval);
                }
                catch (Exception ex)
                {
                    AddLog($"❌ Hata: {ex.Message}");
                    isSending = false;
                }
            }
        });

        sendThread.IsBackground = true;
        sendThread.Start();
    }
    catch (Exception ex)
    {
        AddLog($"❌ Hata: {ex.Message}");
    }
}

private void AboutMenuItem_Click(object sender, EventArgs e)
{
    MessageBox.Show("COM Port Veri Aktarım Uygulaması\nVersiyon: 1.0.0\nGeliştirici: [Senin İsmin]",
        "Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
}



        private void buttonStop_Click(object sender, EventArgs e)
        {
            isSending = false;

            if (sendThread != null && sendThread.IsAlive)
            {
                sendThread.Join();  // Thread düzgün dursun
            }

            if (senderPort != null && senderPort.IsOpen)
            {
                senderPort.Close();
            }

            AddLog("⏹ Yayın durduruldu!");
            MessageBox.Show("Yayın durduruldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void ButtonListen_Click(object sender, EventArgs e)
        {
            try
            {
                if (receiverPort != null && receiverPort.IsOpen)
                {
                    receiverPort.Close();
                    Thread.Sleep(100); // Portun tamamen kapanmasını bekle
                }

            string portName = comboBoxReceiverPorts.SelectedItem?.ToString() ?? "";

            
            if (string.IsNullOrEmpty(portName))
            {
                AddLog("❌ Dinleme için port seçilmedi!");
                return;
            }

            int baudRate = int.Parse(textBoxReceiverBaudRate.Text);
            receiverPort = new SerialPort(portName, baudRate);
            receiverPort.DataReceived += ReceiverPort_DataReceived;
            receiverPort.Open();

            if (!receiverPort.IsOpen)
            {
                AddLog("❌ Dinleme başlatılamadı! Port açılamadı.");
                return;
            }

            AddLog("🎧 Dinlemeye başlandı!");
        }
        catch (Exception ex)
        {
            AddLog($"❌ Dinleme başlatılamadı: {ex.Message}");
        }
    }

        private void ReceiverPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string receivedData = receiverPort.ReadLine().Trim(); // Gelen mesajı temizle
                receivedData = receivedData.Replace("\r", "").Replace("\n", ""); // Gereksiz satır sonu karakterlerini kaldır

                // Artık log listbox'a eklenmeyecek, sadece gelen mesajlar listesinde gösterilecek
                Invoke(new Action(() =>
                {
                    listBoxReceivedMessages.Items.Add(receivedData);
                }));
            }
            catch (Exception ex)
            {
                AddLog($"❌ Okuma hatası: {ex.Message}");
            }
        }


        // **Logları ekrana yazan metod**
        private void AddLog(string message)
        {
            try
            {
                if (listBoxLogs.InvokeRequired)
                {
                    listBoxLogs.BeginInvoke(new Action(() =>
                    {
                        listBoxLogs.Items.Add($"{DateTime.Now:HH:mm:ss} - {message}");
                        listBoxLogs.TopIndex = listBoxLogs.Items.Count - 1; // En son loga scroll yap
                    }));
                }
                else
                {
                    listBoxLogs.Items.Add($"{DateTime.Now:HH:mm:ss} - {message}");
                    listBoxLogs.TopIndex = listBoxLogs.Items.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Log hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonClearLogs_Click(object sender, EventArgs e)
        {
            listBoxLogs.Items.Clear();  // Log listesini temizle
            listBoxReceivedMessages.Items.Clear(); // Alınan mesajlar listesini temizle
            AddLog("🗑 Loglar temizlendi!");
        }


            }
        }

