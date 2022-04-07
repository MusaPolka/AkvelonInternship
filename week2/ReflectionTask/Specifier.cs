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
            var apiParamDescription = new ApiParamDescription();
            var commonDescription = new CommonDescription();
            commonDescription.Name = paramName;

            Type type = typeof(T);

            var method = type.GetMethod(methodName);

            if (method == null)
            {
                apiParamDescription.MinValue = null;
                apiParamDescription.MaxValue = null;
                apiParamDescription.Required = false;
                apiParamDescription.ParamDescription = commonDescription;

                return apiParamDescription;
            }

            var parameters = method.GetParameters();

            var parameter = parameters.SingleOrDefault(x => x.Name == paramName);

            if (parameter == null)
            {
                apiParamDescription.MinValue = null;
                apiParamDescription.MaxValue = null;
                apiParamDescription.Required = false;
                apiParamDescription.ParamDescription = commonDescription;

                return apiParamDescription;
            }

            var paramValue = parameter.GetCustomAttribute<ApiIntValidationAttribute>();
            var paramRequired = parameter.GetCustomAttribute<ApiRequiredAttribute>();
            var paramDescription = parameter.GetCustomAttribute<ApiDescriptionAttribute>();


            if (paramValue != null)
            {
                apiParamDescription.MinValue = paramValue.MinValue;
                apiParamDescription.MaxValue = paramValue.MaxValue;
            }

            if (paramRequired != null)
            {
                apiParamDescription.Required = paramRequired.Required;
            }

            if (paramDescription != null)
            {
                commonDescription.Description = paramDescription.Description;
                apiParamDescription.ParamDescription = commonDescription;
            }

            apiParamDescription.ParamDescription = commonDescription;

            return apiParamDescription;
        }

        public ApiMethodDescription GetApiMethodFullDescription(string methodName)
        {
            ApiMethodDescription apiMethodDescription = new ApiMethodDescription();
            CommonDescription commonMethodDescription = new CommonDescription();
            ApiParamDescription apiReturnDescription = new ApiParamDescription();

            Type type = typeof(T);

            var method = type.GetMethod(methodName);

            if (method == null)
            {
                return apiMethodDescription;
            }
            commonMethodDescription.Name = methodName;

            var methodDescription = method.GetCustomAttribute<ApiDescriptionAttribute>();

            if (methodDescription != null)
            {
                commonMethodDescription.Description = methodDescription.Description;
            }

            var apiMethod = method.GetCustomAttribute<ApiMethodAttribute>();

            if (apiMethod == null)
            {
                return null;
            }

            apiMethodDescription.MethodDescription = commonMethodDescription;


            var parameters = method.GetParameters();

            ApiParamDescription[] paramDescriptions = new ApiParamDescription[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                paramDescriptions[i] = GetApiMethodParamFullDescription(methodName, parameters[i].Name);
            }

            apiMethodDescription.ParamDescriptions = paramDescriptions;


            var returnParamDescription = method.ReturnParameter.GetCustomAttribute<ApiDescriptionAttribute>();
            var returnParamValue = method.ReturnParameter.GetCustomAttribute<ApiIntValidationAttribute>();
            var returnParamRequired = method.ReturnParameter.GetCustomAttribute<ApiRequiredAttribute>();

            if (returnParamDescription != null)
            {
                apiReturnDescription.ParamDescription = new CommonDescription() {Name = method.ReturnParameter.Name , Description = returnParamDescription.Description };
            }
            if (returnParamValue != null)
            {
                apiReturnDescription.MaxValue = returnParamValue.MaxValue;
                apiReturnDescription.MinValue = returnParamValue.MinValue;
            }
            if (returnParamRequired != null)
            {
                apiReturnDescription.Required = returnParamRequired.Required;
            }

            apiMethodDescription.ReturnDescription = apiReturnDescription;

            return apiMethodDescription;
        }
    }
}