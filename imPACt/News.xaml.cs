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
    public partial class News : ContentPage
    {
        public News()
        {
            InitializeComponent();

            this.BindingContext = this;

            newsName.Text = App.currentUser.NewsTitle;
            newsDescription.Text = App.currentUser.NewsDescription;
            newsDate.Text = App.currentUser.NewsDate;
            newsAuthor.Text = App.currentUser.FullName;
        }
    }

}
