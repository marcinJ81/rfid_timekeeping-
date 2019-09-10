using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using topTO;
using System.Linq;


namespace RFID_interface1
{
    //card read with  thread (semphore)
    public interface ISerialPortAndTransponderManager
    {
        List<string> portNames();
        byte getAdressForPort( string portName);
        bool initializeDevice(string portName);
        Transponder deviceHandler { get;  set; }
        bool ReadTagId(out long tag);
    }

    public class SerialPortAndTransponderManager : ISerialPortAndTransponderManager
    {
        private ISerialPortAndTransponderManager iserialPort { get; set; }
        
        public Transponder deviceHandler
        {
            get {
                if (deviceHandler != null)
                    return deviceHandler;
                else
                    return null;
            }
            set { deviceHandler = value; }
        }

        public SerialPortAndTransponderManager(ISerialPortAndTransponderManager iserialP)
        {
            this.iserialPort = iserialP;
        }
        public byte getAdressForPort(string portName)
        {
            if (portName == "com256" || portName == "com257" || portName == "com258")
            {
                //device simulate
                byte address = 0;
                return address;
            }
            else
            {
                byte address = Transponder.GetAddress(portName);
                return address;
            }
            // what the address was returned when the device was not connected? maybe zero
        }

        public bool initializeDevice(string portName)
        {
            Transponder device = new Transponder(portName, this.iserialPort.getAdressForPort(portName));
            if (device != null)
            {
                deviceHandler = device;
                return deviceHandler.Initialize();
            }
            else
            {
                return false;
            }
          
        }

        public List<string> portNames()
        {
            List<string> result = new List<string>();
            var source = SerialPort.GetPortNames();
            if (source == null)
            {
                result.Add("brak");
                return result;
            }
            else
            {
                foreach (var i in source)
                {
                    result.Add(i);
                }
                return result;
            }

        }

        public bool ReadTagId(out long tag)
        {
            if (this.deviceHandler.ReadCardNumber(out tag))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
