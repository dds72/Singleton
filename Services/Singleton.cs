using System;
using System.Collections.Concurrent;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Singleton.Models;
using Singleton.Services;

namespace Singleton
{
    public class Singleton
    {
        private readonly ConcurrentQueue<Job> queue = new ConcurrentQueue<Job>();
        private readonly IServiceProvider serviceProvider;

        private Timer timer;

        public Singleton(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Init()
        {
            timer = new Timer(Process, null, TimeSpan.FromSeconds(1), new TimeSpan(-1));
        }

        public void Enqueue(Job job)
        {
            this.queue.Enqueue(job);
        }

        private void Process(object state)
        {
            while(this.queue.TryDequeue(out var job))
            {
                Send(job);
            }
            timer.Change(TimeSpan.FromMilliseconds(100), new TimeSpan(-1));
        }

        private void Send(Job job)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<Transient>();
                var data = service.GetData();
            }
        }
    }
}