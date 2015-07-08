using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinAzureAD.Model;

namespace XamarinAzureAD.ViewModel
{
    class SelectedItemViewModel : XLabs.Forms.Mvvm.ViewModel
    {
        private ObservableNews _selectedNews;

        public ObservableNews SelectedNews
        {

            get
            {
                return _selectedNews ?? (_selectedNews = new ObservableNews()
                {
                        
                });
            }
            set { SetProperty(ref _selectedNews, value); }
        }


		

		


    }
}
