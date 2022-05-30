using ControleLeitura2.Models;

namespace ControleLeitura2.Repositories.Interfaces
{
    public interface IStatusRepository
    {
        IEnumerable<Status> Status { get; }
    }
}
