namespace charp_cookbook.Application;

public interface IDeploymentService
{
    void PerformValidation();
}

public class DeploymentService: IDeploymentService
{
    private readonly DeploymentArtifacts _deploymentArtifacts;
    private readonly DeploymentRepository _deploymentRepository;

    public DeploymentService(
        DeploymentArtifacts deploymentArtifacts,
        DeploymentRepository deploymentRepository)
    {
        _deploymentArtifacts = deploymentArtifacts;
        _deploymentRepository = deploymentRepository;
    }

    public void PerformValidation()
    {
        _deploymentArtifacts.Validate();
        _deploymentRepository.SaveStatus("status");
    }
}