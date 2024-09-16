using System.ComponentModel;

namespace BookStore.WebMvc.Extensions
{
    public static class TypeExtensions
    {
        public static Dictionary<string, string> GetPropDisplayNames(this Type type)
        {
            var propertyInfos = type.GetProperties();

            var result = new Dictionary<string, string>();

            foreach (var propertyInfo in propertyInfos)
            {
                var attrs = propertyInfo.GetCustomAttributes(false);

                var propName = propertyInfo.Name;
                var propDisplayName = propertyInfo.Name;

                if (attrs.Count() == 0)
                {
                    continue;
                }

                foreach (var attr in attrs)
                {
                    if (attr is DisplayNameAttribute displayNameAttr)
                    {
                        propDisplayName = displayNameAttr.DisplayName;
                    }
                }

                result.Add(propName, propDisplayName);
            }

            return result;
        }
        
    }
}
