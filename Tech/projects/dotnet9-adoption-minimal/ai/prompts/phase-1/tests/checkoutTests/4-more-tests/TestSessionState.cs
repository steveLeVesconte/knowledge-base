// TestInfrastructure/Fakes/TestSessionState.cs
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;

namespace MvcMusicStore.Tests.TestInfrastructure.Fakes
{
    public class TestSessionState : HttpSessionStateBase
    {
        private readonly Dictionary<string, object> _sessionData = new Dictionary<string, object>();

        public TestSessionState(string sessionId = null)
        {
            if (!string.IsNullOrEmpty(sessionId))
            {
                _sessionData["CartId"] = sessionId;
            }
        }

        public override object this[string name]
        {
            get => _sessionData.ContainsKey(name) ? _sessionData[name] : null;
            set => _sessionData[name] = value;
        }

        public override void Add(string name, object value)
        {
            _sessionData[name] = value;
        }

        public override void Remove(string name)
        {
            _sessionData.Remove(name);
        }

        public override IEnumerator GetEnumerator()
        {
            return _sessionData.GetEnumerator();
        }
    }
}