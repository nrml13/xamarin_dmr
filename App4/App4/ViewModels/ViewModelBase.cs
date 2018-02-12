using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged<T>(ref T prop, T val, [CallerMemberName] string propName = "")
        {
            if ((prop == null) || (prop != null && !prop.Equals(val)))
            {
                prop = val;
                RaisePropertyChanged(propName);
            }
        }

        public void RaisePropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
