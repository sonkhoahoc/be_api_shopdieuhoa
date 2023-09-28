using AutoMapper;
using DADH.Entities;
using DADH.Extensions;
using DADH.Model.User;
using DADH.Model;
using DoAnTuLanh.IRepositories;

namespace DoAnTuLanh.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<UserModel> UserGetById(long id)
        {
            Admin_User user = _context.Admin_User.Find(id);
            UserModel userViewModel = _mapper.Map<UserModel>(user);
            return userViewModel;
        }
        public async Task<UserModel> UserCreate(UserCreateModel useradd)
        {
            Admin_User user = _mapper.Map<Admin_User>(useradd);
            user.pass_code = Encryptor.RandomPassword();
            user.password = Encryptor.MD5Hash(user.password + user.pass_code);
            _context.Admin_User.Add(user);
            _context.SaveChanges();
            UserModel userViewModel = _mapper.Map<UserModel>(user);
            return userViewModel;
        }
        public async Task<UserModifyModel> UserModify(UserModifyModel userupdate)
        {
            var user = _context.Admin_User.FirstOrDefault(r => r.id == userupdate.id);

            user.address = userupdate.address;
            user.email = userupdate.email;
            user.phone_number = userupdate.phone_number;
            user.birthday = userupdate.birthday;
            user.sex = userupdate.sex;
            user.full_name = userupdate.full_name;
            user.is_active = userupdate.is_active;
            user.dateUpdated = DateTime.Now;

            UserModifyModel userViewModel = _mapper.Map<UserModifyModel>(user);

            _context.Admin_User.Update(user);
            _context.SaveChanges();
            return userupdate;
        }
        public async Task<bool> ChangePassUser(ChangePassModel model)
        {
            var user = _context.Admin_User.FirstOrDefault(r => r.id == model.id);
            LoginModel login = new LoginModel
            {
                password = model.passwordOld,
                username = user.username,
            };
            if (Authenticate(login) == 1)
            {
                user.dateUpdated = DateTime.Now;
                user.pass_code = Encryptor.RandomPassword();
                user.password = Encryptor.MD5Hash(model.passwordNew + user.pass_code);
                _context.Admin_User.Update(user);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<PaginationSet<UserModel>> UserList(string? full_name, string? username, int page_number, int page_size)
        {
            PaginationSet<UserModel> response = new PaginationSet<UserModel>();
            IEnumerable<UserModel> listItem = from a in _context.Admin_User
                                              select new UserModel
                                              {
                                                  address = a.address,
                                                  is_active = a.is_active,
                                                  sex = a.sex,
                                                  birthday = a.birthday,
                                                  email = a.email,
                                                  full_name = a.full_name,
                                                  id = a.id,
                                                  phone_number = a.phone_number,
                                                  userAdded = a.userAdded,
                                                  username = a.username,
                                                  userUpdated = a.userUpdated,
                                              };
            if (username != null && username != "")
            {
                listItem = listItem.Where(r => r.username.Contains(username));
            }
            if (full_name != null && full_name != "")
            {
                listItem = listItem.Where(r => r.full_name.Contains(full_name));
            }
            if (page_number > 0)
            {
                response.totalcount = listItem.Select(x => x.id).Count();
                response.page = page_number;
                response.maxpage = (int)Math.Ceiling((decimal)response.totalcount / page_size);
                response.lists = listItem.OrderByDescending(r => r.id).Skip(page_size * (page_number - 1)).Take(page_size).ToList();
            }
            else
            {
                response.lists = listItem.OrderByDescending(r => r.id).ToList();
            }
            return response;
        }
        public int Authenticate(LoginModel login)
        {
            Admin_User user = _context.Admin_User.Where(r => r.username.ToUpper() == login.username.ToUpper() || r.email.ToUpper() == login.username.ToUpper() || r.phone_number == login.username).FirstOrDefault();
            if (!user.is_active)
            {
                return -1;
            }
            else
            {
                var passWord = Encryptor.MD5Hash(login.password + user.pass_code);
                return passWord != user.password ? 2 : 1;
            }
        }
        public async Task<Admin_User> CheckUser(string username)
        {
            return _context.Admin_User.Where(r => r.username.ToUpper() == username.ToUpper() || r.email.ToUpper() == username.ToUpper() || r.phone_number == username).FirstOrDefault();

        }
        public async Task<int> CheckUserExists(string username, string phone_number, string email)
        {
            return _context.Admin_User.Where(r => r.username.ToUpper() == username.ToUpper() || r.email.ToUpper() == email.ToUpper() || r.phone_number == phone_number).Count();

        }
    }
}
