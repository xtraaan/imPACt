using imPACt.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using imPACt;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using imPACt.SignUp;

namespace imPACt.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    

    public partial class SignUpInfo : ContentPage
    {


        // private SQLiteAsyncConnection _connection;
        public RegisterUserTable NewUser;

        public SignUpInfo(RegisterUserTable Newuser)
        {
            InitializeComponent();

            // _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            NewUser = Newuser;


            foreach (var method in GetMajorMethod())
                Major.Items.Add(method.MajorSel);
            foreach (var method in GetResearchMethod())
                ResearchInterests.Items.Add(method.ResearchSel);
            foreach (var method in GetSelectionMethod())
                Year.Items.Add(method.YearSel);
            
        }


        
        private  void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            NewUser.Major = Major.Items[Major.SelectedIndex];
            
            //DisplayAlert("Selection", Maj, "Ok");
            
        }
        private  void ResearchInterests_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewUser.ResearchInterest = ResearchInterests.Items[ResearchInterests.SelectedIndex];
            
           // DisplayAlert("Selection", Res, "Ok");
        }

        private  void Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewUser.Year = Year.Items[Year.SelectedIndex];
        //    DisplayAlert("Selection", Yr, "Ok");

        }

        async void OnSignUpInfoClicked(object sender, EventArgs e)
        {


            //await App._connection;
            //  var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            // var db = new SQLiteConnection(dbpath);
            // db.CreateTable<RegisterUserTable>();

            NewUser.FirstName = FirstnameEntry.Text;
            NewUser.LastName = LastnameEntry.Text;
            NewUser.School = College.Text;


           // await App.Database.SaveUserAsync(NewUser);
            

            //App.currentUser = await App.Database.GetUserAsync(NewUser.UserId);

            /*string mystring = $"{App.currentUser.UserId}\n{App.currentUser.Username}\n{App.currentUser.Email}\n" +
                $"{App.currentUser.Password}\n{App.currentUser.Major}\n{App.currentUser.Year}\n{App.currentUser.ResearchInterest}";
                await DisplayAlert("user", mystring, "Ok");*/

            //NEEDS MORE TO CHECK ALL FIELDS ARE FILLED AND VALID
            var rootPage = Navigation.NavigationStack.FirstOrDefault();
            if (rootPage != null)
            {
                await Navigation.PushAsync(new SignUpPic(NewUser));

                /*Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
                await Navigation.PopToRootAsync();*/
            }
        }


        /*-----------------------------------------------------------------------------------*/

        public class Majors {
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