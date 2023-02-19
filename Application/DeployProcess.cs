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

internal class DeployProcess: IDisposable
{
    private bool _disposed;

    private readonly StreamWriter _report = new("");

    public bool CheckStatus()
    {
        _report.WriteLine("Hello World./");

        return true;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {

            }

            _report?.Close();
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}