using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace GPS
{
    public class SerialPortManager
    {
        private SerialPort _serialPort;
        private SerialSettings _currentSerialSettings = new SerialSettings();
        private string _latestRecieved = String.Empty;
        public event EventHandler<SerialDataEventArgs> NewSerialDataRecieved;
        int w { get; set; }
        /// <summary>
        /// Returns 1 if it is opened 
        /// </summary>
        /// <returns></returns>
        public bool IsSerialPortOpened()
        {
            return _serialPort.IsOpen;
        }

        /// <summary>
        /// Gets or sets the current serial port settings
        /// </summary>
        public SerialSettings CurrentSerialSettings
        {
            get { return _currentSerialSettings; }
            set { _currentSerialSettings = value; }
        }

        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int dataLength = _serialPort.BytesToRead;
            byte[] data = new byte[dataLength];
            int nbrDataRead = _serialPort.Read(data, 0, dataLength);
            if (nbrDataRead == 0)
                return;

            // Send data to whom ever interested
            if (NewSerialDataRecieved != null)
                NewSerialDataRecieved(this, new SerialDataEventArgs(data));

        }

        /// <summary>
        /// Connects to a serial port defined through the current settings
        /// </summary>
        public void StartListening()
        {
            // Closing serial port if it is open
            if (_serialPort != null && _serialPort.IsOpen)
                _serialPort.Close();
            
            // Setting serial port settings
            _serialPort = new SerialPort("COM4");

            // Subscribe to event and open serial port for data
            //_serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            //_serialPort.Open();
            try
            {
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
                _serialPort.Open();
            }
            catch
            {
                //jesli COM4 jest zamkniety to na czerwono
                //Colors.BackColor = Color.Red;
                ForButtonColors.status = 0;

            }
        }
        /// <summary>
        /// Closes the serial port
        /// </summary>
        public void StopListening()
        {
            ForButtonColors.status = 3;
            
            _serialPort.Close();
        }

    }
    /// <summary>
    /// EventArgs used to send bytes recieved on serial port
    /// </summary>
    public class SerialDataEventArgs : EventArgs
    {
        public SerialDataEventArgs(byte[] dataInByteArray)
        {
            Data = dataInByteArray;
        }

        /// <summary>
        /// Byte array containing data from serial port
        /// </summary>
        public byte[] Data;

    }
    public struct Gelocation
    {
        string Latitiude;
        string Longitiude;
        public Gelocation(string x)
        {
            string Longi = "";
            string Longifirsttwonumbers = x[4].ToString() + x[5].ToString();
            for (int i = 6; i < 13; ++i)
            {
                if (i != 8)
                {
                    Longi += x[i];
                }
            }
            string Lati = "";
            string Latifirsttwonumbers = x[17].ToString() + x[18].ToString() + x[19].ToString();
            for (int i = 20; i < 27; ++i)
            {
                if (i != 22)
                {
                    Lati += x[i];
                }
            }
            int a, b;
            Int32.TryParse(Lati, out a);
            Int32.TryParse(Longi, out b);
            a /= 60;
            b /= 60;
            Latitiude = Latifirsttwonumbers + "." + a.ToString() + "°";
            Longitiude = Longifirsttwonumbers + "." + b.ToString() + "°";
        }
        public string MakeURL()
        {
            string x;
            x = "https://www.google.com/maps/place/" + this.Longitiude + "," + this.Latitiude;
            return x;
        }
    }
}