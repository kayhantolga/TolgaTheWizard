using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TolgaTheWizard.Extensions
{
    public static class CommunicationExtensions
    {
        /// <summary>
        /// Converts the given collection to a QueryString.
        /// </summary>
        /// <param name="nvc"></param>
        /// <returns></returns>
        public static string ToQueryString(this NameValueCollection nvc)
        {
            var array = (from key in nvc.AllKeys
                    from value in nvc.GetValues(key)
                    select $"{HttpUtility.UrlEncode(key)}={HttpUtility.UrlEncode(value)}")
                .ToArray();
            return string.Join("&", array);
        }

        /// <summary>
        /// Convert the given object to a QueryString
        /// </summary>
        /// <param name="dynamicObject"></param>
        /// <returns></returns>
        public static string ToQueryString(this Object dynamicObject)
        {
            return ToQueryString(dynamicObject.ToNameValueCollection());
        }

        /// <summary>
        /// Converts the given object to NameValue colleciton
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dynamicObject"></param>
        /// <returns></returns>
        public static NameValueCollection ToNameValueCollection<T>(this T dynamicObject)
        {
            var nameValueCollection = new NameValueCollection();
            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(dynamicObject))
            {
                var prop = propertyDescriptor.GetValue(dynamicObject);
                if (prop != null)
                {
                    string value = prop.ToString();
                    nameValueCollection.Add(propertyDescriptor.Name, value);
                }
            }
            return nameValueCollection;
        }
    }
}
