using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ColmenApp.Interfaces;
using ColmenApp.Models;
using ColmenApp.Models.Requests;
using ColmenApp.Models.Responses;
using ColmenApp.Models.Responses.Pagination;
using Refit;

namespace ColmenApp.Services
{
    class ApiService  : IApiService
    {
        public static string ApiUrl = "http://192.53.170.84/api";

        public async Task<ResponseApi<LoginResponse>> LoginUser([Body] LoginRequest model)
        {
            ResponseApi<LoginResponse> apiResponse = null;
            var apiService = RestService.For<IApiService>(ApiUrl);
            var statusCode = HttpStatusCode.OK;
            try
            {
                apiResponse = await apiService.LoginUser(model);
            }
            catch (ApiException ex)
            {
                statusCode = ex.StatusCode;
            }

            if (statusCode != HttpStatusCode.OK)
            {
                LoginResponse loginResponse = new LoginResponse();
                apiResponse = new ResponseApi<LoginResponse>(ref loginResponse);
            }

            return apiResponse;
        }

        public async Task<ResponsePaginate<Customer>> GetAllCustomers(int page, string bearerToken)
        {
            ResponsePaginate<Customer> apiResponse = null;
            var apiService = RestService.For<IApiService>(ApiUrl);
            
            var statusCode = HttpStatusCode.OK;
            try
            {
                apiResponse = await apiService.GetAllCustomers(page, $"Bearer {bearerToken}");
            }
            catch (ApiException ex)
            {
                statusCode = ex.StatusCode;
            }

            if (statusCode != HttpStatusCode.OK)
            {
                ObservableCollection<Customer> customer = new ObservableCollection<Customer>();
                apiResponse = new ResponsePaginate<Customer>(ref customer);
            }

            return apiResponse;
        }
    }
}
