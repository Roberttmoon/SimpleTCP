using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace SimpleTCP
{
    public class TCPIPHeadder
    {

        int verLenTosHeadLen;      //first word made of next 4
        byte version;               //first 4bits
        byte headerLenght;          //second 4bits  
        byte ipTypeOfService;       //thrid 8 bits
        ushort sizeOfDatagram;      //forth 16 bits
        int identFlagOffset;        //second word make of next 3
        ushort idintification;      //first 16 bits
        byte flag;                  //second 3 bits
        ushort ipOffset;            //third 13 bits
        int ttlProtocalChecksum;    //third word made up of next 3
        byte timeToLive;            //first 8 bits
        byte ipProtocol;            //second 8 bits
        ushort ipChecksum;          //third 16 bits
        int ipAdresses;             //
        IPAddress ipSourceAddress;
        IPAddress ipDestAddress;
        byte padding;
        byte[] newHead;
        static public byte Ipv4HeaderLength = 20;

        public TCPIPHeadder()
        {
            this.version = 4;
            headerLenght = (byte)Ipv4HeaderLength;
            ipTypeOfService = 0;
            idintification = 0;
            ipOffset = 0;
            timeToLive = 1;
            ipProtocol = 0;
            ipChecksum = 0;
            ipSourceAddress = IPAddress.Any;
            ipDestAddress = IPAddress.Any;
        }

        #region getsets!

        public byte Version
        {
            get { return version; }
            set { version = value; }
        }

        public byte HeaderLenght
        {
            get { return (byte)headerLenght; }
            set { headerLenght = (byte)(value / 4); }
        }

        public byte IPTypeOfService
        {
            get { return ipTypeOfService; }
            set { ipTypeOfService = value; }
        }
        public ulong SizeOfDatagram
        {
            get { return (ushort)IPAddress.NetworkToHostOrder((short)sizeOfDatagram); }
            set { sizeOfDatagram = (ushort)IPAddress.HostToNetworkOrder((short)value); }
        }
        public ushort Idintification
        {
            get
            { return (ushort)IPAddress.NetworkToHostOrder((short)idintification); }
            set { idintification = (ushort)IPAddress.HostToNetworkOrder((short)value); }
        }
        public ushort IPOffset
        {
            get { return (ushort)IPAddress.NetworkToHostOrder((short)ipOffset); }
            set { ipOffset = (ushort)IPAddress.HostToNetworkOrder((short)value); }
        }
        public byte TimeToLive
        {
            get { return timeToLive; }
            set { timeToLive = value; }
        }
        public byte Protocal
        {
            get { return ipProtocol; }
            set { ipProtocol = value; }
        }
        public ushort Checksum
        {
            get { return (ushort)IPAddress.NetworkToHostOrder((short)ipChecksum); }
            set { ipChecksum = (ushort)IPAddress.HostToNetworkOrder((short)value); }
        }
        public IPAddress IPSourceAddress
        {
            get { return ipSourceAddress; }
            set { ipSourceAddress = value; }
        }
        public IPAddress IPDestAddress
        {
            get { return ipDestAddress; }
            set { ipDestAddress = value; }
        }

        #endregion 

        public static TCPIPHeadder create(byte[] packet, ref int bitsCopied)
        {
            TCPIPHeadder newHeader = new TCPIPHeadder();
            newHeader.version = (byte)(4 << 4);
            newHeader.headerLenght = (byte)Ipv4HeaderLength;
            //byte topLine = newHeader.version & newHeader.headerLenght;


            

            return newHeader;
        }
    }
}
