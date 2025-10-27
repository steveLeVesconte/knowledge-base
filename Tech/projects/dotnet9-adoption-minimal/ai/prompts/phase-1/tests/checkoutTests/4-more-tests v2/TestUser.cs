using System.Security.Principal;

namespace MvcMusicStore.Tests.TestInfrastructure.Fakes
{
    /// <summary>
    /// Test double for IPrincipal that simulates authenticated and anonymous users.
    /// </summary>
    public class TestUser : IPrincipal
    {
        private readonly IIdentity _identity;

        /// <summary>
        /// Creates an anonymous (unauthenticated) test user.
        /// </summary>
        public TestUser() : this(null)
        {
        }

        /// <summary>
        /// Creates an authenticated test user with the specified username.
        /// </summary>
        /// <param name="userName">The username (null for anonymous user)</param>
        public TestUser(string userName)
        {
            _identity = new TestIdentity(userName);
        }

        public IIdentity Identity => _identity;

        public bool IsInRole(string role)
        {
            // Simple implementation - extend if role-based tests are needed
            return false;
        }

        private class TestIdentity : IIdentity
        {
            private readonly string _name;

            public TestIdentity(string name)
            {
                _name = name;
            }

            public string Name => _name ?? string.Empty;

            public string AuthenticationType => string.IsNullOrEmpty(_name) ? null : "TestAuth";

            public bool IsAuthenticated => !string.IsNullOrEmpty(_name);
        }
    }
}