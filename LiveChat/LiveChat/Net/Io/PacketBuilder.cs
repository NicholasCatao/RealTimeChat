using System;
using System.IO;
using System.Text;

namespace LiveChat.Net.Io
{
    public class PacketBuilder
    {
        private readonly MemoryStream _memoryStream;

        public PacketBuilder(MemoryStream memoryStream)
        {
            _memoryStream = new MemoryStream();
        }

        public void WriteOpCode(byte opCode)
        {
            _memoryStream .WriteByte(opCode);    
        }

        public  void WriteStream(string msg )
        {
            var msgLength = msg.Length;

            _memoryStream.Write(BitConverter.GetBytes(msgLength));
            _memoryStream.Write(Encoding.ASCII.GetBytes(msg));
        }

        public byte[] GetPacketsBytes()
        {
             return _memoryStream.ToArray();
        }
    }
}
