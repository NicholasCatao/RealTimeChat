using System.Net.Sockets;

namespace LiveChat.Net
{
    public class Server
    {
       private  readonly TcpClient _tcpClient;

        public Server()
        {
            _tcpClient = new TcpClient();
        }

        public void ConnecToServer(string userName)
        {
            if( _tcpClient.Connected  is false)
            {
                _tcpClient.Connect("127.0.0.1", 50987);
            }
        }
    }
}
