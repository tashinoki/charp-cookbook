namespace charp_cookbook.Application;

public class Program
{
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
    }
}