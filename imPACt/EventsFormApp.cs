using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace imPACt
{
    public class EventsFormApp : INotifyPropertyChanged
    {
        private EventApp _impactevent;

        public EventApp ImpactEvent
        {
            get { return _impactevent; }
            set { _impactevent = value; OnPropertyChanged(); }
        }

        public EventsFormApp()
        {
            ImpactEvent = new EventApp();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null){
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
