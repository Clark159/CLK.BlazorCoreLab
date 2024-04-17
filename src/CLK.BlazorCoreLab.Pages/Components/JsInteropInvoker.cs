using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace CLK.BlazorCoreLab.Components
{
    public class JsInteropInvoker
    {
        private readonly IServiceProvider _serviceProvider;

        public JsInteropInvoker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [JSInvokable]
        public async Task<object> InvokeMethodAsync(string typeName, string methodName, Dictionary<string, string> args)
        {
            var type = Type.GetType(typeName);
            if (type == null) throw new ArgumentException("Type not found.");

            var service = _serviceProvider.GetRequiredService(type);
            var method = type.GetMethod(methodName);
            if (method == null) throw new ArgumentException("Method not found.");

            ParameterInfo[] parameters = method.GetParameters();
            object[] actualParams = new object[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                var param = parameters[i];
                if (args.TryGetValue(param.Name, out string value))
                    actualParams[i] = Convert.ChangeType(value, param.ParameterType);
                else
                    throw new ArgumentException($"No value provided for parameter {param.Name}.");
            }

            var result = method.Invoke(service, actualParams);
            if (result is Task task)
            {
                await task;
                return task.GetType().IsGenericType ? ((dynamic)task).Result : null;
            }

            return result;
        }
    }
}
