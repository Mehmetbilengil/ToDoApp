using System;
using System.Collections.Generic;
using ToDo.ViewModel;

namespace ToDo.BusinessService
{
    public interface ITaskService
    {
        List<ToDoTaskListView> GetList(Guid listId, Guid userId);
        BaseResult Remove(Guid id, Guid userId);
        BaseResult Save(ToDoTaskEditView model);
        BaseResult Update(ToDoTaskEditView model);
    }
}