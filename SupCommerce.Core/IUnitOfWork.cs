using System.Threading.Tasks;

namespace SupCommerce.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}