
Testing suggest in phase-2

**Phase 2a HTTPS Testing Scope**:
- [ ] Azure App Service HTTPS-only mode enforcement
- [ ] TLS certificate configuration and validation
- [ ] Secure cookie attributes (`Secure`, `SameSite`) verification
- [ ] HTTP-to-HTTPS redirect behavior
- [ ] OWIN cookie authentication over HTTPS (ApplicationCookie, ExternalCookie)
- [ ] Anti-forgery token functionality over HTTPS
- [ ] Session state persistence over HTTPS (shopping cart validation)
- [ ] Mixed content warnings check (all resources load over HTTPS)



discussions:
https://claude.ai/chat/0295eaa7-92f9-4081-9c72-a17283d4d7e1
https://claude.ai/chat/caa0e893-93b7-4e65-b559-a68149b00ddc



The following may be true.
**Why This Decision**

- Local HTTPS requires IIS Express SSL config, self-signed cert trust, limited value for testing

- Azure App Service provides production-grade HTTPS out-of-box (automatic cert management)

- No external OAuth dependency yet (providers disabled until Phase 5)

- OWIN cookie authentication designed to work over HTTP or HTTPS transparently

- Better to validate in actual deployment environment than simulate locally

**Phase 5 Note**

- OAuth external providers (Microsoft, Google) require HTTPS redirect URIs

- Phase 2a HTTPS validation establishes foundation for Phase 5 work

- OAuth-specific HTTPS testing (callbacks, state parameters) deferred to Phase 5