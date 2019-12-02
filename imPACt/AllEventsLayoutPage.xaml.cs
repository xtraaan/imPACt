using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace imPACt
{
    public partial class AllEventsLayoutPage : ContentPage
    {
        public AllEventsLayoutPage()
        {
            InitializeComponent();


            NavigationPage.SetHasNavigationBar(this, false);
        }

        //private async void CreateButton(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new EventsFormPage());
        //}

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EventsFormPage());
        }

        private async void TapGestureRecognizer_Tapped_Edit(object sender, EventArgs e)
        {
            TappedEventArgs tappedEventArgs = (TappedEventArgs)e;

            //check
            EventApp impactevent = ((EventsModel)BindingContext).ImpactEvents.Where(emp => emp.ImpactEventId == (int)tappedEventArgs.Parameter).FirstOrDefault();

            await Navigation.PushAsync(new EventsFormPage(impactevent));
        }


        private async void TapGestureRecognizer_Tapped_Remove(object sender, EventArgs e)
        {
            TappedEventArgs tappedEventArgs = (TappedEventArgs)e;

            //check
            EventApp impactevent = ((EventsModel)BindingContext).ImpactEvents.Where(emp => emp.ImpactEventId == (int)tappedEventArgs.Parameter).FirstOrDefault();

            ((EventsModel)BindingContext).ImpactEvents.Remove(impactevent);
        }

    }
}
