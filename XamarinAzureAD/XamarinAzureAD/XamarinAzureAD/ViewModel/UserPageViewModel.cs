using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using DTOModel.Providers.Interfaces;
using Xamarin.Forms;
using XamarinAzureAD.Mapper;
using XamarinAzureAD.Model;
using XLabs.Ioc;

namespace XamarinAzureAD.ViewModel
{
    public class UserPageViewModel : XLabs.Forms.Mvvm.ViewModel
    {
        private string _entryText;
        private Command _entryTextChanged;
        private ObservableCollection<ObservableUser> _originalCollection;
        private string _searchText;
        private ObservableCollection<ObservableUser> _usersList;
        public bool NoUserLabelBool;

        public UserPageViewModel()
        {
            NoUserLabelBool = false;
            Debug.WriteLine("Adding and Converting DTO Users");
            var userProvider = Resolver.Resolve<IUserProvider>();
            var dtoUsers = userProvider.GetUsersAsyncTask();
            foreach (var dtoUser in dtoUsers.Result)
            {
                OriginalCollection.Add(UserMapper.Convert(dtoUser));
            }

            if (string.IsNullOrWhiteSpace(EntryText))
            {
                foreach (var observableUser in OriginalCollection)
                {
                    SortedUsersList.Add(observableUser);
                }
            }
            UpdateListAfterSearch();
        }

        public ObservableCollection<ObservableUser> OriginalCollection
        {
            get { return _originalCollection ?? (_originalCollection = new ObservableCollection<ObservableUser>()); }
            set { SetProperty(ref _originalCollection, value); }
        }

        public ObservableCollection<ObservableUser> SortedUsersList
        {
            get { return _usersList ?? (_usersList = new ObservableCollection<ObservableUser>()); }
            set { SetProperty(ref _usersList, value); }
        }

        public Command EntryTextChanged
        {
            get
            {
                return _entryTextChanged ?? (_entryTextChanged = new Command(() => { var i = 2; })
                    );
            }
            set { SetProperty(ref _entryTextChanged, value); }
        }

        public string EntryText
        {
            get { return _entryText ?? (_entryText = ""); }
            set { SetProperty(ref _entryText, value); }
        }

        public string SearchText
        {
            get { return _searchText ?? (_searchText = ""); }
            set { SetProperty(ref _searchText, value); }
        }

        public void UpdateListAfterSearch()
        {
            Debug.WriteLine("Updating SortedUserList with Search for: " + SearchText);
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                SortedUsersList.Clear();
                var original = OriginalCollection.ToArray();
                foreach (var observableUser in original)
                {
                    observableUser.DisplayName = observableUser.DisplayName.ToUpper();
                }
                var originalSorted = original.Where(user => user.DisplayName.Contains(SearchText.ToUpper())).ToList();
                foreach (var observableUser in originalSorted)
                {
                    SortedUsersList.Add(observableUser);
                }
            }
            else
            {
                SortedUsersList.Clear();
                foreach (var observableUser in OriginalCollection)
                {
                    SortedUsersList.Add(observableUser);
                }
            }

            //if (SortedUsersList.Count < 1)
            //{
            //    NoUserLabelBool = true;
            //}
            //else
            //{
            //   NoUserLabelBool = false;
            //}
        }
    }
}