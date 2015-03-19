# Simple Cloud Manager Project - Web Application #
This project contains a single Web App that contains both the Views/Pages along with the Web API in support of the Pages.

### Setting Azure Active Directory Tenant ###

You an use an existing Azure Active Directory AAD tenant (all Azure subscriptions have one associated with it). Or create a new AAD tenant in the [Portal](https://manage.windowsazure.com).  See [http://www.windowsazure.com](http://www.windowsazure.com).  

### Step 1:  Clone or download this repository

From your shell or command line:

	`git clone https://github.com/SimpleCloudManagerProject/Scamp-API`

### Step 2:  Register the Scamp Web App on your Azure Active Directory tenant

1. Sign in to the [Azure management portal](https://manage.windowsazure.com).
2. Click on Active Directory in the left hand nav.
3. Click the directory tenant where you wish to register the sample application.
4. Click the Applications tab.
5. In the drawer, click Add.
6. Click "Add an application my organization is developing".
7. Enter a friendly name for the application, for example "Scamp", select "Web Application and/or Web API", and click next.
8. For the sign-on URL, enter the base URL for the sample, `https://localhost:44300/`. We'll use this later.
9. For the App ID URI, enter `https://<your_tenant_name>/Scamp`, replacing `<your_tenant_name>` with the name of your Azure AD tenant.  Save the configuration.
10. Also, get the TenantID from the URL in your browser. eg. below in the URL you'll see a guid which is your Tenant ID.
```
../ActiveDirectoryExtension/Directory/<tenantId>/directoryQuickStart
```
11. Also, get the ClientID from the Application settings.  On the Application -> Configure tab, grap the "CLIENT ID" value.

### Step 3:  Configure the Scamp Web App to use your Azure Active Directory tenant
TODO


### Step 4:  Enable the OAuth2 implicit grant for your application

By default, applications provisioned in Azure AD are not enabled to use the OAuth2 implicit grant. In order to run this sample, you need to explicitly opt in.

1. From the former steps, your browser should still be on the Azure management portal - and specifically, displaying the Configure tab of your application's entry.
2. Using the Manage Manifest button in the drawer, download the manifest file for the application and save it to disk.
3. Open the manifest file with a text editor. Search for the `oauth2AllowImplicitFlow` property. You will find that it is set to `false`; change it to `true` and save the file.
4. Using the Manage Manifest button, upload the updated manifest file. Save the configuration of the app.

### Step 5:  Configure the Scamp Application to use your Azure Active Directory tenant

1. TODO:
2. Open the solution in Visual Studio 2015 CTP 6
3. In the Projects -> ScampAPI -> Properties folder, create a file: **debugSettings.json**:



```javascript
{
    "profiles": [
        {
            "name": "IIS Express",
            "launchBrowser": true,
            "launchUrl": "https://localhost:44300/",
            "environmentVariables": {
                "APPSETTING_ClientId": "<clientId-from above App in AAD>",
                "APPSETTING_TenantId": "<tenantId-from above App in AAD->",
                "APPSETTING_RedirectUri": "https://localhost:44300/"
                "APPSETTING_DocDb:databaseName": "scamp",
                "APPSETTING_DocDb:collectionName": "scampdata"
            }
        }
    ]
}

```

### Step 6: Configure IIS Express bindings for HTTPS
1. Start the Project - this will launch the site and automatically setup the IIS Express site.
2. It will fail as the bindings for the site to support HTTPS on port 44300 haven't been added yet. We just ran it now to force the creation of the site.
2. Until the VS 2015 CTP tooling has the settings, you have to modify IIS Express configuration.
2. Open your **%USERPROFILE%\Documents\IISExpress\config\applicationhost.config** file
3. locate the <site... element that contains your site
4. Add a new binding as follows so the <../sites/bindings> section looks like:

````
<bindings>
    <binding protocol="http" bindingInformation="*:10838:localhost" />
    <binding protocol="https" bindingInformation="*:44300:localhost" />
</bindings>
````

### Running with specific Tenant and Client ID ###

This makes use of environment variables that need to be added.

In your Package Manager Console, before you debug - add $env variabiels.

    PM> $env:APPSETTING_TenantId = "foo"
    PM> $env:APPSETTING_ClientId = "bar"
    PM> $env:AppSETTING_DocDb:endpoint = "<url here>"
    PM> $env:AppSETTING_DocDb:authkey = "<key here>"
    PM> $env:AppSETTING_DocDb:databaseName = "<db name here, e.g. scamp>"
    PM> $env:AppSETTING_DocDb:collectionName = "<collection name>"

Or, these can be set also from Project Properties -> Debug -> Environment Variables to set.
This format is used as this is what AZW uses for Environment variables. 


````
APPSETTING_TenantId
APPSETTING_ClientId
APPSETTING_DocDb:endpoint
APPSETTING_DocDb:authkey
APPSETTING_DocDb:databaseName
APPSETTING_DocDb:collectionName
````

### Settings For Site ###
- **TenantId** this is the Tenant ID of the AAD Domain. This can be retrieved from the Azure Portal from the URL.
- **ClientId** this is the Client ID for the Scamp application once it's been setup in an AAD tenant. This comes from the Applications Configure page for that specific AAD Tenant.
- **DocDB:endpoint** this is the DocumentDB URL that comes from the [Azure Preview Portal](https://portal.azure.com)
- **DocDB:authkey** this is the DocumentDB key that comes from the [Azure Preview Portal](https://portal.azure.com)
- **DocDb:databaseName** this is '**scamp**' by default the Scamp code will create this if it doesn't exist already
- **DocDb:collectionName** this is '**scampdata**' by default the Scamp code will create this if it doesn't exist already.

#### Sample Data Generation ####

There is a temporary endpoint to aid the demo scenario (that we should plan to remove). Hit /sampledata to generate sample data. There's still some work to do to generate more meaningful sample data.
