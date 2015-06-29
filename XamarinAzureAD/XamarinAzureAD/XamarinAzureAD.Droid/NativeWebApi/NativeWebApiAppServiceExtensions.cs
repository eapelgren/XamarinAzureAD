using System;
using System.Net.Http;
using Microsoft.Azure.AppService;

namespace XamarinAzureAD.Droid
{
    public static class NativeWebApiAppServiceExtensions
    {
        public static NativeWebApi CreateNativeWebApi(this IAppServiceClient client)
        {
            return new NativeWebApi(client.CreateHandler());
        }

        public static NativeWebApi CreateNativeWebApi(this IAppServiceClient client, params DelegatingHandler[] handlers)
        {
            return new NativeWebApi(client.CreateHandler(handlers));
        }

        public static NativeWebApi CreateNativeWebApi(this IAppServiceClient client, Uri uri, params DelegatingHandler[] handlers)
        {
            return new NativeWebApi(uri, client.CreateHandler(handlers));
        }

        public static NativeWebApi CreateNativeWebApi(this IAppServiceClient client, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
        {
            return new NativeWebApi(rootHandler, client.CreateHandler(handlers));
        }
    }
}
