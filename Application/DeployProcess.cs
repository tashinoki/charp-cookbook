namespace charp_cookbook.Application;

internal class BadDeployProcess
{
    private readonly StreamWriter _report = new("");

    public bool CheckStatus()
    {
        _report.WriteLine("Hello World./");

        return true;
    }
}

