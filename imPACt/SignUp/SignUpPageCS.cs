using imPACt.Login;
using System;
using System.Linq;
using Xamarin.Forms;

namespace imPACt

{
	public class SignUpPageCS : ContentPage
	{
		Entry usernameEntry, passwordEntry, emailEntry;
		Label messageLabel;

		public SignUpPageCS ()
		{
			messageLabel = new Label ();
			usernameEntry = new Entry {
				Placeholder = "username"	
			};
			passwordEntry = new Entry {
				IsPassword = true
			};
			emailEntry = new Entry ();
			var signUpButton = new Button {
				Text = "Sign Up"
			};
			signUpButton.Clicked += OnSignUpButtonClicked;

			Title = "Sign Up";
			Content = new StackLayout { 
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					new Label { Text = "Username" },
					usernameEntry,
					new Label { Text = "Password" },
					passwordEntry,
					new Label { Text = "Email address" },
					emailEntry,
					signUpButton,
					messageLabel
				}
			};
		}

		async void OnSignUpButtonClicked (object sender, EventArgs e)
		{

            //Data Entry
			var user = new User () {
				Username = usernameEntry.Text,
				Password = passwordEntry.Text,
				Email = emailEntry.Text
			};


			// Sign up logic goes here
			var signUpSucceeded = AreDetailsValid (user);
			if (signUpSucceeded) {
				var rootPage = Navigation.NavigationStack.FirstOrDefault ();
				if (rootPage != null) {
					App.IsUserLoggedIn = true;
                    //	Navigation.InsertPageBefore (new SignUpPage (), Navigation.NavigationStack.First ());
                    //	await Navigation.PopToRootAsync ();
                    //Navigation.InsertPageBefore(new SignUpInfo(), this);
                    await Navigation.PushAsync(new SignUpInfo ());
				}
			} else {
				messageLabel.Text = "Sign up failed";
			}
		}

		bool AreDetailsValid (User user)
		{
			return (!string.IsNullOrWhiteSpace (user.Username) && !string.IsNullOrWhiteSpace (user.Password) && !string.IsNullOrWhiteSpace (user.Email) && user.Email.Contains ("@") && user.Email.Contains(".edu"));
		}
	}
}
