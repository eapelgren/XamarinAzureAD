using System.IO;
using Android.App;
using Android.Content.PM;
using Android.OS;
<<<<<<< HEAD
using DTOModel.Providers.Implementations.Mocked;
using DTOModel.Providers.Interfaces;
=======
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
using Xamarin.Forms;
using XLabs.Forms;
using XLabs.Forms.Services;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Mvvm;
using XLabs.Platform.Services;
using XLabs.Platform.Services.Email;
using XLabs.Platform.Services.Media;
<<<<<<< HEAD

namespace XamarinAzureAD.Droid
{
    [Activity(Label = "Xlent Xamarin Preview", MainLauncher = true, Theme = "@android:style/Theme.Material.Light",
=======
using XLabs.Serialization;
using XamarinAzureAD.Services;

namespace XamarinAzureAD.Droid
{
    [Activity(Label = "Xlent Xamarin Preview", MainLauncher = true,  Theme = "@android:style/Theme.Material.Light",
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class MainActivity : XFormsApplicationDroid
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            if (!Resolver.IsSet)
            {
<<<<<<< HEAD
                SetIoc();
=======
                this.SetIoc();
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
            }
            else
            {
                var app = Resolver.Resolve<IXFormsApp>() as IXFormsApp<XFormsApplicationDroid>;
                app.AppContext = this;
            }

            Forms.Init(this, bundle);

            App.Init();

            Forms.ViewInitialized += (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.View.StyleId))
                {
                    e.NativeView.ContentDescription = e.View.StyleId;
                }
            };

<<<<<<< HEAD
            SetPage(App.GetMainPage());
        }

=======
            this.SetPage(App.GetMainPage());
        }
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
        private void SetIoc()
        {
            var resolverContainer = new SimpleContainer();

            var app = new XFormsAppDroid();

            app.Init(this);

            var documents = app.AppDataDirectory;
            var pathToDatabase = Path.Combine(documents, "xlent.db");

            resolverContainer.Register(t => AndroidDevice.CurrentDevice)
<<<<<<< HEAD
                .Register(t => t.Resolve<IDevice>().Display)
=======
                .Register<IDisplay>(t => t.Resolve<IDevice>().Display)
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
                .Register<IFontManager>(t => new FontManager(t.Resolve<IDisplay>()))
                //.Register<IJsonSerializer, Services.Serialization.JsonNET.JsonSerializer>()
                //.Register<IJsonSerializer, JsonSerializer>()
                .Register<IEmailService, EmailService>()
                .Register<IMediaPicker, MediaPicker>()
                .Register<ITextToSpeechService, TextToSpeechService>()
                .Register<IDependencyContainer>(resolverContainer)
                .Register<IXFormsApp>(app)
                .Register<ISecureStorage>(t => new KeyVaultStorage(t.Resolve<IDevice>().Id.ToCharArray()))
<<<<<<< HEAD
                //.Register<IHttpHeaderAuthenticator, HttpHeaderProviderMocked>()
                .Register<INewsProvider, NewsProviderMocked>()
                .Register<IUserProvider, UserProviderMocked>()
                .Register<ICommentProvider, CommentProviderMocked>();
            //.Register<ISimpleCache>(
            //    t => new SQLiteSimpleCache(new SQLitePlatformAndroid(),
            //        new SQLiteConnectionString(pathToDatabase, true), t.Resolve<IJsonSerializer>()));


            Resolver.SetResolver(resolverContainer.GetResolver());
        }
    }
}
=======
                //.Register<ISimpleCache>(
                //    t => new SQLiteSimpleCache(new SQLitePlatformAndroid(),
                //        new SQLiteConnectionString(pathToDatabase, true), t.Resolve<IJsonSerializer>()));
                .RegisterSingle<IAzureAdService, XlentRestService>();

        Resolver.SetResolver(resolverContainer.GetResolver());
    }
    }
}

>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
