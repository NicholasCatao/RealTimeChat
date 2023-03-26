using LiveChat.MVVM.Core;
using LiveChat.Net;
using System.Runtime.Serialization;

namespace LiveChat.MVVM.ViewModel
{
    public class MainViewModel
    {
        public RelayCommand ConnectToServerCommand { get; set; }
        public string UserName { get; set; }

        private readonly Server _Server;

        public MainViewModel()
        {
            _Server = new Server();
            ConnectToServerCommand = new RelayCommand(o => _Server.ConnecToServer(UserName), o => !string.IsNullOrEmpty(UserName));
        }
    }
}
