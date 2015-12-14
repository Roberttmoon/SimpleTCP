using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.InteropServices;

namespace SimpleTCP
{
    public class TCPIPHeadder
    {

        public int verLenTosHeadLen;       //first word made of next 4
        int version;                //first 4bits
        int headerLenght;           //second 4bits  
        int ipTypeOfService;        //thrid 8 bits
        int sizeOfDatagram;         //forth 16 bits
        public int identFlagOffset;        //second word make of next 3
        int idintification;         //first 16 bits
        int flag;                   //second 3 bits
        int ipOffset;               //third 13 bits
        public int ttlProtocalChecksum;    //third word made up of next 3
        int timeToLive;             //first 8 bits
        int ipProtocol;             //second 8 bits
        int ipChecksum;             //third 16 bits
        IPAddress ipSourceAddress;  //32 bit word
        IPAddress ipDestAddress;    //32 bit word
        public int optPadding;       //last word
        int ipOtions;               //variable
        public int padding;                // makes up the rest of the 32 bits
        static public int Ipv4HeaderLength = 20;

        public TCPIPHeadder()
        {
            version = 4;
            headerLenght = Ipv4HeaderLength;
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

        public int Version
        {
            get { return version; }
            set { version = value; }
        }

        public int HeaderLenght
        {
            get { return (byte)headerLenght; }
            set { headerLenght = value; }
        }

        public int IPTypeOfService
        {
            get { return ipTypeOfService; }
            set { ipTypeOfService = value; }
        }
        public int SizeOfDatagram
        {
            get { return IPAddress.NetworkToHostOrder((short)sizeOfDatagram); }
            set { sizeOfDatagram = IPAddress.HostToNetworkOrder((short)value); }
        }
        public int Idintification
        {
            get { return IPAddress.NetworkToHostOrder((short)idintification); }
            set { idintification = IPAddress.HostToNetworkOrder((short)value); }
        }
        public int IPOffset
        {
            get { return IPAddress.NetworkToHostOrder((short)ipOffset); }
            set { ipOffset = IPAddress.HostToNetworkOrder((short)value); }
        }
        public int TimeToLive
        {
            get { return timeToLive; }
            set { timeToLive = value; }
        }
        public int Protocal
        {
            get { return ipProtocol; }
            set { ipProtocol = value; }
        }
        public int Checksum
        {
            get { return IPAddress.NetworkToHostOrder((short)ipChecksum); }
            set { ipChecksum = IPAddress.HostToNetworkOrder((short)value); }
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

        public static TCPIPHeadder create()
        {
            TCPIPHeadder newHeader = new TCPIPHeadder();
            return newHeader;
        }

        public int makeVerLenTosHeadLen(int verson, int headerLenght, int ipTypeOfService, int sizeOfDtatgram, ref int verLenTosHeadLen)
        {
            verLenTosHeadLen = (verson << 4) | headerLenght;
            verLenTosHeadLen = (verLenTosHeadLen << 8) | ipTypeOfService;
            verLenTosHeadLen = (verLenTosHeadLen << 16) | sizeOfDtatgram;
            return verLenTosHeadLen;
        }
        public int makeIdentFlagOffset(int identification, int flags, int offset, ref int identFlagOffset)
        {
            identFlagOffset = (identification << 16) | flag;
            identFlagOffset = (identFlagOffset << 3) | offset;
            return identFlagOffset;
        }
        public int makeTtlProtocalChecksum(int timeToLive, int protocal, ref int ttlProtocalChecksum)
        {
            int standInChecksum = 0000000000000000;
            ttlProtocalChecksum = (timeToLive << 8) | protocal;
            ttlProtocalChecksum = (ttlProtocalChecksum << 16) | standInChecksum;
            return ttlProtocalChecksum;
        }
        public int makeOptPadding(int options, ref int padding, ref int optPadding)
        {
            if (Marshal.SizeOf(options) < 32)
            {
                int offset = Marshal.SizeOf(options) - 32;
                return options << offset;
            }
            else if (Marshal.SizeOf(options) == 32)
            {
                return options;
            }
            else return 0;
        }

    }
}
