﻿using imPACt.Tables;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace imPACt.SignUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPic : ContentPage
    {
        public RegisterUserTable NewUser;
        
        public SignUpPic(RegisterUserTable Newuser)
        {
            InitializeComponent();
            NewUser = Newuser;



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
                Newuser.ImageBytes = memoryStream.ToArray();

                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;

                });


            };
        }
        

        public async void Button_Clicked(object sender, EventArgs e)
        {
            if (NewUser.ImageBytes != null) {
                await App.Database.SaveUserAsync(NewUser);
                App.currentUser = await App.Database.GetUserAsync(NewUser.UserId);

                Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
                await Navigation.PopToRootAsync();
            }
            //else
            //{
            //    await DisplayAlert("No Photo", "Upload Photo", "Ok");
            //}

            
        }
    }
}