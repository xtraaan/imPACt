using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using imPACt.Tables;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace imPACt.Matching
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Connections : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public Connections()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            List<RegisterUserTable> matches = new List<RegisterUserTable>();

            foreach (var user in App.currentUser.Matches.ToList())
            {
                if (user.Major == App.currentUser.Major)
                {
                    matches.Add(user);
                }
            }

            listView2.ItemsSource = matches;
        }
    }
}
