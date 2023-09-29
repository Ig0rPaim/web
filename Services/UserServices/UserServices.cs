using BuilderAux_MVC.Models;
using BuilderAux_MVC.Services.IServices;
using BuilderAux_MVC.Utils;

namespace BuilderAux_MVC.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly HttpClient _httpClient;
        public const string BasePath = "api/v1/User";

        public UserServices(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<UserVOModel>> GetAllUsers()
        {
            var Response = await _httpClient.GetAsync(BasePath);
            return await Response.ReadContentAs<List<UserVOModel>>();
        }

        public async Task<UserVOModel> GetUsersById(int Id)
        {
            var Response = await _httpClient.GetAsync($"{BasePath}/{Id}");
            return await Response.ReadContentAs<UserVOModel>();
        }

        public async Task<UserVOModel> CreateUser(UserVOModel user)
        {
            var Response = await _httpClient.PostAsJson(BasePath, user);
            if (Response.IsSuccessStatusCode)
                return await Response.ReadContentAs<UserVOModel>();
            else throw new Exception("Erro na chamada da API");
        }

        public async Task<UserVOModel> UpdateUser(UserVOModel user)
        {
            var Response = await _httpClient.PutAsJson(BasePath, user);
            if (Response.IsSuccessStatusCode)
                return await Response.ReadContentAs<UserVOModel>();
            else throw new Exception("Erro na chamada da API");
        }

        public async Task<bool> DeleteUserById(int Id)
        {
            var Response = await _httpClient.GetAsync($"{BasePath}/{Id}");
            if (Response.IsSuccessStatusCode) 
                return await Response.ReadContentAs<bool>();
            else throw new Exception("Erro na chamada da API");
        }
    }
}
