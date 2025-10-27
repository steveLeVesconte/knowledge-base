using System.Collections.Generic;
using System.Web;

namespace MvcMusicStore.Tests.TestInfrastructure.Fakes
{
    /// <summary>
    /// Test double for HttpSessionStateBase that uses an in-memory dictionary.
    /// Provides session storage functionality required for ShoppingCart cart ID management.
    /// </summary>
    public class TestSessionState : HttpSessionStateBase
    {
        private readonly Dictionary<string, object> _sessionStorage = new Dictionary<string, object>();

        public override object this[string name]
        {
            get => _sessionStorage.ContainsKey(name) ? _sessionStorage[name] : null;
            set => _sessionStorage[name] = value;
        }
    }
}