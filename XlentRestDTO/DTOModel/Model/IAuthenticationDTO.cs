namespace DTOModel.Model
{
    public interface IAuthenticationDTO
    {
        string AccessToken { get; set; }

        string RefreshToken { get; set; }

        string AuthenticationUserId { get; set; }
    }
}