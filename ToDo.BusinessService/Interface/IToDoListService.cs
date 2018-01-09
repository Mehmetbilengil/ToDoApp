using System;
using System.Collections.Generic;
using ToDo.ViewModel;

namespace ToDo.BusinessService
{
    public interface IToDoListService
    {
        List<ToDoItemListView> GetList(Guid userId);
        ToDoItemDetailView GetDetails(Guid id, Guid userId);
        BaseResult Remove(Guid id, Guid userId);
        BaseResult Save(ToDoItemEditView model, Guid userId);
        BaseResult Update(ToDoItemEditView model, Guid userId);
    }
}