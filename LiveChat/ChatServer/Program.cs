
using ChatServer;
using System.Net;
using System.Net.Sockets;

public class Program
{

   private static TcpListener _tcpListener = null;
   private static List<Cliente> _users;
    private static void Main(string[] args)
    {
        _tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 50987);
        _tcpListener.Start();

        while (true)
        {
            var cliente = new Cliente(_tcpListener.AcceptTcpClient());
            _users.Add(cliente);
        }



        //BroadCast for everyone
    }
}