using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace imPACt.Matching
{
    public partial class MainMatchPage : CarouselPage
    {
        public MainMatchPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
