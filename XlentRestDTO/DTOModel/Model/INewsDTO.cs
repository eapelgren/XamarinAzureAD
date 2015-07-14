using System;

namespace DTOModel.Model
{
    public interface INewsDTO
    {
        string Id { get; set; }

        string Header { get; set; }

        string Description { get; set; }

        Uri PictureUri { get; set; }

        string AuthorId { get; set; }

        string DatePosted { get; set; }
    }
}