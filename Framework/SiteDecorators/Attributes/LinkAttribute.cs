using System;

namespace Framework.SiteDecorators.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class LinkAttribute : Attribute
    {
        public readonly string Link;
        public LinkAttribute(string link) => Link = link;
    }
}
