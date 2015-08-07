using System;
using Xamarin.Forms;
using XamarinAzureAD.Model;
using XLabs.Data;

namespace XamarinAzureAD.Controlls
{
    public class ObservableEvent : ObservableObject, IPost
    {
        private ObservableUser _authorObservableUser;

        public ObservableUser AuthorObservableUser
        {

            get
            {
                return _authorObservableUser ?? (_authorObservableUser = new ObservableUser()
                {

                });
            }
            set { SetProperty(ref _authorObservableUser, value); }


        }

        private Image _eventImage;

        public Image EventImage
        {

            get
            {
                return _eventImage ?? (_eventImage = new Image()
                {

                });
            }
            set { SetProperty(ref _eventImage, value); }
        }

        private string _id;

        public string Id
        {

            get { return _id ?? (_id = ""); }
            set { SetProperty(ref _id, value); }
        }

        private DateTime? _eventDateTime;

        public DateTime? EventDateTime
        {

            get
            {
                return _eventDateTime ?? (_eventDateTime = DateTime.Now);
            }
            set { SetProperty(ref _eventDateTime, value); }
        }




		

		

    }
}