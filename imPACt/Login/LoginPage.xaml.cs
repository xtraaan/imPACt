using System;
using Xamarin.Forms;
using imPACt.Tables;
using SQLite;
using System.IO;

namespace imPACt
{
	public partial class LoginPage : ContentPage
	{
       
		public LoginPage ()
		{
            

			InitializeComponent ();
		}

		async void OnSignUpButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new SignUpPage ());
		}

         async void  OnLoginButtonClicked(object sender, EventArgs e)
        {

            //Checking if the username and password exists
            var myquery = await App.Database.QueryUserAsync(usernameEntry.Text, passwordEntry.Text);
            //await DisplayAlert("User", myquery.ToString(), "Ok");
            
            //If query is not null that means user exists
            if (myquery != null)
            {
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }

            //logic needs to be fixed because app crashes if its incorrect
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Error", "Failed Username and Password", "Okay", "Cancel");
                    if (result)
                    {
                        passwordEntry.Text = string.Empty;
                    }
                });
            }
        }
	}
}
