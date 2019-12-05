using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using imPACt.Tables;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace imPACt.Matching
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchPage : ContentPage
    {
        public MatchPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //Remove current user from list
            var users = await App.Database.GetUsersAsync();
            List<RegisterUserTable> list = new List<RegisterUserTable>();


            /*
             * 
             * taking all users and adding to list if they meet criteria and major
             * 
             * 
             */
            foreach (var user in users)
            {
                if (user.UserId != App.currentUser.UserId)
                {
                    if (App.currentUser.Year == "Freshman" || App.currentUser.Year == "Sophomore" || App.currentUser.Year == "Junior" || App.currentUser.Year == "Senior")
                    {
                        if (user.Year == "Graduate" || user.Year == "Ph.d" || user.Year == "Professor")
                        {
                            list.Add(user);
                        }
                    }
                    else
                    {
                        if (user.Year == "Freshman" || user.Year == "Sophomore" || user.Year == "Junior" || user.Year == "Senior")
                        {
                            list.Add(user);
                        }
                    }
                }
            }

            //if list is empty then display alert other wise add to listView
            if (list.Count() != 0)
                listView.ItemsSource = list;
            else
                await DisplayAlert("No Matches Found", "Try again later...", "Okay", "Cancel");
        }



        //Take the current listView data and sent to connectProfile for info on user tapped
        async void OnProfileButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var user = button.BindingContext as RegisterUserTable;
            await Navigation.PushAsync(new ConnectProfilePage(user));
        }

    }
}