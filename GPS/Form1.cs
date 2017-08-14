using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPS
{
    public partial class Form1 : Form
    {
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        SerialPortManager _spManager;
        string toLink = "";
        string str = "";

        public Form1()
        {
            InitializeComponent();
            UserInitialization();
        }
        private void UserInitialization()
        {
            _spManager = new SerialPortManager();
            SerialSettings mySerialSettings = _spManager.CurrentSerialSettings;

            _spManager.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved);
        }

        void _spManager_NewSerialDataRecieved(object sender, SerialDataEventArgs e)
        {
            if (!_spManager.IsSerialPortOpened())
            {
                ForButtonColors.status = 0;
            }
            if (this.InvokeRequired)
            {
                // Using this.Invoke causes deadlock when closing serial port, and BeginInvoke is good practice anyway.
                this.BeginInvoke(new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved), new object[] { sender, e });
                return;
            }

            // This application is connected to a GPS sending ASCCI characters, so data is converted to text
            str += Encoding.ASCII.GetString(e.Data);
            if (str.Length >= 1000)
            {
                str = "";
            }

            tbData.AppendText(str);
            if (str.Contains("GLL"))
            {
                String[] substrings = str.Split('$');
                foreach (var item in substrings)
                {
                    if (item.Length >= 32 && item.Contains("GLL"))
                    {
                        toLink = item;
                        GoogleMapstxt.Text = toLink;
                        //jesli stale pobiera dobre info 
                        ForButtonColors.status = 2;
                    }
                    if (item.Contains(",,,,,") && item.Contains("GLL"))
                    {
                        ForButtonColors.status = 1;
                    }
                }
            }
            if (toLink.Length > 1 && toLink[0] == 'G' && toLink[1] == 'P')
            {
                toLink = toLink.Remove(0, 2);
            }
            tbData.ScrollToCaret();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _spManager.StartListening();
            myTimer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _spManager.StopListening();
        }

        private string UnUsedMethodToGenerateURL()
        {
            string url = ""; // "https://www.google.com/maps/place/";
            url = "https://www.google.com/maps/place/" + toLink[4].ToString() + toLink[5].ToString() + '°' + toLink[6].ToString() + toLink[7].ToString() +
                '\'' + toLink[9].ToString() + toLink[10].ToString() + '.' + toLink[11].ToString() + toLink[12].ToString() +
                toLink[13].ToString() + "\"" + toLink[15].ToString() + '+' + toLink[17].ToString() + toLink[18].ToString() +
                toLink[19].ToString() + '°' + toLink[20].ToString() + toLink[21].ToString() + '\'' + toLink[23].ToString() +
                toLink[24].ToString() + "." + toLink[25].ToString() + toLink[26].ToString() + toLink[27].ToString() +
                "\"" + toLink[29].ToString();
            return url;
            //insert this method to button1's click as url and this will also work
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gelocation x = new Gelocation(toLink);
            string url = x.MakeURL();
            System.Diagnostics.Process.Start(url);
        }
        

        public void btnColors_Click(object sender, EventArgs e)
        {
            //int caseSwitch = ForButtonColors.status;
            //switch (caseSwitch)
            //{
            //    case 0:
            //        btnColors.BackColor = System.Drawing.Color.Red; //Color.Red;
            //        break;
            //    case 1:
            //        btnColors.BackColor = System.Drawing.Color.Orange;
            //        break;
            //    case 2:
            //        btnColors.BackColor = System.Drawing.Color.Green;
            //        break;
            //    case 3:
            //        btnColors.BackColor = System.Drawing.Color.Gray;
            //        break;
            //}
            //if (!_spManager.IsSerialPortOpened() && caseSwitch != 3)
            //{
            //    ForButtonColors.status = 0;
            //}
        }
        private void MyTimer_Click(object sender, EventArgs e)
        {
            int caseSwitch = ForButtonColors.status;
            switch (caseSwitch)
            {
                case 0:
                    btnColors.BackColor = System.Drawing.Color.Red; //Color.Red;
                    break;
                case 1:
                    btnColors.BackColor = System.Drawing.Color.Orange;
                    break;
                case 2:
                    btnColors.BackColor = System.Drawing.Color.Green;
                    break;
                case 3:
                    btnColors.BackColor = System.Drawing.Color.Gray;
                    break;
            }
            if (!_spManager.IsSerialPortOpened() && caseSwitch != 3)
            {
                ForButtonColors.status = 0;
                _spManager.StartListening();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myTimer.Interval = 1000;
            myTimer.Tick += MyTimer_Click;
            btnColors.BackColor = System.Drawing.Color.Gray;
        }
    }
}
