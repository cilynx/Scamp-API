using System;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.ConfigurationModel;

namespace ScampApi.Infrastructure
{
    public class LinkHelper : ILinkHelper
    {
        private readonly string _apiRootUrl;
        private IUrlHelper _urlHelper;

        public LinkHelper(IUrlHelper urlHelper, IConfiguration configuration)
        {
            _urlHelper = urlHelper;
            _apiRootUrl = configuration.Get("ApiRootUrl");
        }

        public string Groups()
        {
            return FullyQualify(_urlHelper.RouteUrl("Groups.GetAll"));
        }
        
        public string Group(int groupId)
        {
            return FullyQualify(_urlHelper.RouteUrl("Groups.GetSingle", new { groupId }));
        }

        public string GroupResource(int groupId, int resourceId)
        {
            return FullyQualify(_urlHelper.RouteUrl("GroupResources.GetSingle", new { groupId, resourceId }));
        }
        public string GroupTemplate(int groupId, int templateId)
        {
            return FullyQualify(_urlHelper.RouteUrl("GroupTemplates.GetSingle", new { groupId, templateId }));
        }
        public string GroupUser(int groupId, int userId)
        {
            return FullyQualify(_urlHelper.RouteUrl("GroupUsers.GetSingle", new { groupId , userId }));
        }
        public string GroupResourceUser(int groupId, int resourceId, int userId)
        {
            return FullyQualify(_urlHelper.RouteUrl("GroupResourceUsers.GetSingle", new { groupId, resourceId , userId }));
        }

        public string CurrentUser()
        {
            return FullyQualify(_urlHelper.RouteUrl("User.CurrentUser"));
        }
        public string Users()
        {
            return FullyQualify(_urlHelper.RouteUrl("Users.GetAll"));
        }
        public string User(int userId)
        {
            return FullyQualify(_urlHelper.RouteUrl("Users.GetSingle", new {  userId }));
        }
        private string FullyQualify(string url)
        {
            // TODo - put proper implementation here ;-)
            return _apiRootUrl + url;
        }


    }
}