using DTOModel;
using System.IO;
using DTOModel.Providers.Implementations;
using DTOModel.Providers.Interfaces;
using DTOModel.Providers.Implementations.Mocked;
using XLabs.Forms.Services;
using Foundation;
using XLabs.Platform.Services;
using XLabs.Platform.Services.Email;
using XLabs.Platform.Services.Media;
using UIKit;
using Xamarin.Forms;
using XLabs.Forms;
using XLabs.Forms.Controls;
using XLabs.Forms.Services;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Mvvm;
using XLabs.Platform.Services;
using XLabs.Platform.Services.Email;
using XLabs.Platform.Services.Media;
using XLabs.Serialization;

namespace XamarinAzureAD.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // ObservableUser Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : XFormsApplicationDelegate
    {
        private object IUserProvider;
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            SetIoc();
       
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }

        private void SetIoc()
        {
            var resolverContainer = new SimpleContainer();

            var app = new XFormsAppiOS();
            app.Init(this);
            var documents = app.AppDataDirectory;
            var pathToDatabase = Path.Combine(documents, "xlent.db");

            resolverContainer.Register<IDevice>(t => AppleDevice.CurrentDevice)
                .Register<IDisplay>(t => t.Resolve<IDevice>().Display)
                .Register<IFontManager>(t => new FontManager(t.Resolve<IDisplay>()))
                //.Register<IJsonSerializer, XLabs.Serialization.ServiceStack.JsonSerializer>()
                //.Register<IJsonSerializer, Services.Serialization.SystemJsonSerializer>()
                //.Register<ISimpleCache>(
                //    t => new SQLiteSimpleCache(new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS(),
                //        new SQLite.Net.SQLiteConnectionString(pathToDatabase, true), t.Resolve<IJsonSerializer>()));
                .Register<ITextToSpeechService, TextToSpeechService>()
                .Register<IEmailService, EmailService>()
                .Register<IMediaPicker, MediaPicker>()
                .Register<IXFormsApp>(app)
                .Register<ISecureStorage, SecureStorage>()
                .Register<IDependencyContainer>(t => resolverContainer)

                //REAL
                //.Register<IAuthenticationProvider, AuthenticationProvider>()
                //.Register<INewsProvider>(t => new NewsProvider(new AuthenticationProvider()))
                //.Register<IUserProvider, UserProvider>();


            //MOCKED
                .Register<IAuthenticationProvider, AuthenticationProviderMocked>()
                .Register<INewsProvider>(t => new NewsProviderMocked(new AuthenticationProviderMocked()))
                .Register<IUserProvider, UserProviderMocked>();



            Resolver.SetResolver(resolverContainer.GetResolver());
        }
    }
}
