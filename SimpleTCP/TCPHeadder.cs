using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace SimpleTCP
{
    class TCPHeadder
    {
        //verson
        byte version;
        //IP header lenght
        byte headerLenght;
        //type of serice
        byte ipTypeOfService;
        //size of datagram
        ushort sizeOfDatagram;
        //idintification 
        ushort idintification;
        //flags
        byte flag;
        //fragmentation offset
        ushort ipOffset;
        //time to live
        byte timeToLive;
        //protocal
        byte ipProtocol;
        //header checksum
        ushort ipChecksum;
        //source address
        IPAddress ipSourceAddress;
        //destinataion address
        IPAddress ipDestAddress;
        //padding
        byte padding;
        //options ?
        

        public TCPHeadder()
        {
            version = 4;
            headerLenght = (byte)Ipv4HeaderLength;    // Set the property so it will convert properly
            ipTypeOfService = 0;
            idintification = 0;
            ipOffset = 0;
            timeToLive = 1;
            ipProtocol = 0;
            ipChecksum = 0;
            ipSourceAddress = IPAddress.Any;
            ipDestAddress = IPAddress.Any;

        }

        public byte version
        {
            get{
                return version;
            }
            set{
                version = value;

            }
        }

        public byte headderLenght
        {
            get{
                return (byte)headderLenght;
            }
            set{
              headderLenght = (byte)(value/4);
            }
        }

        public byte ipTypeOfService
        {
            get
            {
                return ipTypeOfService;
            }
            set
            {
                ipTypeOfService = value;
            }
        }
        public ulong sizeOfDatagram
        {
            get
            {
                return (ushort)IPAddress.HostToNetworkOrder((short)ipTotalLen);
            }
            set
            {
                ipTotalLen = (ushort)IPAddress.HostToNetworkOrder((short)value);
            }
        }
    }
}
