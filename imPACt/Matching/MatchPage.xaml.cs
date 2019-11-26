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
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //Remove current user from list
            var users = await App.Database.GetUsersAsync();
            List<RegisterUserTable> list = new List<RegisterUserTable>();

            foreach (var user in users)
            {
                if (user.UserId != App.currentUser.UserId)
                    list.Add(user);
            }
            listView.ItemsSource = list;

        }
    }
}