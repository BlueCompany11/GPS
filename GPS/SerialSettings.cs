using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO.Ports;
using System.ComponentModel;

namespace GPS
{
    public class SerialSettings
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        /// <summary>
        /// Send a PropertyChanged event
        /// </summary>
        /// <param name="propertyName">Name of changed property</param>
        private void SendPropertyChangedEvent(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
