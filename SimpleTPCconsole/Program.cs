using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTCP;

namespace SimpleTPCconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ImADumbTestClass iadtc = new ImADumbTestClass();
            TCPBody bytestream = new TCPBody();
            byte[] myByteStream = bytestream.makeByteArray<ImADumbTestClass>(iadtc);
            TCPIPHeadder testy = new TCPIPHeadder();
            testy.SizeOfDatagram = 6;
            Console.WriteLine(Convert.ToString(10202, 2).PadLeft(8, '0'));

            int myNum = 15 << 6;
            int myInt = 65535;
            int myNewInt = myInt << 1;
            Console.WriteLine(Convert.ToString(myNewInt, 2).PadLeft(32, '0'));

            Console.ReadLine();

        }
    }
}
