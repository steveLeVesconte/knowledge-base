using System;
using System.Security.Principal;
using System.Web;

namespace MvcMusicStore.Tests.TestInfrastructure.Fakes
{
    /// <summary>
    /// Test double for HttpContextBase that provides minimal functionality required for ShoppingCart tests.
    /// Supports session state and user identity simulation.
    /// </summary>
    public class TestHttpContext : HttpContextBase
    {
        private readonly TestSessionState _session;
        private readonly IPrincipal _user;

        /// <summary>
        /// Creates a test HTTP context with an anonymous user and the specified cart ID.
        /// </summary>
        /// <param name="cartId">The cart ID to store in session</param>
        public TestHttpContext(string cartId) : this(cartId, null)
        {
        }

        /// <summary>
        /// Creates a test HTTP context with a specific user and cart ID.
        /// </summary>
        /// <param name="cartId">The cart ID to store in session</param>
        /// <param name="userName">The username for the authenticated user (null for anonymous)</param>
        public TestHttpContext(string cartId, string userName)
        {
            _session = new TestSessionState();
            _session["CartId"] = cartId;
            
            _user = userName == null 
                ? new TestUser() 
                : new TestUser(userName);
        }

        public override HttpSessionStateBase Session => _session;

        public override IPrincipal User => _user;
    }
}