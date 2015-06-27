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
        private ObservableCollection<ObservableUser> _userList;

        public ObservableCollection<ObservableUser> UserList
        {

            get
            {
                return _userList ?? (_userList = GetUserList());
            }
            set { SetProperty(ref _userList, value); }
        }

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
        {

            get
            {
                return _selectedObservableUser ?? (_selectedObservableUser = new ObservableUser()
                {
                    
                });
            }
            set
            {
                SetProperty(ref _selectedObservableUser, value);

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
