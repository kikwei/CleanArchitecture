namespace ProductsCleanArch.Presentation.Authentication
{
    public interface IJwtAuthentication
    {
        string Authenticate(string userName, string password);
    }
}