using System;
using System.Threading;
using Hangfire;
using Microsoft.Owin.Hosting;

namespace HangInThere
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var webApp = WebApp.Start<Startup>("http://localhost:8888");

                RecurringJob.AddOrUpdate(() => Car.Wash(), Cron.Minutely);

                var jobId1 = BackgroundJob.Enqueue(() => Car.Run());

                var jobId2 = BackgroundJob.Schedule(() => Car.ChangeOil(), TimeSpan.FromSeconds(10));

                //var options = new BackgroundJobServerOptions
                //{
                //    ServerName = $"{Environment.MachineName}.{Guid.NewGuid()}"
                //};

                //using (var server = new BackgroundJobServer(options))
                //{
                //    Console.WriteLine("Hangfire Server started. Press any key to exit...");
                //    var counter = 0;
                //    while (true)
                //    {
                //        Console.WriteLine("Enqueuing...");

                //        var jobId1 = BackgroundJob.Enqueue(
                //            () => Car.Run(DateTime.Now.Ticks.ToString()));

                //        var jobId2 = BackgroundJob.Schedule(
                //            () => Car.ChangeOil(), TimeSpan.FromSeconds(3));


                //        counter++;
                //        if (counter >= 5)
                //        {
                //            break;
                //        }
                //    }
                //}

                Console.WriteLine("Server started... press ENTER to shut down");
                Console.ReadLine();

                webApp.Dispose();
            }
            catch (Exception)
            {
            }

        }
    }
}
