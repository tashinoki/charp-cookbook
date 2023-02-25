using Microsoft.Extensions.DependencyInjection;

namespace charp_cookbook.Application;

public class Program
{
    readonly IDeploymentService _deploymentService;

    public Program(IDeploymentService deploymentService)
    {
        _deploymentService = deploymentService;
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
        var services = new ServiceCollection();

        services.AddTransient<DeploymentArtifacts>();
        services.AddTransient<DeploymentRepository>();
        services.AddTransient<IDeploymentService, DeploymentService>();

        var serviceProvider = services.BuildServiceProvider();
        var deployMentService = serviceProvider.GetRequiredService<IDeploymentService>();
        
        var program = new Program(deployMentService);
        program.StartValidation();
    }

    public void StartValidation()
    {
        _deploymentService.PerformValidation();
    }
}