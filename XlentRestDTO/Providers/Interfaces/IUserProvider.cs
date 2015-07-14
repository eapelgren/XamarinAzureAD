using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTOModel.Model;

namespace DTOModel.Providers.Interfaces
{
    internal interface IUserProvider
    {
        Task<IEnumerable<IUserDTO>> GetUsersAsyncTask();

        Task<IEnumerable<IUserDTO>> GetUsersAsyncTask(Func<IUserDTO, bool> predict);

        Task<IUserDTO> PostUserAsyncTask(IUserDTO user);
    }
}