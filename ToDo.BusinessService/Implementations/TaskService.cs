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
    public class TaskService : ITaskService
    {
        public List<ToDoTaskListView> GetList(Guid listId, Guid userId)
        {
            using (var repo = new ToDoRepository<ToDoTask>())
            {
                var list = repo.Query(o => o.List.UserId == userId && o.ToDoListId == listId).Select(o => new ToDoTaskListView() {
                    Id = o.Id,
                    Desc = o.Desc,
                    NotificationRequested = o.NotificationRequested,
                    NotificationType = o.NotificationType,
                    NotificationDate = o.NotificationDate,
                    NotificationTime = o.NotificationDate
                }).ToList();

                return list;
            }
        }


        public BaseResult Save(ToDoTaskEditView model)
        {
            using (var repo = new ToDoRepository<ToDoList>())
            {
                var result = new LoginResult();

                var toDoList = repo.SingleOrDefault(o => o.UserId == model.UserId && o.Id == model.ListId);

                if (toDoList == null)
                {
                    result.ResultType = ResultType.BusinessError;
                    result.ResultMessage = $"ToDoList not found by id:{model.ListId}";
                    return result;
                }

                var task = new ToDoTask()
                {
                    ToDoListId = toDoList.Id,
                    Desc = model.Desc,
                    NotificationType = model.NotificationType,
                    NotificationRequested = model.NotificationRequested,
                    NotificationDate = model.NotificationDate
                };

                model.Id = task.Id;
                toDoList.Tasks.Add(task);

                repo.SaveChanges();

                return result;
            }
        }

        public BaseResult Update(ToDoTaskEditView model)
        {
            using (var repo = new ToDoRepository<ToDoTask>())
            {
                var result = new LoginResult();

                var dbModel = repo.SingleOrDefault(o => o.List.UserId == model.UserId && o.Id == model.Id);

                if (dbModel == null)
                {
                    result.ResultType = ResultType.BusinessError;
                    result.ResultMessage = $"Item not found by id:{model.Id}";
                    return result;
                }

                dbModel.Desc = model.Desc;
                dbModel.NotificationType = model.NotificationType;
                dbModel.NotificationRequested = model.NotificationRequested;
                dbModel.NotificationDate = model.NotificationDate;
                repo.SaveChanges();

                return result;
            }
        }

        public BaseResult Remove(Guid id, Guid userId)
        {
            using (var repo = new ToDoRepository<ToDoTask>())
            {
                var result = new LoginResult();

                var dbModel = repo.SingleOrDefault(o => o.List.UserId == userId && o.Id == id);

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
