using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTOModel.Model;
using DTOModel.Providers.Interfaces;

namespace DTOModel.Providers.Implementations
{
    internal class UserProvider : IUserProvider
    {
        public Task<IEnumerable<IUserDTO>> GetUsersAsyncTask()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IUserDTO>> GetUsersAsyncTask(Func<IUserDTO, bool> predict)
        {
            throw new NotImplementedException();
        }

        public Task<IUserDTO> PostUserAsyncTask(IUserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}