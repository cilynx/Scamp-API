using Microsoft.Framework.ConfigurationModel;
using System;

namespace ScampApi.ViewModels
{
    public class ScampSettings
    {

        public string TenantId { get; set; }
        public string ClientId { get; set; }

        public string ExtraQueryParameter { get; set; }

        public string CacheLocation { get; set; }
        public string RedirectUri { get; set; }

        public ScampSettings()
        {
            var settings = new
            {
                tenantId = "dpe1.onmicrosoft.com",
                clientId = "5480d52a-a26b-47f5-a0a7-c4838f543f7e",
                extraQueryParameter = "nux=1",
                cacheLocation = "localStorage",
                redirectUri = "https://localhost:44300/oauth"
            };

            this.TenantId = settings.tenantId;
            this.ClientId = settings.clientId;
            this.ExtraQueryParameter = settings.extraQueryParameter;
            this.CacheLocation = settings.cacheLocation;
            this.RedirectUri = settings.redirectUri;
        }

    }

}