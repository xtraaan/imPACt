﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace imPACt
{
    public partial class NewsFormPage : ContentPage
    {
        public NewsFormPage()
        {
            InitializeComponent();
        }

        async void OnCreateNewsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new News());
        }
    }
}
