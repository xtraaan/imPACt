﻿using System;
using System.Collections.Generic;
using imPACt.Tables;
using Xamarin.Forms;

namespace imPACt
{
    public partial class EventsPage : ContentPage
    {
        Events clickedContent = new Events();
        public EventsPage(Events content)
        {
            InitializeComponent();
            clickedContent = content;
            //NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void UpdateButton(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        //private async void InviteMembersButton(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new EventsLayoutPage());
        //}
    }
}
