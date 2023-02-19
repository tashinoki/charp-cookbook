// See https://aka.ms/new-console-template for more information

//// Manage Object lifetime.

using charp_cookbook.Application;

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