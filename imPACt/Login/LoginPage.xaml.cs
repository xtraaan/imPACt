using System;
using System.IO;
using imPACt.Tables;
using SQLite;
using Xamarin.Forms;

namespace imPACt
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        void OnLoginButtonClicked(object sender, EventArgs e)
        {

            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);

            var myquery = db.Table<RegisterUserTable>().Where(u => u.Username.Equals(usernameEntry.Text) && u.Password.Equals(passwordEntry.Text)).FirstOrDefault();

            if (myquery != null)
            {
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }
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


            //         var user = new User {
            //	Username = usernameEntry.Text,
            //	Password = passwordEntry.Text
            //};

            //var isValid = AreCredentialsCorrect (user);
            //if (isValid) {
            //	App.IsUserLoggedIn = true;
            //	Navigation.InsertPageBefore (new MainPage (), this);
            //	await Navigation.PopAsync ();
            //} else {
            //	messageLabel.Text = "Login failed";
            //	passwordEntry.Text = string.Empty;
            //}
        }

        bool AreCredentialsCorrect(User user)
        {
            return user.Username == Constants.Username && user.Password == Constants.Password;
        }
    }
}
