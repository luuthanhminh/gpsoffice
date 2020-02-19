using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using gpsoffice.Core.Data.DTOs;
using gpsoffice.Core.Data.ItemViewModels;
using gpsoffice.Core.Repositories;
using gpsoffice.Core.Services;
using gpsoffice.Core.Services.Interfaces;
using gpsoffice.Core.ViewModels.Base;
using MvvmCross.Navigation;
using Xamarin.Essentials;

namespace gpsoffice.Core.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        readonly IApiService _apiService;

        readonly VoucherRepository _voucherRepository;

        public FirstViewModel(IMvxNavigationService navigationService, IDialogService dialogService, IApiService apiService
            , VoucherRepository voucherRepository) : base(navigationService, dialogService)
        {
            _apiService = apiService;
            _voucherRepository = voucherRepository;
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
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    // Connection to internet is available

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

                        // update local db

                        await _voucherRepository.AddOrUpdateItems(res.ResponseObject.Select(v => new VoucherDTO()
                        {
                            Autoid = v.Autoid,
                            UserName = v.UserName,
                            VoucherDate = v.VoucherDate,
                            VoucherNumber = v.VoucherNumber,
                            Narration = v.Narration
                        }).ToList());
                    }
                    else
                    {
                        await _dialogService.ShowMessage("Error", String.Join(Environment.NewLine, res.Errors), "Close");
                    }
                }
                else
                {
                    // get data from local db

                    var vouchers = _voucherRepository.GetAll();

                    this.Vouchers = new ObservableCollection<VoucherItemViewModel>(vouchers.Select(v => new VoucherItemViewModel()
                    {
                        ParentViewModel = this,
                        Autoid = v.Autoid,
                        UserName = v.UserName,
                        VoucherDate = v.VoucherDate,
                        VoucherNumber = v.VoucherNumber,
                        Narration = v.Narration
                    }));
                }

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
