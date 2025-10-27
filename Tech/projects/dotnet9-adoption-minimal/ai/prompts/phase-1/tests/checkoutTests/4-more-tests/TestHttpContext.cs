// TestInfrastructure/Fakes/TestHttpContext.cs
using System;
using System.Security.Principal;
using System.Web;
using System.Web.SessionState;

namespace MvcMusicStore.Tests.TestInfrastructure.Fakes
{
    public class TestHttpContext : HttpContextBase
    {
        private readonly TestSessionState _session;
        private readonly IPrincipal _user;

        public TestHttpContext(string sessionId = null, IPrincipal user = null)
        {
            _session = new TestSessionState(sessionId);
            _user = user ?? new TestUser();
        }

        public override HttpSessionStateBase Session => _session;

        public override IPrincipal User => _user;
    }
}