using DTOModel.Model;
using XamarinAzureAD.Model;

namespace XamarinAzureAD.Mapper
{
    public static class CommentMapper
    {
        public static ObservableComment Convert(ICommentDTO commentDTO)
        {
            return new ObservableComment
            {
                Author = new UserMapper().Convert(commentDTO.Author),
                Comment = commentDTO.Comment,
                Id = commentDTO.Id
            };
        }
    }
}