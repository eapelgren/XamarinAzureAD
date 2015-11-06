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
<<<<<<< HEAD
        private ObservableCollection<ObservableUser> _userList;

        public ObservableCollection<ObservableUser> UserList
=======
        public UserListViewModel()
        {
        }
        
        private ObservableCollection<User> _userList;

        public ObservableCollection<User> UserList
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
        {

            get
            {
                return _userList ?? (_userList = GetUserList());
            }
            set { SetProperty(ref _userList, value); }
        }

<<<<<<< HEAD
        private ObservableCollection<ObservableUser> GetUserList()
        {

            var list = new ObservableCollection<ObservableUser>();             
            Resolver.Resolve<IAzureRestService>().GetUserTaskAsync().ContinueWith(task =>
            {
                foreach (var user in task.Result)
                {
                    list.Add(user);
                }
            });  
           
            return list;
        }

        private ObservableUser _selectedObservableUser;

        public ObservableUser SelectedObservableUser
=======
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
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
        {

            get
            {
<<<<<<< HEAD
                return _selectedObservableUser ?? (_selectedObservableUser = new ObservableUser()
=======
                return _selectedUser ?? (_selectedUser = new User()
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
                {
                    
                });
            }
            set
            {
<<<<<<< HEAD
                SetProperty(ref _selectedObservableUser, value);
=======
                SetProperty(ref _selectedUser, value);
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d

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
