using System;
using System.Collections.Generic;
using gpsoffice.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms;

namespace gpsoffice.UI.Pages
{
    [MvxContentPagePresentation()]
    public partial class FirstPage : BasePage<FirstViewModel>
    {
        public FirstPage()
        {
            InitializeComponent();

        }
    }
}
