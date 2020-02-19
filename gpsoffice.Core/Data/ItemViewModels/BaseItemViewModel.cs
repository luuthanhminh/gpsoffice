using System;
using MvvmCross.ViewModels;

namespace gpsoffice.Core.Data.ItemViewModels
{
    public class BaseItemViewModel : MvxViewModel
    {
        public MvxViewModel ParentViewModel { get; set; }
    }
}
