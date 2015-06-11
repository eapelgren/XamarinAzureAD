﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinAzureAD.Model;

namespace XamarinAzureAD.Services
{
    interface IAzureAdService
    {
        Task<Boolean> LoginAdTask();

        Task<ObservableCollection<User>> GetUsersTask();


    }
}
