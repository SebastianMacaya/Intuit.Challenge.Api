using Api.Intuit.ApiService.Configurations;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Features.Variance;

namespace Api.Intuit.ApiService.Extensions
{
    public static class WebApplicationBuilderExtension
    {
        public static void ConfigureHostDI(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterSource(new ContravariantRegistrationSource());
                builder.RegisterModule(new DataAutofacModule());
                builder.RegisterModule(new MediatrAutofacModule());
                builder.RegisterModule(new ServicesAutofacModule());
                builder.RegisterModule(new MappersAutofacModule());
            });
        }
    }
}
