using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using XamarinAzureAD.Handler;
using XamarinAzureAD.Model;
using XamarinAzureAD.Services;
using XLabs.Ioc;
using XLabs.Platform.Services;

namespace XamarinAzureAD.iOS
{
    public class XlentRestServiceiOS : IAzureRestService
    {
        public async Task<XlentAuthResult> LoginAdTaskAsync(string username, string password)
        {
            var client = new NativeWebApi();
            var result = await client.Login.GetByUsernamePasswordAsync(username, password);
                return new XlentAuthResult()
                {
                    RefreshToken = result.RefreshToken,
                    IdToken = result.IdToken
                };
        }

        public async Task<XlentAuthResult> LoginAdTaskAsync(string token)
        {
            var client = new NativeWebApi();
            var result = await client.Login.GetByTokenAsync(token);
            return new XlentAuthResult()
            {
                RefreshToken = result.RefreshToken,
                IdToken = result.IdToken
            };
        }

        public async Task<ObservableCollection<ObservableNews>> GetNewsTaskAsync()
        {
         
            var news = await new NativeWebApi().News.GetNewsAsync("99", new LocalTokenHandler().GetRefreshToken() );

            var list = new ObservableCollection<ObservableNews>();
            foreach (var newse in news)
            {
                list.Add(new ObservableNews()
                {
                    Description = newse.Description,
                    Header = newse.Header,
                    PictureUri = new Uri(newse.PictureUri)
                });
            }

            return list;

        }

        public Task<ObservableCollection<ObservableUser>> GetUserTaskAsync()
        {
            throw new NotImplementedException();
        }
    }
}