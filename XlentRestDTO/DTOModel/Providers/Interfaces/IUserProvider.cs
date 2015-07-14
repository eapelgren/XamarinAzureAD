using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTOModel.Model;

namespace DTOModel.Providers.Interfaces
{
    public interface IUserProvider
    {
        Task<IEnumerable<IUserDTO>> GetUsersAsyncTask();

        Task<IEnumerable<IUserDTO>> GetUsersAsyncTask(string id);

        Task<IUserDTO> PostUserAsyncTask(IUserDTO user);
    }
}