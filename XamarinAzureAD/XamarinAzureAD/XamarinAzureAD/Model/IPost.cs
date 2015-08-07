using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinAzureAD.Model
{
    interface IPost
    {
        ObservableUser AuthorObservableUser { get; set; }
    }
}
