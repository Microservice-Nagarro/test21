﻿using BHF.MS.MyMicroservice.Models;
using BHF.MS.MyMicroservice.Models.Settings;
using Microsoft.Extensions.Options;

namespace BHF.MS.MyMicroservice.Services
{
    public class ExampleService2(IHttpClientFactory httpClientFactory, IOptions<Service2Settings>? settings) : IExampleService2
    {
        public async Task<HttpResponseMessage> DoSomethingAsync(ExampleModel model)
        {
            var client = httpClientFactory.CreateClient();
            var baseAddress = settings?.Value.BaseAddress;
            return await client.PostAsJsonAsync(baseAddress, model);
        }
    }
}
