using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.ComponentModel.Design.Serialization;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace charp_cookbook.Application;

public class Program
{
    private int Count { get; set; } = 0;

    public Program()
    {
    }

    public static Task Main()
    {

        var cts = new CancellationTokenSource();
        cts.CancelAfter(10000)
        await ConcurrentProcess(cts.Token);
    }

    private static async Task ConcurrentProcess(CancellationToken token)
    {
        while (true)
        {
            token.ThrowIfCancellationRequested();
            Count++;
            Console.WriteLine(Count);
            await Task.Delay(1000);
        }
    }
}