using ControleLeitura2.Models;

namespace ControleLeitura2.Repositories.Interfaces
{
    public interface IPrioridadeRepository
    {
        IEnumerable<Prioridade> Prioridades { get; }
    }
}
