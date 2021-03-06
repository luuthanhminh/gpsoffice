﻿using System;
using System.Threading.Tasks;
using Flurl.Http;
using gpsoffice.Core.Repositories;
using gpsoffice.Core.Services;
using gpsoffice.Core.Services.Interfaces;
using gpsoffice.Core.ViewModels;
using gpsoffice.UI.Services;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Realms;

namespace gpsoffice.UI
{
    public class CoreApp : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            CreatableTypes()
               .EndingWith("Service")
               .AsInterfaces()
               .RegisterAsLazySingleton();



            RegisterCustomAppStart<CustomMvxAppStart<FirstViewModel>>();

            FlurlHttp.Configure(settings => settings.Timeout = TimeSpan.FromSeconds(15));


            Mvx.IoCProvider.RegisterType<IDialogService, DialogService>();
            Mvx.IoCProvider.RegisterType<IApiService, ApiService>();
            Mvx.IoCProvider.RegisterType<VoucherRepository>();



        }
    }



    public class CustomMvxAppStart<TViewModel> : MvxAppStart<TViewModel>
     where TViewModel : IMvxViewModel
    {
        public CustomMvxAppStart(IMvxApplication application, IMvxNavigationService navigationService) : base(application, navigationService)
        {
        }

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            return NavigationService.Navigate<TViewModel>();
        }

    }


}
