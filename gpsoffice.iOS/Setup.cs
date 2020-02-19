﻿using System;
using gpsoffice.iOS.Presenter;
using gpsoffice.UI;
using MvvmCross;
using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmCross.Forms.Presenters;
using MvvmCross.Platforms.Ios.Presenters;

namespace gpsoffice.iOS
{
    public class Setup : MvxFormsIosSetup<CoreApp, App>
    {
        protected override IMvxIosViewPresenter CreateViewPresenter()
        {
            var presenter = new IosCustomPresenter(this.ApplicationDelegate, this.Window, this.FormsApplication);
            Mvx.IoCProvider.RegisterSingleton<IMvxFormsViewPresenter>(presenter);
            return presenter;
        }

    }
}
