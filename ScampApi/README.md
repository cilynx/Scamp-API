
### Running with specific Tenant and Client ID ###

This makes use of environment variables that need to be added.

In your Package Manager Console, before you debug - add 2 $env variabiels.

```
    PM> $env:APPSETTING_TenantId = "foo"
    PM> $env:APPSETTING_ClientId = "bar"
````


Or, these can be set also from Project Properties -> Debug -> Environment Variables to set
    APPSETTING_TenantId
    APPSETTING_ClientId


This format is used as this is what AZW uses
