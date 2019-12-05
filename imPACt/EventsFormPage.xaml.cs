using imPACt.Tables;
using System;
using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;
using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.IO;

namespace imPACt
{
    public partial class EventsFormPage : ContentPage
    {
        Events Event1 = new Events();
        public EventsFormPage()
        {
            InitializeComponent();
            
            //getting photo to display into image source
            pickPhoto.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }
                var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

                });

                if (file == null)
                    return;

                var memoryStream = new MemoryStream();
                file.GetStream().CopyTo(memoryStream);
                Event1.ImageBytes = memoryStream.ToArray();

                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;

                });

                
            };
        }

        
        //Create event and add to database then pop back to eventpage
        private async void CreateButton(object sender, EventArgs e)
        {

            Event1.Title = eventName.Text;
            Event1.Description = descriptionName.Text;
            Event1.Owner = App.currentUser.FullName;
            
            

            await App.Database.SaveEventAsync(Event1);
            
            await Navigation.PopAsync();
        }

        //go back to events
        private async void CancelButton(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


        //Getting data on click
        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            Event1.EventDate = date.Date;
        }
    }
}
