using ToDo.ViewModel;

namespace ToDo.BusinessService
{
    public interface IUserAccountService
    {
        BaseResult Create(RegisterViewModel model);
        LoginResult GetUser(LoginViewModel model);
    }
}