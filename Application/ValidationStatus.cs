namespace charp_cookbook.Application;

internal class ValidationStatus
{
    public bool Deployment { get; init; }

    public bool Artifacts { get; init; }

    public void Deconstruct(
        out bool deployment,
        out bool artifacts)
    {
        deployment = Deployment;
        artifacts = Artifacts;
    }
}

