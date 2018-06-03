using System;
using System.ComponentModel;

namespace LgTvController
{
    public class AvailableDevice : INotifyPropertyChanged
    {
        private string ip;
        private string port;
        private string server;
        private string servicePort;
        private string mac;
        private Guid uuid;
        private string usn;

        public AvailableDevice() { }

        public AvailableDevice(string ip, string port, string server, string servicePort, string mac, Guid uuid, string usn)
        {
            this.ip = ip;
            this.port = port;
            this.server = server;
            this.servicePort = servicePort;
            this.mac = mac;
            this.uuid = uuid;
            this.usn = usn;
        }

        public string Ip
        {
            get { return ip; }
            set
            {
                ip = value;
                OnPropertyChanged("Ip");
            }
        }

        public string Port
        {
            get { return port; }
            set
            {
                port = value;
                OnPropertyChanged("Port");
            }
        }

        public string Server
        {
            get { return server; }
            set
            {
                server = value;
                OnPropertyChanged("Server");
            }
        }

        public string ServicePort
        {
            get { return servicePort; }
            set
            {
                servicePort = value;
                OnPropertyChanged("ServicePort");
            }
        }

        public string Mac
        {
            get { return mac; }
            set
            {
                mac = value;
                OnPropertyChanged("Mac");
            }
        }

        public Guid Uuid
        {
            get { return uuid; }
            set
            {
                uuid = value;
                OnPropertyChanged("Uuid");
            }
        }

        public string Usn
        {
            get { return usn; }
            set
            {
                usn = value;
                OnPropertyChanged("Usn");
            }
        }

        private void OnPropertyChanged(string propName)
        {
            PropertyChangedEventArgs args = new PropertyChangedEventArgs(propName);
            PropertyChanged?.Invoke(this, args);
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
