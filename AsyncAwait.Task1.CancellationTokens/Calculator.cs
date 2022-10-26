using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait.Task1.CancellationTokens;

internal static class Calculator
{
    // todo: change this method to support cancellation token
    public static async Task<long> CalculateAsync(int n, CancellationToken token)
    {
        return await Task.Run(async () =>
        {
            long sum = 0;
            for (var i = 0; i < n; i++)
            {
                if (token.IsCancellationRequested)
                {
                    return -1;
                }
                // i + 1 is to allow 2147483647 (Max(Int32)) 
                sum += (i + 1);
                await Task.Delay(10);
            }
            return sum;
        }, token);
    }
}
