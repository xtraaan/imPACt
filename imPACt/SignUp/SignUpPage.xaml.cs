using imPACt.Login;
using System;
using System.Linq;
using imPACt.Tables;
using SQLite;
using Xamarin.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace imPACt

{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        //Uncomment if using the ListView
        /*protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetUsersAsync();
        }*/

        private async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            //checking if it is a real email and is a .edu email
            Regex regex = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.(edu)$", RegexOptions.IgnoreCase);

            //Check if content is filled in correctly
            if ( !string.IsNullOrWhiteSpace(usernameEntry.Text)
                && !string.IsNullOrWhiteSpace(passwordEntry.Text)
                && regex.IsMatch(emailEntry.Text)
                && (passwordEntry.Text == RepasswordEntry.Text) 
               )
            {
                //data for filling new user signup
                var newUser = new RegisterUserTable
                {
                    
                    Username = usernameEntry.Text,
                    Password = passwordEntry.Text,
                    Email = emailEntry.Text
                };

             

                /*listView.ItemsSource = await App.Database.GetUsersAsync();*/
                /*string mystring = $"{App.currentUser.UserId}\n{App.currentUser.Username}\n{App.currentUser.Email}\n{App.currentUser.Password}";
                await DisplayAlert("user", mystring, "Ok");*/


                var rootPage = Navigation.NavigationStack.FirstOrDefault();
                if (rootPage != null)
                {
                    App.IsUserLoggedIn = true;
                    //Pass in user so it can be updated and created in database
                    await Navigation.PushAsync(new SignUpInfo(newUser)); 
                }
            }
            else
            {
                await DisplayAlert("Error", "Sign up failed", "OK");
            }


        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
