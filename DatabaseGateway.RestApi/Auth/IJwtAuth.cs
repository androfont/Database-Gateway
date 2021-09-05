namespace DatabaseGateway.RestApi.Auth
{
    public interface IJwtAuth
    {
        string Authenticate(string username, string password);
    }
}
