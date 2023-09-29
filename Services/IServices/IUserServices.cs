using BuilderAux_MVC.Models;

namespace BuilderAux_MVC.Services.IServices
{
    public interface IUserServices
    {
        Task<IEnumerable<UserVOModel>> GetAllUsers();
        //List<UserVOModel> GetAll();
        Task<UserVOModel> GetUsersById(int Id);
        //UserVOModel GetById(int id);
        Task<UserVOModel> CreateUser(UserVOModel user);
        //UserVOModel Create(UserVOModel userVO);
        Task<UserVOModel> UpdateUser(UserVOModel user);
        //UserVOModel Update(UserVOModel userVO);
        Task<bool> DeleteUserById(int Id);
        //bool Delete(int id);
    }
}
