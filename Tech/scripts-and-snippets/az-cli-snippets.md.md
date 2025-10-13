
#az #ad #api #scope #app
# Expose API scope for the API app (simpler approach)

Needs testing and research.  Might be useful.
```

az ad app update --id $apiAppId --set api.oauth2PermissionScopes="[{`"adminConsentDescription`":`"Allow the application to write user data on behalf of the signed-in user`",`"adminConsentDisplayName`":`"Write user data`",`"id`":`"$API_SCOPE_ID`",`"isEnabled`":true,`"type`":`"User`",`"userConsentDescription`":`"Allow the application to write your user data on your behalf`",`"userConsentDisplayName`":`"Write your user data`",`"value`":`"$API_SCOPE_NAME`"}]"

```
