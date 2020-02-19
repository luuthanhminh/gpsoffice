using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using gpsoffice.Core.Data.ItemViewModels;
using gpsoffice.Core.Services;
using gpsoffice.Core.Services.Interfaces;
using gpsoffice.Core.ViewModels.Base;
using MvvmCross.Navigation;

namespace gpsoffice.Core.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        readonly IApiService _apiService;

        public FirstViewModel(IMvxNavigationService navigationService, IDialogService dialogService, IApiService apiService) : base(navigationService, dialogService)
        {
            _apiService = apiService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            LoadData();
        }

        #region Properties

        private ObservableCollection<VoucherItemViewModel> _vouchers = new ObservableCollection<VoucherItemViewModel>();
        public ObservableCollection<VoucherItemViewModel> Vouchers
        {
            get
            {
                return _vouchers;
            }
            set
            {
                SetProperty(ref _vouchers, value);
            }
        }

        private bool _hasNoData;
        public bool HasNoData
        {
            get
            {
                return _hasNoData;
            }
            set
            {
                SetProperty(ref _hasNoData, value);
            }
        }

        #endregion

        #region Methods

        async void LoadData()
        {
            try
            {
                ShowLoading();

                var res = await _apiService.GetVouchers(5);

                if (res.IsSuccess)
                {
                    Vouchers = new ObservableCollection<VoucherItemViewModel>(res.ResponseObject.Select(v => new VoucherItemViewModel()
                    {
                        ParentViewModel = this,
                        Autoid = v.Autoid,
                        UserName = v.UserName,
                        VoucherDate = v.VoucherDate,
                        VoucherNumber = v.VoucherNumber,
                        Narration = v.Narration
                    }));
                }
                else
                {
                    await _dialogService.ShowMessage("Error", String.Join(Environment.NewLine, res.Errors), "Close");
                }

                //var vouchers = new List<VoucherItemViewModel>()
                //{
                //    new VoucherItemViewModel()
                //    {
                //        Autoid = 84170,
                //        Narration = "chq no 582009",
                //        UserName = "YATIN-PC",
                //        VoucherNumber = "5927",
                //        VoucherDate = "2020-03-10T00:00:00"
                //    },
                //    new VoucherItemViewModel()
                //    {
                //        Autoid = 84170,
                //        Narration = "chq no 582009",
                //        UserName = "YATIN-PC",
                //        VoucherNumber = "5927",
                //        VoucherDate = "2020-03-10T00:00:00"
                //    },
                //    new VoucherItemViewModel()
                //    {
                //        Autoid = 84170,
                //        Narration = "chq no 582009",
                //        UserName = "YATIN-PC",
                //        VoucherNumber = "5927",
                //        VoucherDate = "2020-03-10T00:00:00"
                //    }
                //};

                //this.Vouchers = new ObservableCollection<VoucherItemViewModel>(vouchers);

                HasNoData = this.Vouchers.Count == 0;
            }
            catch (Exception ex)
            {
                await _dialogService.ShowMessage("Error", ex.Message, "Close");
            }
            finally
            {
                HideLoading();
            }

        }

        #endregion
    }
}
