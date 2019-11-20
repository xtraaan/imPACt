using System;
using System.IO;
using System.Linq;
using imPACt.Tables;
using SQLite;
using Xamarin.Forms;

namespace imPACt

{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        void OnSignUpButtonClicked(object sender, EventArgs e)
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

            db.Insert(user);



            // Sign up logic goes here

            //var signUpSucceeded = AreDetailsValid (user);
            //if (signUpSucceeded) {
            //	var rootPage = Navigation.NavigationStack.FirstOrDefault ();
            //	if (rootPage != null) {
            //		App.IsUserLoggedIn = true;
            //		Navigation.InsertPageBefore (new MainPage (), Navigation.NavigationStack.First ());
            //		await Navigation.PopToRootAsync ();
            //	}
            //} else {
            //	messageLabel.Text = "Sign up failed";
            //}
        }

        bool AreDetailsValid(User user)
        {
            return (!string.IsNullOrWhiteSpace(user.Username) && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@"));
        }
    }
}
