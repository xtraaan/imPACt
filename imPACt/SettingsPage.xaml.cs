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
            App.currentUser.FirstName = FirstnameEntry.Text;
            App.currentUser.LastName = LastnameEntry.Text;
            App.currentUser.Major = Mjr;
            App.currentUser.Year = Yr;
            App.currentUser.FirstName = RsrchInt;

            await App.Database.UpdateUser();
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
                new Majors { MajorSel = "Accounting" },

            new Majors { MajorSel = "Applied Mathematics" },
            new Majors { MajorSel = "Architectural Engineering" },
            new Majors { MajorSel = "Architecture" },
            new Majors { MajorSel = "Biochemistry" },
            new Majors { MajorSel = "Bioengineering" },
            new Majors { MajorSel = "Biophysics" },
            new Majors { MajorSel = "Chemical Engineering" },
            new Majors { MajorSel = "Computer Science" },
            new Majors { MajorSel = "Civil Engineering" },
            new Majors { MajorSel = "Computer Engineering" },
            new Majors { MajorSel = "Electrical Engineering" },
            new Majors { MajorSel = "Engineering Science" },
            new Majors { MajorSel = "Mechanical Engineering" },
            new Majors { MajorSel = "Microbiology" },
            new Majors { MajorSel = "Nuclear Engineering" },


            };

        }

        private IList<Research> GetResearchMethod()
        {
            return new List<Research>
            {
                new Research { ResearchSel = "Artificial Intelligence"},
                new Research { ResearchSel = "Machine Learning"},
                new Research { ResearchSel = "Game Design"},
                new Research { ResearchSel = "That one thing"},
            };
        }

        private IList<Years> GetSelectionMethod()
        {
            return new List<Years>
            {
                new Years { YearSel = "Freshman"},
                new Years { YearSel = "Sophmore"},
                new Years { YearSel = "Junior"},
                new Years { YearSel = "Senior"},
                new Years { YearSel = "Graduate"},
                new Years { YearSel = "Ph.d"},
                new Years { YearSel = "Professor"},
            };
        }
    }
}
