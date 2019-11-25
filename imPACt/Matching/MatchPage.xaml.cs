using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            listView.ItemsSource = await App.Database.GetUsersAsync();
        }

        private async void OnCreate(object sender)
        {
            listView.ItemsSource = await App.Database.GetUsersAsync();
        }
    }
}