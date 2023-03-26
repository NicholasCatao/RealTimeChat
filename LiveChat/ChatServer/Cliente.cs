using ChatServer.Net.Io;
using System.Net.Sockets;

namespace ChatServer
{
    public class Cliente
    {
        public string UserName { get; set; }
        public Guid id { get; set; }
        public TcpClient ClientSocket { get; set; }

        PackageReader _packageReader;

        public Cliente(TcpClient tcpClient)
        {
            ClientSocket = tcpClient;
            id = Guid.NewGuid();
            _packageReader = new PackageReader(ClientSocket.GetStream());

            var opCode = _packageReader.ReadByte();
            UserName = _packageReader.ReadMessage();

            Console.WriteLine($"{DateTime.Now} : Client has conneted with the user name : {UserName}");

        }
    }
}
