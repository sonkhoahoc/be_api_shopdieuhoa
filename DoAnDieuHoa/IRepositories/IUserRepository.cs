using DADH.Entities;
using DADH.Model.User;
using DADH.Model;

namespace DoAnTuLanh.IRepositories
{
    public interface IUserRepository
    {
        Task<PaginationSet<UserModel>> UserList(string? full_name, string? username, int page_number, int page_size);
        Task<UserModel> UserGetById(long id);
        Task<UserModel> UserCreate(UserCreateModel useradd);
        Task<bool> ChangePassUser(ChangePassModel model);
        Task<Admin_User> CheckUser(string username);
        Task<int> CheckUserExists(string username, string phone_number, string email);
        int Authenticate(LoginModel login);
        Task<UserModifyModel> UserModify(UserModifyModel userupdate);
    }
}
