using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using imPACt.Tables;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace imPACt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public  ProfilePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //BindingContext = new ProfilePageViewModel();
            name.Text = App.currentUser.FirstName + " " + App.currentUser.LastName;
            researchInterests.Text = "  " + App.currentUser.ResearchInterest;
            major.Text = "  " + App.currentUser.Major;
            gradeYear.Text = "  " + App.currentUser.Year;
            school.Text = "  " + App.currentUser.School;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            name.Text = "  " + App.currentUser.FirstName + " " + App.currentUser.LastName;
            researchInterests.Text = "  " + App.currentUser.ResearchInterest;
            major.Text = "  " + App.currentUser.Major;
            gradeYear.Text = "  " + App.currentUser.Year;
            school.Text = "  " + App.currentUser.School;

            var users = await App.Database.GetFriendAsync();
            List<Friends> list = new List<Friends>();

            foreach (var ev in users)
            {
                if (App.currentUser.UserId == ev.userID)
                {
                    list.Add(ev);
                }
            }

            var match = await App.Database.GetUsersAsync();
            List<RegisterUserTable> matches = new List<RegisterUserTable>();

            foreach (var ev in match)
            {
                foreach (var fr in list)
                {
                    if (ev.UserId == fr.FriendID)
                    {
                        matches.Add(ev);
                    }
                }

            }

            listView2.ItemsSource = matches;

        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}