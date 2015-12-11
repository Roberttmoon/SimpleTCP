using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTCP
{
    class TCPHeader
    {
        int ports; // made up of source and dest ports
        int sourcePort;
        int destPort;
        int sequenceNumber;
        int actNumber;
        int offsetReserveFlagsWindow; //made up of the next 4 things
        int dataOffset; //first 4 bits of offsetReserveFlags
        int reserved; // second 6 bits of offsetReserveFlags
        int flags; // third 6 bits of offsetRes
        int window; // last 16 bits of 
        int chesumPointer; //made up of checksum and pointer
        int checksum;
        int urgentPointer;
        int optionsPadding; // made up of options and padding
        int options; //first 24 bytes of optionsPadding
        int padding; // last 8 bits of optionsPadding

        
        int makePorts(int sourcePort, int destPort)
        {
            int ports = (sourcePort << 16) | destPort;
            return ports;
        }
        int makeOffsetReserveFlagsWindow(int dataOffset, int reserved, int flags, int window)
        {
            int myOffsetReserveFlagWindow;
            int newDataOffset = dataOffset << 10;
            int newReserved = reserved << 6;
            int myOffsetReserveFlag = (newDataOffset | newReserved | flags) << 16;
            myOffsetReserveFlagWindow = myOffsetReserveFlag | window;
            return myOffsetReserveFlagWindow;
        }
        int makeOptionsPadding(int options, int padding)
        {
            int optionsPadding = (options << 8) | padding;
            return optionsPadding;
        }

        
    }
}
