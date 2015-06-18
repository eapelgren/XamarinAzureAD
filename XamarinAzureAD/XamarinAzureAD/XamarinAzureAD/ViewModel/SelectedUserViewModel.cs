using System;
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
