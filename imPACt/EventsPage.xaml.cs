using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace imPACt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventsPage : ContentPage
    {
        public EventsPage()
        {
            InitializeComponent();

            eventName.Text = App.currentUser.EventName;
            eventDescription.Text = App.currentUser.EventDescription;
            eventDate.Text = App.currentUser.EventDate;
            eventSponsor.Text = App.currentUser.EventSponsor;
            //this.BindingContext = this;
        }
    }
}