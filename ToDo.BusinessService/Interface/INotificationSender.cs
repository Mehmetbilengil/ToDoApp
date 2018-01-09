using System.Threading.Tasks;

namespace ToDo.BusinessService.Implementations
{
    public interface INotificationSender
    {
        Task<int> Send();
    }
}