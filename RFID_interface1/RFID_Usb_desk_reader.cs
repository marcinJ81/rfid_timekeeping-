using System;
using System.IO.Ports;
using System.Linq;

namespace RFID_interface1
{

    public interface IDeviceConfiguration
    {
        SerialPort getConfiguration(string portName,  int baudrate, int dataB, int readT);
        void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e);
    }
    public class DevicesConfiguration : IDeviceConfiguration
    {
        private ISerialPortAndTransponderManager itransponder { get; set; }
        public DevicesConfiguration(ISerialPortAndTransponderManager itransponder)
        {
            this.itransponder = itransponder;
        }

        public SerialPort getConfiguration(string portName,  int baudrate, int dataB, int readT)
        {
            SerialPort portDevices = new SerialPort(itransponder.portNames().Where(x => x.Contains(portName)).First());
            portDevices.BaudRate = baudrate;
            portDevices.Parity = Parity.None;
            portDevices.StopBits = StopBits.One;
            portDevices.DataBits = 8;
            portDevices.ReadTimeout = 3000;
            portDevices.Handshake = Handshake.None;
            return portDevices;
        }

        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }

}
