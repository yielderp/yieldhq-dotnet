using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using YieldHQ.Client.Http;

namespace YieldHQ.Client.DependencyInjection;

/// <summary>
/// Extension methods for registering <see cref="YieldHQClient"/> in the DI container.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the YieldHQ API client with the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configure">Action to configure <see cref="YieldHQClientOptions"/>.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddYieldClient(this IServiceCollection services, Action<YieldHQClientOptions> configure)
    {
        services.Configure(configure);

        services.AddHttpClient<YieldHQClient>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<YieldHQClientOptions>>().Value;
            client.BaseAddress = new Uri(options.BaseUrl.TrimEnd('/') + "/");
            client.Timeout = options.Timeout;
        }).AddHttpMessageHandler(sp =>
        {
            var options = sp.GetRequiredService<IOptions<YieldHQClientOptions>>().Value;
            return new YieldHttpHandler(options);
        });

        return services;
    }
}
