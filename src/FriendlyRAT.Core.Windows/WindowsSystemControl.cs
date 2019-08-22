﻿using System;
using System.Drawing;

namespace FriendlyRAT.Core.Windows
{
    using System.Threading;
    using System.Threading.Tasks;

    public class WindowsSystemControl : ISystemControl
    {
        public event EventHandler<RenderRegion> RenderRegionReceived = (sender, region) => { };

        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        private readonly RateLimitedLoop loop = new RateLimitedLoop(25);

        private int initialized = 0;

        private Rectangle renderRegion = new Rectangle(0, 0, 128, 128);

        public void Dispose()
        {
            this.cancellationTokenSource.Cancel();
            this.cancellationTokenSource.Dispose();
        }

        public void Init()
        {
            if (Interlocked.CompareExchange(ref this.initialized, 1, 0) == 1)
            {
                throw new NotSupportedException();
            }

            Task.Run(this.Run);
        }

        private async Task Run()
        {
            await Task.WhenAll(this.loop.Run(RenderLoopAsync, this.cancellationTokenSource.Token));
        }

        private Task RenderLoopAsync()
        {
            var region = this.renderRegion;
            var bitmap = RegionCapture.Capture(region);
            RenderRegionReceived(this, new RenderRegion(region, bitmap));
            return Task.CompletedTask;
        }

        public void SetRegion(Rectangle region) => this.renderRegion = region;
    }
}
