namespace Samples.Http.Client.Ioc
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using Refit;
    using Core;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddValuesServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<MyToken>() //will eventually inject from HTTP pipeline
                .AddTransient<IValuesController>(provider =>
                {
                    var token = provider.GetRequiredService<MyToken>();

                    var refitSettings = new RefitSettings
                        {AuthorizationHeaderValueGetter = () => Task.FromResult(token.Value)};

                    return RestService.For<IValuesController>("http://localhost:5000", refitSettings);
                })
                .AddTransient<IValuesClient, ValuesClient>()
                .AddTransient<RunExamples>();
        }
    }
}
