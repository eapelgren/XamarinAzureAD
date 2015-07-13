using System.Threading.Tasks;
using DTOModel.Model;

namespace DTOModel.Providers.Interfaces
{
    public interface INewsStatisticProvider
    {
        Task PostNewsStatisticAsyncTask(INewsStatisticDTO news);
    }
}