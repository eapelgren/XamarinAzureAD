<<<<<<< HEAD
<<<<<<< HEAD
﻿using System.IO;
using DTOModel.Providers.Implementations.Mocked;
using DTOModel.Providers.Interfaces;
using Foundation;
using UIKit;
using Xamarin.Forms;
=======
=======
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Foundation;
using UIKit;
<<<<<<< HEAD
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
=======
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
using XLabs.Forms;
using XLabs.Forms.Services;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Mvvm;
using XLabs.Platform.Services;
using XLabs.Platform.Services.Email;
using XLabs.Platform.Services.Media;
<<<<<<< HEAD
<<<<<<< HEAD
=======
using XLabs.Serialization;
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
=======
using XLabs.Serialization;
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d

namespace XamarinAzureAD.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
<<<<<<< HEAD
<<<<<<< HEAD
    // ObservableUser Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : XFormsApplicationDelegate
    {
        private object IUserProvider;
=======
=======
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : XFormsApplicationDelegate
    {
<<<<<<< HEAD
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
=======
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
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
<<<<<<< HEAD
<<<<<<< HEAD

            Forms.Init();
=======
            
            global::Xamarin.Forms.Forms.Init();
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
=======
            
            global::Xamarin.Forms.Forms.Init();
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }

        private void SetIoc()
        {
            var resolverContainer = new SimpleContainer();

            var app = new XFormsAppiOS();
            app.Init(this);
<<<<<<< HEAD
<<<<<<< HEAD
            var documents = app.AppDataDirectory;
            var pathToDatabase = Path.Combine(documents, "xlent.db");

            resolverContainer.Register(t => AppleDevice.CurrentDevice)
                .Register(t => t.Resolve<IDevice>().Display)
                .Register<IFontManager>(t => new FontManager(t.Resolve<IDisplay>()))
                //.Register<IJsonSerializer, XLabs.Serialization.ServiceStack.JsonSerializer>()
                //.Register<IJsonSerializer, Services.Serialization.SystemJsonSerializer>()
                //.Register<ISimpleCache>(
                //    t => new SQLiteSimpleCache(new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS(),
                //        new SQLite.Net.SQLiteConnectionString(pathToDatabase, true), t.Resolve<IJsonSerializer>()));
=======
=======
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d

            //var documents = app.AppDataDirectory;
            //var pathToDatabase = Path.Combine(documents, "xforms.db");

            resolverContainer.Register<IDevice>(t => AppleDevice.CurrentDevice)
                .Register<IDisplay>(t => t.Resolve<IDevice>().Display)
                .Register<IFontManager>(t => new FontManager(t.Resolve<IDisplay>()))
                //.Register<IJsonSerializer, XLabs.Serialization.ServiceStack.JsonSerializer>()
                //.Register<IJsonSerializer, Services.Serialization.SystemJsonSerializer>()
<<<<<<< HEAD
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
=======
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
                .Register<ITextToSpeechService, TextToSpeechService>()
                .Register<IEmailService, EmailService>()
                .Register<IMediaPicker, MediaPicker>()
                .Register<IXFormsApp>(app)
                .Register<ISecureStorage, SecureStorage>()
<<<<<<< HEAD
<<<<<<< HEAD
                .Register<IDependencyContainer>(t => resolverContainer)

                //REAL
                //.Register<IAuthenticationProvider, AuthenticationProvider>()
                //.Register<INewsProvider>(t => new NewsProvider(new AuthenticationProvider()))
                //.Register<IUserProvider, UserProvider>();


                //MOCKED
                .Register<IAuthenticationProvider, AuthenticationProviderMocked>()
                .Register<INewsProvider>(t => new NewsProviderMocked(new AuthenticationProviderMocked()))
                .Register<IUserProvider, UserProviderMocked>()
                .Register<ICommentProvider, CommentProviderMocked>();

=======
=======
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
                .Register<IDependencyContainer>(t => resolverContainer);
                //.Register<ISimpleCache>(
                //    t => new SQLiteSimpleCache(new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS(),
                //        new SQLite.Net.SQLiteConnectionString(pathToDatabase, true), t.Resolve<IJsonSerializer>()));
<<<<<<< HEAD
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
=======
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d

            Resolver.SetResolver(resolverContainer.GetResolver());
        }
    }
<<<<<<< HEAD
<<<<<<< HEAD
}
=======
}
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
=======
}
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
