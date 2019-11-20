using imPACt.Login;
using System;
using System.Linq;
using imPACt.Tables;
using SQLite;
using Xamarin.Forms;
using System.IO;

namespace imPACt

{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {

            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<RegisterUserTable>();

            var user = new RegisterUserTable()
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text,
                Email = emailEntry.Text
            };



            if (!string.IsNullOrWhiteSpace(user.Username) && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@"))
            {
                db.Insert(user);
                var rootPage = Navigation.NavigationStack.FirstOrDefault();
                if (rootPage != null)
                {
                    App.IsUserLoggedIn = true;
                    Navigation.InsertPageBefore(new SignUpInfo(), Navigation.NavigationStack.First());
                    await Navigation.PopToRootAsync();
                }
                else
                {
                    messageLabel.Text = "Sign up failed";
                }


            }


        }
    }
}
