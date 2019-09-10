using System.Collections.Generic;
using NUnit.Framework;
using RFID_interface1;

namespace Tests
{
    public class Tests_SerialPorts
    {
        private ISerialPortManager iReal {get;set;}
        private ISerialPortManager iFake { get; set; }

        public Tests_SerialPorts()
        {
            this.iReal = new SerialPortManager();
            this.iFake = new Fake_ListSerialPorts();
        }
        [Test]
        public void Test_exmaple()
        {
            var result = iReal.getAdressForPort("com256");
            Assert.AreEqual(0, result);
        }
       
    }

    public class Fake_ListSerialPorts : ISerialPortManager
    {
        public byte getAdressForPort(string portName)
        {
                return 0;           
        }

        public List<string> portNames()
        {
            List<string> result = new List<string>();
            result.Add("com256");
            result.Add("com257");
            result.Add("com258");
            return result;
        }
    }
}