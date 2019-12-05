using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace imPACt
{
    public partial class SettingsPage : ContentPage
    {
        string Mjr, Yr, RsrchInt;
        public SettingsPage()
        {
            InitializeComponent();

            //adding them to list for pickers
            foreach (var method in GetMajorMethod())
                Major.Items.Add(method.MajorSel);
            foreach (var method in GetResearchMethod())
                ResearchInterests.Items.Add(method.ResearchSel);
            foreach (var method in GetSelectionMethod())
                Year.Items.Add(method.YearSel);
        }

        

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {

            Mjr = Major.Items[Major.SelectedIndex];

            //DisplayAlert("Selection", Maj, "Ok");

        }
        private void ResearchInterests_SelectedIndexChanged(object sender, EventArgs e)
        {
            RsrchInt = ResearchInterests.Items[ResearchInterests.SelectedIndex];

            // DisplayAlert("Selection", Res, "Ok");
        }

        private void Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            Yr = Year.Items[Year.SelectedIndex];
            //    DisplayAlert("Selection", Yr, "Ok");

        }

        private async void ToolbarItem_Activated(object sender, EventArgs e)
        {

            /*
             * 
             * Go through each one to check if field has been changed and if it has save to current user
             * 
             * */
            if(!string.IsNullOrWhiteSpace(FirstnameEntry.Text))
                App.currentUser.FirstName = FirstnameEntry.Text;

            if (!string.IsNullOrWhiteSpace(LastnameEntry.Text))
                App.currentUser.LastName = LastnameEntry.Text;

            if (!string.IsNullOrWhiteSpace(Yr))
                App.currentUser.Year = Yr;

            if (!string.IsNullOrWhiteSpace(Mjr))
                App.currentUser.Major = Mjr;

            if (!string.IsNullOrWhiteSpace(RsrchInt))
                App.currentUser.ResearchInterest = RsrchInt;

            //Update current users database
            await App.Database.UpdateUser();

            //Display it has been saved
            await DisplayAlert("Saved", "Settings Saved", "Ok");

        }



        public class Majors
        {
            public string MajorSel { get; set; }
        }

        public class Research
        {
            public string ResearchSel { get; set; }
        }
        public class Years
        {
            public string YearSel { get; set; }
        }


        //List of Majors Added to the list
        private IList<Majors> GetMajorMethod()
        {
            return new List<Majors>{

                    new Majors { MajorSel = "Applied Mathematics" },
                    new Majors { MajorSel = "Architectural Engineering" },
                    new Majors { MajorSel = "Bioengineering" },
                    new Majors { MajorSel = "Biophysics" },
                    new Majors { MajorSel = "Biochemistry" },
                    new Majors { MajorSel = "Chemical Engineering" },
                    new Majors { MajorSel = "Computer Science" },
                    new Majors { MajorSel = "Civil Engineering" },
                    new Majors { MajorSel = "Computer Engineering" },
                    new Majors { MajorSel = "Electrical Engineering" },
                    new Majors { MajorSel = "Engineering Science" },
                    new Majors { MajorSel = "Math" },
                    new Majors { MajorSel = "Mechanical Engineering" },
                    new Majors { MajorSel = "Nuclear Engineering" },
                    new Majors { MajorSel = "Physics" },



            };

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new LoginPage(), Navigation.NavigationStack[0]);
            await Navigation.PopToRootAsync();
        }

        private IList<Research> GetResearchMethod()
        {
            return new List<Research>
            {
                new Research { ResearchSel = "Artificial Intelligence"},
                new Research { ResearchSel = "Machine Learning"},
                new Research { ResearchSel = "Game Design"},
                new Research { ResearchSel = "That one thing"},
                new Research { ResearchSel = "Virtual Reality"},
                new Research { ResearchSel = "Data Analytics"},
                new Research { ResearchSel = "Computer Networks"},

            };
        }

        private IList<Years> GetSelectionMethod()
        {
            return new List<Years>
            {
                new Years { YearSel = "Freshman"},
                new Years { YearSel = "Sophomore"},
                new Years { YearSel = "Junior"},
                new Years { YearSel = "Senior"},
                new Years { YearSel = "Graduate"},
                new Years { YearSel = "Ph.D"},
                new Years { YearSel = "Professor"},
            };
        }
    }
}
