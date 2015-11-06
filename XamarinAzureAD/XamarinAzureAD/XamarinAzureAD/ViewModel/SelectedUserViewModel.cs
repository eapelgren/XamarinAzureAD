<<<<<<< HEAD
﻿using XamarinAzureAD.Model;

namespace XamarinAzureAD.ViewModel
{
    internal class SelectedUserViewModel : XLabs.Forms.Mvvm.ViewModel
    {
        private ObservableUser _selectedObservableUser;

        public SelectedUserViewModel(ObservableUser selectedObservable)
        {
            SelectedObservableUser = selectedObservable;
        }

        public ObservableUser SelectedObservableUser
        {
            get { return _selectedObservableUser ?? (_selectedObservableUser = new ObservableUser()); }
            set { SetProperty(ref _selectedObservableUser, value); }
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinAzureAD.Model;
using XamarinAzureAD.Services;
using XLabs.Forms.Mvvm;

namespace XamarinAzureAD.ViewModel
{
    class SelectedUserViewModel : XLabs.Forms.Mvvm.ViewModel
    {

        public SelectedUserViewModel(User selected)
        {
            SelectedUser = selected;

        }

        private User _selectedUser;

        public User SelectedUser
        {

            get
            {
                return _selectedUser ?? (_selectedUser = new User());
            }
            set { SetProperty(ref   _selectedUser, value); }
        }


		

		

    }
}
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
