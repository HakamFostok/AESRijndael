using Microsoft.Extensions.DependencyInjection;

namespace AesRijndaelLibrary;

public static class ServiceCollectionExtensions
{
    public static void RegisterEncryptionDecrptionServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IEncryptor, Encryptor>();
        serviceCollection.AddScoped<IDecreptor, Decreptor>();
    }
}
