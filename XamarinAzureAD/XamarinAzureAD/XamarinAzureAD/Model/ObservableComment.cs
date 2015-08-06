using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLabs.Data;

namespace XamarinAzureAD.Model
{
    public class ObservableComment : ObservableObject
    {

        private string _id;

        public string Id
        {

            get { return _id ?? (_id = "NO ID"); }
            set { SetProperty(ref _id, value); }
        }

        private ObservableUser _author;

        public ObservableUser Author
        {

            get
            {
                return _author ?? (_author = new ObservableUser()
                {
                    DisplayName = "NOT AUTHOR SET",
                });
            }
            set { SetProperty(ref _author, value); }
        }

        private string _comment;

        public string Comment
        {

            get { return _comment ?? (_comment = "NO COMMENT SET"); }
            set { SetProperty(ref _comment, value); }
        }
        
    }
}
