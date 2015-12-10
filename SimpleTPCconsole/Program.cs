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
            bytestream.makeByteArray<ImADumbTestClass>(iadtc);



            Console.ReadLine();

        }
    }
}
