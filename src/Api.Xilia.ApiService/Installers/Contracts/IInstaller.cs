namespace Api.Intuit.ApiService.Installers.Contracts
{
    public interface IInstallerApplicationBuilder
    {
        void InstallApplication(IApplicationBuilder app, IConfiguration configuration);
    }

    public interface IInstallerServiceCollection
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
