using System;
namespace gpsoffice.Core.Data.ItemViewModels
{
    public class VoucherItemViewModel : BaseItemViewModel
    {
        private int _autoid;
        public int Autoid
        {
            get
            {
                return _autoid;
            }
            set
            {
                SetProperty(ref _autoid, value);
            }
        }

        private string _narration;
        public string Narration
        {
            get
            {
                return _narration;
            }
            set
            {
                SetProperty(ref _narration, value);
            }
        }

        private string _voucherNumber;
        public string VoucherNumber
        {
            get
            {
                return _voucherNumber;
            }
            set
            {
                SetProperty(ref _voucherNumber, value);
            }
        }

        private string _voucherDate;
        public string VoucherDate
        {
            get
            {
                return _voucherDate;
            }
            set
            {
                SetProperty(ref _voucherDate, value);
            }
        }

        private string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                SetProperty(ref _userName, value);
            }
        }
    }
}
