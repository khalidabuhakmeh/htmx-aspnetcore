using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Lib.AspNetCore.ServerSentEvents;
using Microsoft.Extensions.Hosting;

namespace Exercises.Models
{
    public class ServerEventsWorker : IHostedService
    {
        private readonly IServerSentEventsService client;

        public ServerEventsWorker(IServerSentEventsService client)
        {
            this.client = client;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var clients = client.GetClients();
                    if (clients.Any())
                    {
                        Number.Value = RandomNumberGenerator.GetInt32(1, 100);
                        await client.SendEventAsync(
                            new ServerSentEvent
                            {
                                Id = "number",
                                Type = "number",
                                Data = new List<string>
                                {
                                    Number.Value.ToString()
                                }
                            },
                            cancellationToken
                        );
                    }

                    await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
                }
            }
            catch (TaskCanceledException)
            {
                // this exception is expected
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }

    public static class Number
    {
        public static int Value { get; set; } = 1;
    }
}