using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MVWorkflows.Application.Interfaces.Repositories;
using MVWorkflows.Application.Interfaces.Services.Storage;
using MVWorkflows.Application.Interfaces.Services.Storage.Provider;
using MVWorkflows.Application.Interfaces.Serialization.Serializers;
using MVWorkflows.Application.Serialization.JsonConverters;
using MVWorkflows.Infrastructure.Repositories;
using MVWorkflows.Infrastructure.Services.Storage;
using MVWorkflows.Application.Serialization.Options;
using MVWorkflows.Infrastructure.Services.Storage.Provider;
using MVWorkflows.Application.Serialization.Serializers;

namespace MVWorkflows.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddTransient(typeof(IRepositoryAsync<,>), typeof(RepositoryAsync<,>))
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<IBrandRepository, BrandRepository>()
                .AddTransient<IDocumentRepository, DocumentRepository>()
                .AddTransient<IWorkflowsRepository, WorkflowsRepository>()
                .AddTransient<IWorkflowInstanceRepository, WorkflowInstanceRepository>()
                .AddTransient<IWorkflowInstanceActionsRepository, WorkflowInstanceActionsRepository>()
                .AddTransient<IDocumentTypeRepository, DocumentTypeRepository>()
                .AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        }

        public static IServiceCollection AddExtendedAttributesUnitOfWork(this IServiceCollection services)
        {
            return services
                .AddTransient(typeof(IExtendedAttributeUnitOfWork<,,>), typeof(ExtendedAttributeUnitOfWork<,,>));
        }

        public static IServiceCollection AddServerStorage(this IServiceCollection services)
            => AddServerStorage(services, null);

        public static IServiceCollection AddServerStorage(this IServiceCollection services, Action<SystemTextJsonOptions> configure)
        {
            return services
                .AddScoped<IJsonSerializer, SystemTextJsonSerializer>()
                .AddScoped<IStorageProvider, ServerStorageProvider>()
                .AddScoped<IServerStorageService, ServerStorageService>()
                .AddScoped<ISyncServerStorageService, ServerStorageService>()
                .Configure<SystemTextJsonOptions>(configureOptions =>
                {
                    configure?.Invoke(configureOptions);
                    if (!configureOptions.JsonSerializerOptions.Converters.Any(c => c.GetType() == typeof(TimespanJsonConverter)))
                        configureOptions.JsonSerializerOptions.Converters.Add(new TimespanJsonConverter());
                });
        }
    }
}