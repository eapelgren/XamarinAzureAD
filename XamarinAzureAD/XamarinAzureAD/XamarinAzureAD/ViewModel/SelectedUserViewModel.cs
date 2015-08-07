using XamarinAzureAD.Model;

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