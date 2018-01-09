using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Common;
using ToDo.DomainModel;
using ToDo.Repository;
using ToDo.ViewModel;

namespace ToDo.BusinessService
{
    public class UserAccountService : IUserAccountService
    {
        public BaseResult Create(RegisterViewModel model)
        {
            using (var repo = new ToDoRepository<User>())
            {
                var result = new BaseResult();

                if (repo.Any(o => o.Email == model.Email))
                {
                    result.ResultType = ResultType.BusinessError;
                    result.ResultMessage = $"there is already an account with this email address: {model.Email}";
                    return result;
                }

                var hashedPassword = PasswordHelper.GetHashString(model.Password);
                var dbModel = new User()
                {
                    Email = model.Email,
                    LastName = model.LastName,
                    FirstName = model.FirstName,
                    Password = hashedPassword,
                };
                repo.Add(dbModel);
                repo.SaveChanges();
                return result;
            }
        }
        public LoginResult GetUser(LoginViewModel model)
        {
            using (var repo = new ToDoRepository<User>())
            {
                var result = new LoginResult();
                var hashedPassword = PasswordHelper.GetHashString(model.Password);
                var user = repo.FirstOrDefault(o => o.Email == model.Email && o.Password== hashedPassword);
                if (user==null)
                {
                    result.ResultType = ResultType.BusinessError;
                    result.ResultMessage = $"Email or password is wrong.";
                    return result;
                }
                result.LastName = user.LastName;
                result.Id = user.Id;

                return result;
            }
        }

    }
}
