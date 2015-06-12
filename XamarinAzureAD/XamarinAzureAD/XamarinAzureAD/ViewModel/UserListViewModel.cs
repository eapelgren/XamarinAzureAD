using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinAzureAD.Model;
using XamarinAzureAD.Services;
using XLabs.Ioc;

namespace XamarinAzureAD.ViewModel
{

    class UserListViewModel : XLabs.Forms.Mvvm.ViewModel
    {
        public UserListViewModel()
        {
           var temp = UserList;
        }
        
        private ObservableCollection<User> _userList;

        public ObservableCollection<User> UserList
        {

            get
            {
                return _userList ?? (_userList = new AzureADServiceMocked().GetUsersTask());
            }
            set { SetProperty(ref _userList, value); }
        }

        private User _selectedUser;

        public User SelectedUser
        {

            get
            {
                return _selectedUser ?? (_selectedUser = new User()
                {
                    
                });
            }
            set
            {
                SetProperty(ref _selectedUser, value);

                if (value != null)
                {
                    var user = value;   
                    NavigationService.NavigateTo<SelectedUserViewModel>(user);
                }
            }
        }


		

		

		

		


		

		



		

		

 


		

		



		

		

    }
}
