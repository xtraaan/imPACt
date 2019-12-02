using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace imPACt
{
    public partial class EventsFormPage : ContentPage
    {
        public EventsFormPage(EventApp impactevent = null)
        {
            InitializeComponent();

            if(impactevent != null)
            {
                //check
                ((EventsFormApp)BindingContext).ImpactEvent = impactevent;
            }
        }

        //private async void CreateButton(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new EventsPage());
        //}

        //private async void CancelButton(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new MainPage());
        //}

        private void Button_Clicked(object sender, EventArgs e)
        {
            EventApp impactevent = ((EventsFormApp)BindingContext).ImpactEvent;

            if(impactevent.ImpactEventId == 0)
            {
                impactevent.PictureUrl = "icon.png";
            }

            MessagingCenter.Send(this, "EventsForm", impactevent);

            Navigation.PopAsync();
        }
    }
}
