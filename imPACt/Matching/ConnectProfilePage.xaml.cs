
using imPACt.Tables;
using Xamarin.Forms;

namespace imPACt.Matching
{
    public partial class ConnectProfilePage : ContentPage
    {
        public RegisterUserTable ClickedUser;
        public ConnectProfilePage(RegisterUserTable user)
        {

            InitializeComponent();
            ClickedUser = user;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            name.Text = ClickedUser.FullName;
            researchInterests.Text = ClickedUser.ResearchInterest;
            major.Text = ClickedUser.Major;
            gradeYear.Text = ClickedUser.Year;

        }
    }
}

