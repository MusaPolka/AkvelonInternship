using System;
using System.Linq;
using System.Reflection;

namespace Documentation
{
    public class Specifier<T> : ISpecifier
    {
        public string GetApiDescription()
        {
            Type type = typeof(T);

            var attribute = type.GetCustomAttribute<ApiDescriptionAttribute>();

            if (attribute != null)
            {
                return attribute.Description;
            }

            return null;
        }

        public string[] GetApiMethodNames()
        {
            Type type = typeof(T);

            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(m => m.GetCustomAttribute<ApiMethodAttribute>() != null)
                .Select(m => m.Name);

            return methods.ToArray();
        }

        public string GetApiMethodDescription(string methodName)
        {
            Type type = typeof(T);

            var method = type.GetMethod(methodName);

            if (method == null)
            {
                return null;
            }

            var result = method.GetCustomAttribute<ApiDescriptionAttribute>();

            if (result == null)
            {
                return null;
            }

            return result.Description;
        }

        public string[] GetApiMethodParamNames(string methodName)
        {
            Type type = typeof(T);

            var method = type.GetMethod(methodName);

            if (method == null)
            {
                return null;
            }

            var parameters = method.GetParameters();

            string[] result = parameters.Select(x => x.Name).ToArray();

            return result;
        }

        public string GetApiMethodParamDescription(string methodName, string paramName)
        {
            Type type = typeof(T);

            var method = type.GetMethod(methodName);

            if (method == null)
            {
                return null;
            }

            var parameters = method.GetParameters();

            var parameter = parameters.SingleOrDefault(x => x.Name == paramName);

            if (parameter == null)
            {
                return null;
            }

            var result = parameter.GetCustomAttribute<ApiDescriptionAttribute>();

            if (result == null)
            {
                return null;
            }

            return result.Description;
        }

        public ApiParamDescription GetApiMethodParamFullDescription(string methodName, string paramName)
        {
            return new ApiParamDescription();
        }

        public ApiMethodDescription GetApiMethodFullDescription(string methodName)
        {
            return new ApiMethodDescription();
        }
    }
}