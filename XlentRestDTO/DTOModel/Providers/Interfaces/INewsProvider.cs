using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTOModel.Model;

namespace DTOModel.Providers.Interfaces
{
    public interface INewsProvider
    {
        Task<IEnumerable<INewsDTO>> GetNewsAsyncTask();

        Task<IEnumerable<INewsDTO>> GetNewsAsyncTask(string id);

        Task<INewsDTO> PostNewsAsyncTask(INewsDTO news);
    }
}