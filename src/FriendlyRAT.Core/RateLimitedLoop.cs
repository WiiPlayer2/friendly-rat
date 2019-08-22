using System;
using System.Collections.Generic;
using System.Text;

namespace FriendlyRAT.Core
{
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    public class RateLimitedLoop
    {
        private readonly TimeSpan timePerOperation;

        public RateLimitedLoop(int ops)
        {
            this.timePerOperation = TimeSpan.FromSeconds(1.0 / ops);
        }

        public Task Run(Func<Task> asyncAction) => Run(asyncAction, CancellationToken.None);

        public async Task Run(Func<Task> asyncAction, CancellationToken cancellationToken)
        {
            var stopwatch = new Stopwatch();
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                stopwatch.Restart();
                await asyncAction();
                stopwatch.Stop();

                if (stopwatch.Elapsed < this.timePerOperation)
                    await Task.Delay(this.timePerOperation - stopwatch.Elapsed, cancellationToken);
            }
        }
    }
}
