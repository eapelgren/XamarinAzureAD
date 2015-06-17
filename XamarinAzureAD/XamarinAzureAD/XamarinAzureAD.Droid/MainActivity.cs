using System.IO;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using XLabs.Forms;
using XLabs.Forms.Services;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Mvvm;
using XLabs.Platform.Services;
using XLabs.Platform.Services.Email;
using XLabs.Platform.Services.Media;
using XLabs.Serialization;
using XamarinAzureAD.Services;

namespace XamarinAzureAD.Droid
{
    [Activity(Label = "Xlent Xamarin Preview", MainLauncher = true,  Theme = "@android:style/Theme.Material.Light",
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class MainActivity : XFormsApplicationDroid
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            if (!Resolver.IsSet)
            {
                this.SetIoc();
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

            this.SetPage(App.GetMainPage());
        }
        private void SetIoc()
        {
            var resolverContainer = new SimpleContainer();

            var app = new XFormsAppDroid();

            app.Init(this);

            var documents = app.AppDataDirectory;
            var pathToDatabase = Path.Combine(documents, "xforms.db");

            resolverContainer.Register(t => AndroidDevice.CurrentDevice)
                .Register<IDisplay>(t => t.Resolve<IDevice>().Display)
                .Register<IFontManager>(t => new FontManager(t.Resolve<IDisplay>()))
                //.Register<IJsonSerializer, Services.Serialization.JsonNET.JsonSerializer>()
                //.Register<IJsonSerializer, JsonSerializer>()
                .Register<IEmailService, EmailService>()
                .Register<IMediaPicker, MediaPicker>()
                .Register<ITextToSpeechService, TextToSpeechService>()
                .Register<IDependencyContainer>(resolverContainer)
                .Register<IXFormsApp>(app)
                .Register<ISecureStorage>(t => new KeyVaultStorage(t.Resolve<IDevice>().Id.ToCharArray()))
                //.Register<ISimpleCache>(
                //    t => new SQLiteSimpleCache(new SQLitePlatformAndroid(),
                //        new SQLiteConnectionString(pathToDatabase, true), t.Resolve<IJsonSerializer>()));
                .RegisterSingle<IAzureAdService, XlentRestService>();

        Resolver.SetResolver(resolverContainer.GetResolver());
    }
    }
}

