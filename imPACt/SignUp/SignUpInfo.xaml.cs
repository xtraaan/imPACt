using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace imPACt.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpInfo : ContentPage
    {
        
        public class MajorsMethod
        {
            public string MajorSel { get; set; }
            
        }
        public class ResearchMethod
        {
            public string ResearchSel { get; set; }

        }



        public SignUpInfo()
        {
            InitializeComponent();

            foreach (var method in GetMajorMethod())
                Major.Items.Add(method.MajorSel);
            foreach (var method in GetResearchMethod())
                ResearchInterests.Items.Add(method.ResearchSel);
        }


        
        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Maj = Major.Items[Major.SelectedIndex];
            
            DisplayAlert("Selection", Maj, "Ok");
            
        }
        private void ResearchInterests_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Res = ResearchInterests.Items[ResearchInterests.SelectedIndex];

            DisplayAlert("Selection", Res, "Ok");
        }

        async void OnSignUpInfoClicked(object sender, EventArgs e)
        {
           //NEEDS MORE TO CHECK ALL FIELDS ARE FILLED AND VALID
            var rootPage = Navigation.NavigationStack.FirstOrDefault();
            if (rootPage != null)
            {
                Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
                await Navigation.PopToRootAsync();
            }
        }

        //List of Majors Added to the list
        private IList<MajorsMethod> GetMajorMethod()
        {
            return new List<MajorsMethod>{
                new MajorsMethod { MajorSel = "Computer Science"},
                new MajorsMethod { MajorSel = "Art"},
                new MajorsMethod { MajorSel = "Math"},
                new MajorsMethod { MajorSel = "English"},
                

            };
           
        }

        private IList<ResearchMethod> GetResearchMethod()
        {
            return new List<ResearchMethod>{
                new ResearchMethod { ResearchSel = "Artificial Intelligence"},
                new ResearchMethod { ResearchSel = "Machine Learning"},
                new ResearchMethod { ResearchSel = "Game Design"},
                new ResearchMethod { ResearchSel = "That one thing"},


            };

        }


    }
}