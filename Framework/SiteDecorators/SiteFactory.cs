using Framework.Driver;
using Framework.SiteDecorators.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using Framework.Pages.Interfaces;

namespace Framework.SiteDecorators
{
    public sealed class SiteFactory
    {

        public static void InitElements(object site, BaseDriver baseDriver)
        {
            if (site == null)
            {
                throw new ArgumentNullException("site", "site cannot be null");
            }

            if (baseDriver == null)
            {
                throw new ArgumentNullException("baseDriver", "baseDriver cannot be null");
            }

            const BindingFlags PublicBindingOptions = BindingFlags.Instance | BindingFlags.Public;
            const BindingFlags NonPublicBindingOptions = BindingFlags.Instance | BindingFlags.NonPublic;

            // Get a list of all of the fields and properties (public and non-public [private, protected, etc.])
            var type = site.GetType();
            var members = new List<MemberInfo>();
            members.AddRange(type.GetFields(PublicBindingOptions));
            members.AddRange(type.GetProperties(PublicBindingOptions));
            while (type != null)
            {
                members.AddRange(type.GetFields(NonPublicBindingOptions));
                members.AddRange(type.GetProperties(NonPublicBindingOptions));
                type = type.BaseType;
            }

            foreach (var member in members)
            {
                // Examine each member, and if the decorator returns a non-null object,
                // set the value of that member to the decorated object.
                FieldInfo field = member as FieldInfo;
                Type targetType = null;
                if (field != null)
                {
                    targetType = field.FieldType;
                }
                if (typeof(IAbstractPage).IsAssignableFrom(targetType))
                {
                    // Getting Link attributes 
                    var attributes = Attribute.GetCustomAttributes(member, typeof(LinkAttribute));
                    string link = null;
                    if (attributes.Length != 0)
                    {
                        var linkAttribute = attributes[0] as LinkAttribute;
                        link = linkAttribute.Link;
                    }
                    //Decorating all PageObject members
                    var decoratedValue = Decorate(targetType, baseDriver, link);
                    if (decoratedValue == null)
                    {
                        continue;
                    }
                    var property = member as PropertyInfo;
                    if (field != null)
                    {
                        field.SetValue(site, decoratedValue);
                    }
                    else if (property != null)
                    {
                        property.SetValue(site, decoratedValue, null);
                    }
                }
            }
        }

        private static object Decorate(Type targetType, BaseDriver baseDriver, string link)
        {
            return string.IsNullOrEmpty(link) ?
                 targetType.GetConstructor(new[] { typeof(BaseDriver), }).Invoke(new object[] { baseDriver }) :
                 targetType.GetConstructor(new[] { typeof(BaseDriver), typeof(string) }).Invoke(new object[] { baseDriver, link });

        }
    }
}
