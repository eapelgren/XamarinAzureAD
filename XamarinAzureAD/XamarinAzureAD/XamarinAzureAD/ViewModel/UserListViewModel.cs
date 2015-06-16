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
        }
        
        private ObservableCollection<User> _userList;

        public ObservableCollection<User> UserList
        {

            get
            {
                return _userList ?? (_userList = GetUserList());
            }
            set { SetProperty(ref _userList, value); }
        }

        private ObservableCollection<User> GetUserList()
        {
            var list = new ObservableCollection<User>();
            Resolver.Resolve<IAzureAdService>().GetUsersTask().ContinueWith(task =>
            {
                if(!task.IsFaulted)
                    foreach (var user in task.Result)
                    {
                        list.Add(user);
                    }
                else
                {
                 throw new Exception("AzureAdService.GetUsersTask Faulted");
                }
            });
            return list;
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

        private string _path;

        public string Path
        {

            get
            {
                return _path ?? (_path = "*");
            }
            set { SetProperty(ref _path, value); }
        }


		

		


		

		

		

		


		

		



		

		

 


		

		



		

		

    }
}
