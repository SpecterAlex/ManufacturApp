using ColmenApp.Models.Requests;
using Refit;
using System.Threading.Tasks;
using ColmenApp.Models.Responses;
using ColmenApp.Models;
using ColmenApp.Models.Responses.Pagination;

namespace ColmenApp.Interfaces
{
    public interface IApiService
    {
        [Post("/auth/login")]
        Task<ResponseApi<LoginResponse>> LoginUser([Body] LoginRequest model);

        [Get("/customers")]
        Task<ResponsePaginate<Customer>> GetAllCustomers([AliasAs("page")] int page, [Header("Authorization")] string bearerToken);
    }
}
