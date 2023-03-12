namespace charp_cookbook.Application;

public interface IDeploymentService
{
    void PerformValidation();
    (bool deployment, bool artifacts) Validate();
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

    public (bool deployment, bool artifacts) Validate()
    {
        var status = new ValidationStatus
        {
            Deployment = false,
            Artifacts = true
        };

        (var deployment, var artifacts) = status;
        return (deployment, artifacts);
    }
}