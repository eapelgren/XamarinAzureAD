using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinAzureAD.Model;
using XLabs.Forms.Mvvm;

namespace XamarinAzureAD.ViewModel
{
    class SelectedUserViewModel : XLabs.Forms.Mvvm.ViewModel
    {

        public SelectedUserViewModel(ObservableUser selectedObservable)
        {
            SelectedObservableUser = selectedObservable;

        }

        private ObservableUser _selectedObservableUser;

        public ObservableUser SelectedObservableUser
        {

            get
            {
                return _selectedObservableUser ?? (_selectedObservableUser = new ObservableUser());
            }
            set { SetProperty(ref   _selectedObservableUser, value); }
        }


		

		

    }
}
