using XLabs.Data;

namespace XamarinAzureAD.Model
{
    public abstract class BasePost : ObservableObject
    {
        public ObservableUser AuthorObservableUser;

        public string DatePosted;

        public string Id;
    }
}