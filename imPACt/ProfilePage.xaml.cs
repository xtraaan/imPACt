using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            researchInterests.Text = App.currentUser.ResearchInterest;
            major.Text = App.currentUser.Major;
            gradeYear.Text = App.currentUser.Year;


        }
    }
}