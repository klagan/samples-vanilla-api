using Samples.Http.Client.Ioc;

namespace Samples.Http.Client
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;

    internal class Program
    {
        private const string Token = "my-token";  // will eventually take from the HTTP pipeline

        private static async Task Main()
        {
            var services = new ServiceCollection().AddValuesServices();
            var serviceProvider = services.BuildServiceProvider();
            
            Console.WriteLine("Press <RETURN> when the API is ready...");
            Console.ReadLine();

            await serviceProvider
                .GetRequiredService<RunExamples>()
                .ExecuteAsync();
        }
    }
}
