using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTCP
{
    public class TCPBody
    {
        public Byte[] makeByteArray<T>(T incoming)
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (incoming == null)
                return null;
            using (var memStream = new MemoryStream())
            {     
                bf.Serialize(memStream, incoming);
                byte[] returnStream = memStream.ToArray();
                return returnStream;
            }
        }
    }
}
