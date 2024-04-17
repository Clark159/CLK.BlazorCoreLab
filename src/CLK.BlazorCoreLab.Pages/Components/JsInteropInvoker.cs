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
        public Task<string> SayHelloAsync(string message)
        {
            // MessageService
            var messageService = _serviceProvider.GetService<MessageService>();
            if(messageService == null) throw new InvalidOperationException($"{nameof(MessageService)}=null");

            // Result
            var result = messageService.GetValue();
            if (string.IsNullOrEmpty(result) == true) throw new InvalidOperationException($"{nameof(result)}=null");

            // Return
            return Task.FromResult(result);
        }
    }
}
