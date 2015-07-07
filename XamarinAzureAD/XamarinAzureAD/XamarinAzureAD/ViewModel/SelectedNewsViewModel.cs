using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinAzureAD.Model;

namespace XamarinAzureAD.ViewModel
{
    class SelectedNewsViewModel : XLabs.Forms.Mvvm.ViewModel
    {
        private ObservableNews _news;

        public ObservableNews News
        {

            get
            {
                return _news ?? (_news = new ObservableNews()
                {
                    
                });
            }
            set { SetProperty(ref _news, value); }
        }


		

		



		

		

    }
}
