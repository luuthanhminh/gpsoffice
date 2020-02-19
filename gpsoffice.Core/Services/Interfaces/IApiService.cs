using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using gpsoffice.Core.Data.Models;
using gpsoffice.Core.Helpers;

namespace gpsoffice.Core.Services
{
    public interface IApiService
    {
        Task<ApiResponse<List<Voucher>>> GetVouchers(int id);
    }
}
