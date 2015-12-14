using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTCP;
using System.Net;

namespace SimpleTPCconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TCPIPHeadder ipv4headder =  TCPIPHeadder.create();
            ipv4headder.makeVerLenTosHeadLen(4, 4, 4, 4, ref ipv4headder.verLenTosHeadLen);
            ipv4headder.makeIdentFlagOffset(4, 4, 4, ref ipv4headder.identFlagOffset);
            ipv4headder.makeTtlProtocalChecksum(4, 4, ref ipv4headder.ttlProtocalChecksum);
            ipv4headder.IPSourceAddress = IPAddress.Parse("10.0.2.20");
            ipv4headder.IPDestAddress = IPAddress.Parse("10.0.2.20");
            ipv4headder.makeOptPadding(43, ref ipv4headder.padding, ref ipv4headder.optPadding);


        }
    }
}
