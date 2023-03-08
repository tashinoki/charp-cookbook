namespace charp_cookbook.Application;

internal abstract class PluginManagementBase
{
    private IPlugin _plugin;

    protected abstract IPlugin CreatePlugin();

    public void Validate()
    {
        _plugin ??= CreatePlugin();
        _plugin.Validate();
    }
}

internal interface IPlugin
{
    void Validate();
}

internal class PluginManager1: PluginManagementBase
{
    protected override IPlugin CreatePlugin()
    {
        return new Plugin1();
    }
}

internal class Plugin1 : IPlugin
{
    public void Validate()
    {
        Console.WriteLine("Plugin 1.");
    }
}
internal class PluginManager2 : PluginManagementBase
{
    protected override IPlugin CreatePlugin()
    {
        return new Plugin2();
    }
}

internal class Plugin2 : IPlugin
{
    public void Validate()
    {
        Console.WriteLine("Plugin 1.");
    }
}