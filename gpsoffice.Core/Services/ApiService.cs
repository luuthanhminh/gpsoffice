using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using gpsoffice.Core.Data.Models;
using gpsoffice.Core.Helpers;

namespace gpsoffice.Core.Services
{
    public class ApiService : IApiService
    {
        #region EndPoints

        const string VOUCHERS_ENDPOINT = AppConstant.API_ENDPOINT + "/vouchers";

        #endregion

        public async Task<ApiResponse<List<Voucher>>> GetVouchers(int id)
        {
            return await DoGet<List<Voucher>>($"{VOUCHERS_ENDPOINT}/{id}");
        }

        #region Methods
        protected async Task<ApiResponse<T>> DoGet<T>(string url)
        {
            ApiResponse<T> result = null;
            try
            {
                var res = await url.GetJsonAsync<T>();

                result = new ApiResponse<T>()
                {
                    IsSuccess = true,
                    ResponseStatusCode = 200,
                    ResponseObject = res
                };

            }
            catch (FlurlHttpTimeoutException fhte)
            {
                result = new ApiResponse<T>()
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Timeout" },
                    ResponseStatusCode = fhte.Call.HttpStatus.HasValue ? (int)fhte.Call.HttpStatus.Value : 500
                };
            }
            catch (FlurlHttpException fhx)
            {
                result = new ApiResponse<T>()
                {
                    IsSuccess = false,
                    Errors = new List<string>() { fhx.Message },
                    ResponseStatusCode = fhx.Call.HttpStatus.HasValue ? (int)fhx.Call.HttpStatus.Value : 500
                };
            }

            catch (Exception ex)
            {
                result = new ApiResponse<T>()
                {
                    IsSuccess = false,
                    Errors = new List<string>() { ex.Message },
                    ResponseStatusCode = 500
                };
            }

            return result;
        }
        #endregion
    }
}
