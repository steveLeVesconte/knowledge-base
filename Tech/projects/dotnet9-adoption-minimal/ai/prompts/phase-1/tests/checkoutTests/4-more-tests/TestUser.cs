// TestInfrastructure/Fakes/TestUser.cs
using System.Security.Principal;

namespace MvcMusicStore.Tests.TestInfrastructure.Fakes
{
    public class TestUser : IPrincipal, IIdentity
    {
        private readonly string _userName;
        private readonly bool _isAuthenticated;

        public TestUser(string userName = null, bool isAuthenticated = false)
        {
            _userName = userName ?? string.Empty;
            _isAuthenticated = isAuthenticated;
        }

        public IIdentity Identity => this;

        public bool IsInRole(string role) => false;

        public string AuthenticationType => "TestAuth";

        public bool IsAuthenticated => _isAuthenticated;

        public string Name => _userName;
    }
}