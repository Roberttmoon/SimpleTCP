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
            byte[] myByteStream = bytestream.makeByteArray<string>(iadtc.imADumbTestVariable);
            TCPHeadder testy = new TCPHeadder();
            testy.SizeOfDatagram = 6;
            Console.WriteLine(Convert.ToString((4 << 4 ), 2).PadLeft(8, '0'));


            Console.ReadLine();

        }
    }
}
