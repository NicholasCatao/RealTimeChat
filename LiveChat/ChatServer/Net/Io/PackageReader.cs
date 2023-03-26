using System.Net.Sockets;
using System.Text;

namespace ChatServer.Net.Io
{
    public class PackageReader: BinaryReader
    {
        private readonly  NetworkStream _networkStream;
        public PackageReader(NetworkStream networkStream): base(networkStream)
        {
            _networkStream = networkStream;
        }

        public string ReadMessage()
        {
            var lenght = ReadInt32();
            var msgBuffer = new byte[lenght];
            _networkStream.Read(msgBuffer, 0, lenght);

            return Encoding.ASCII.GetString(msgBuffer);

        }
    }
}
