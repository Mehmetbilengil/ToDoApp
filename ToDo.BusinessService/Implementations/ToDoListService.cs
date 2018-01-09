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
    public class ToDoListService : IToDoListService
    {
        public List<ToDoItemListView> GetList(Guid userId)
        {
            using (var repo = new ToDoRepository<ToDoList>())
            {
                var list = repo.Query(o => o.UserId == userId).Select(o => new ToDoItemListView() { Id = o.Id, Title = o.ListTitle }).ToList();

                return list;
            }
        }

        public ToDoItemDetailView GetDetails(Guid id, Guid userId)
        {
            using (var repo = new ToDoRepository<ToDoList>())
            {
                var result = repo.Query(o => o.UserId == userId && o.Id == id)
                    .Select(o => new ToDoItemDetailView()
                    {
                        Id = o.Id,
                        Title = o.ListTitle,
                        //Tasks = o.Tasks.Select(t => new ToDoTaskListView { Id = t.Id, Desc = t.Desc }).ToList()

                    }).SingleOrDefault();


                return result;
            }
        }

        public BaseResult Save(ToDoItemEditView model, Guid userId)
        {
            using (var repo = new ToDoRepository<ToDoList>())
            {
                var result = new LoginResult();

                var dbModel = new ToDoList()
                {
                    ListTitle = model.Title,
                    UserId = userId

                };
                model.Id = dbModel.Id;

                repo.Add(dbModel);
                repo.SaveChanges();

                return result;
            }
        }

        public BaseResult Update(ToDoItemEditView model, Guid userId)
        {
            using (var repo = new ToDoRepository<ToDoList>())
            {
                var result = new LoginResult();

                var dbModel = repo.SingleOrDefault(o => o.UserId == userId && o.Id == model.Id);

                if (dbModel == null)
                {
                    result.ResultType = ResultType.BusinessError;
                    result.ResultMessage = $"Item not found by id:{model.Id}";
                    return result;
                }

                dbModel.ListTitle = model.Title;
                repo.SaveChanges();

                return result;
            }
        }

        public BaseResult Remove(Guid id, Guid userId)
        {
            using (var repo = new ToDoRepository<ToDoList>())
            {
                var result = new LoginResult();

                var dbModel = repo.SingleOrDefault(o => o.UserId == userId && o.Id == id);

                if (dbModel == null)
                {
                    result.ResultType = ResultType.BusinessError;
                    result.ResultMessage = $"Item not found by id:{id}";
                    return result;
                }

                repo.Remove(dbModel);
                repo.SaveChanges();

                return result;
            }
        }

    }
}
