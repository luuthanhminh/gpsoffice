using System;
using gpsoffice.Core.ViewModels;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

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

            RegisterAppStart<FirstViewModel>();


        }
    }
}
