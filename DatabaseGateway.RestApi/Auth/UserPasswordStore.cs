using System.Collections.Generic;

namespace DatabaseGateway.RestApi.Auth
{
    public static class UserPasswordStore
    {
        private static Dictionary<string, string> userPasswordTable;

        static UserPasswordStore()
        {
            userPasswordTable = new Dictionary<string, string>()
            {
                {"jane", "jane" },
                {"john", "john" }
            };
        }
    }
}
