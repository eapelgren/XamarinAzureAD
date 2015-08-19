using System;
using DTOModel.Model;
using XamarinAzureAD.Model;

namespace XamarinAzureAD.Mapper
{
    internal static class UserMapper
    {
        public static ObservableUser Convert(IUserDTO author)
        {
            return new ObservableUser
            {
                AuthorImageUri = new Uri(author.AuthorImageUri),
                DisplayName = author.DisplayName,
                GivenName = author.GivenName,
                Id = author.Id,
                Location = author.Location,
                SurName = author.SurName,
                TelephoneNumber = author.TelephoneNumber
            };
        }
    }
}