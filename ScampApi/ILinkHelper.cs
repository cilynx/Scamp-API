namespace ScampApi.Infrastructure
{
    public interface ILinkHelper
    {
        string Groups();
        string Group(string groupId);
        string GroupResource(string groupId, int resourceId);
        string GroupTemplate(string groupId, int templateId);
        string GroupUser(string groupId, int userId);
        string CurrentUser();
        string Users();
        string User(int userId);
        string GroupResourceUser(string groupId, int resourceId, int userId);
    }
}