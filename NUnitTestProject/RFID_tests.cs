using System.Collections.Generic;
using NUnit.Framework;
using RFID_interface1;
using topTO;

namespace Tests
{
    public class Tests_SerialPorts
    {
        private ISerialPortAndTransponderManager iReal {get;set;}
        private ISerialPortAndTransponderManager iFake { get; set; }

        public Tests_SerialPorts()
        {
            this.iReal = new SerialPortAndTransponderManager();
            this.iFake = new Fake_ListSerialPorts();
        }
        [Test]
        public void Test_exmaple()
        {
            var result = iReal.getAdressForPort("com256");
            Assert.AreEqual(0, result);
        }
       
    }

    public class Fake_ListSerialPorts : ISerialPortAndTransponderManager
    {
        public Transponder deviceHandler { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public byte getAdressForPort(string portName)
        {
                return 0;           
        }

        public bool initializeDevice(string portName)
        {
            throw new System.NotImplementedException();
        }

        public List<string> portNames()
        {
            List<string> result = new List<string>();
            result.Add("com256");
            result.Add("com257");
            result.Add("com258");
            return result;
        }

        public bool ReadTagId(out long tag)
        {
            throw new System.NotImplementedException();
        }
    }
}