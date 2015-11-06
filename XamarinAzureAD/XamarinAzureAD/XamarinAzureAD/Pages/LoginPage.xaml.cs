<<<<<<< HEAD
<<<<<<< HEAD
﻿using Xamarin.Forms;
=======
=======
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
<<<<<<< HEAD
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
=======
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
using XamarinAzureAD.ViewModel;
using XLabs.Forms.Mvvm;

namespace XamarinAzureAD.Pages
{
<<<<<<< HEAD
<<<<<<< HEAD
    [ViewType(typeof (LoginPage))]
    public partial class LoginPage : BaseView
=======
    [ViewType(typeof(LoginPage))]
    public partial class LoginPage : XLabs.Forms.Mvvm.BaseView
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
=======
    [ViewType(typeof(LoginPage))]
    public partial class LoginPage : XLabs.Forms.Mvvm.BaseView
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
    {
        public LoginPage()
        {
            BindingContext = new LoginPageViewModel();
            InitializeComponent();
        }
<<<<<<< HEAD
<<<<<<< HEAD

=======
        
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
=======
        
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
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
