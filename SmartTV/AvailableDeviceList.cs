using System.Collections.Generic;
using System.ComponentModel;

namespace LgTvController
{
    public class AvailableDeviceList : INotifyPropertyChanged
    {
        public List<AvailableDevice> availableDevList = new List<AvailableDevice>();

        public void Load(AvailableDevice ad)
        {
            availableDevList.Add(ad);
            OnPropertyChanged("AvailableDevList");
        }
        
        private void OnPropertyChanged(string propName)
        {
            PropertyChangedEventArgs args = new PropertyChangedEventArgs(propName);
            PropertyChanged?.Invoke(this, args);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
