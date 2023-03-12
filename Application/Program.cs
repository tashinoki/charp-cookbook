using Microsoft.Extensions.DependencyInjection;

namespace charp_cookbook.Application;

public class Program
{
    readonly IDeploymentService _deploymentService;
    private readonly IThirdPartyServiceFactory _thirdPartyServiceFactory;

    public Program(IDeploymentService deploymentService,
        IThirdPartyServiceFactory thirdPartyServiceFactory)
    {
        _deploymentService = deploymentService;
        _thirdPartyServiceFactory = thirdPartyServiceFactory;
    }

    public static void Main()
    {
        //// Manage Object lifetime.
        //foreach (var _ in Enumerable.Range(1, 10))
        //{
        //    var badDeploymentProcess = new BadDeployProcess();
        //    badDeploymentProcess.CheckStatus();
        //}

        foreach (var _ in Enumerable.Range(1, 10))
        {
            using var badDeploymentProcess = new DeployProcess();
            badDeploymentProcess.CheckStatus();
        }


        //// Tight coupling
        //var services = new ServiceCollection();

        //services.AddTransient<DeploymentArtifacts>();
        //services.AddTransient<DeploymentRepository>();
        //services.AddTransient<IDeploymentService, DeploymentService>();

        //var serviceProvider = services.BuildServiceProvider();
        //var deployMentService = serviceProvider.GetRequiredService<IDeploymentService>();
        
        //var program = new Program(deployMentService);
        //program.StartValidation();


        //// ThirdParty Service
        //var services = new ServiceCollection();
        //services.AddSingleton<IThirdPartyServiceFactory, ThirdPartyServiceFactory>();

        //var serviceProvider = services.BuildServiceProvider();
        //var factory = serviceProvider.GetRequiredService<IThirdPartyServiceFactory>();
        //var p = new Program(null, factory);
        //p.Validate();


        //// Factory method
        var p = new Program(null, null);
        p.Run(new PluginManagementBase[]
        {
            new PluginManager1(),
            new PluginManager2()
        });

        //// Tuple
        var services = new ServiceCollection();
        services.AddTransient<DeploymentArtifacts>();
        services.AddTransient<DeploymentRepository>();
        services.AddTransient<IDeploymentService, DeploymentService>();

        var serviceProvider = services.BuildServiceProvider();
        var deployMentService = serviceProvider.GetRequiredService<IDeploymentService>();
        (var deployment, var artifacts) = deployMentService.Validate();
        Console.WriteLine($"Deployment: {deployment}, Artifacts: {artifacts}");
    }

    public void StartValidation()
    {
        _deploymentService.PerformValidation();
    }

    public void Validate()
    {
        _thirdPartyServiceFactory.Create().Validate();
    }

    internal void Run(PluginManagementBase[] bases)
    {
        foreach (var plugin in bases)
        {
            plugin.Validate();
        }
    }
}