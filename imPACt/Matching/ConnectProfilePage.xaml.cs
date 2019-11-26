
using Xamarin.Forms;

namespace imPACt.Matching
{
    public partial class ConnectProfilePage : ContentPage
    {
        public ConnectProfilePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var users = await App.Database.GetUsersAsync();
            foreach (var user in users)
            {
                name.Text = user.FullName;
                researchInterests.Text = user.ResearchInterest;
                major.Text = user.Major;
                gradeYear.Text = user.Year;
            }
        }
    }
}
