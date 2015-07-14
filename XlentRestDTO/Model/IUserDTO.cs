using System;

namespace DTOModel.Model
{
    public interface IUserDTO
    {
        Uri AuthorImageUri { get; set; }

        string DisplayName { get; set; }

        string GivenName { get; set; }

        string Id { get; set; }

        string Location { get; set; }

        string SurName { get; set; }

        string TelephoneNumber { get; set; }
    }
}