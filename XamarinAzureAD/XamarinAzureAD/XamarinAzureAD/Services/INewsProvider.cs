using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinAzureAD.Model;

namespace XamarinAzureAD.Services
{
    public interface INewsProvider
    {
        Task<ObservableCollection<ObservableNews>> GetNewsTaskAsync(string username, string password);
    }
}
