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
        public void SayHello(string message)
        {
            
        }
    }
}
