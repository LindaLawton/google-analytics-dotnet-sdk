using System;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core;
using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Services.Interfaces;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var tracker = Tracker.BuildWebTracker("UA-59183475-1");
            var x = new PageViewHit(tracker, "location");
            var xx = new PageViewHit(tracker, "location","hostname");
            var xxx = new PageViewHit(tracker, "hostname","path");


            var hit = new PageViewHit(tracker, "location", "hostname", "path", "title");
            var request = (Hitrequest)tracker.CreateHitRequest(hit);
           
            var debugRequest = Task.Run(() => request.ExecuteDebugAsync());
            debugRequest.Wait();
            Console.Write(debugRequest.Result.RawResponse);
            
            var collectRequest = Task.Run(() => request.ExecuteCollectAsync());
            collectRequest.Wait();
            Console.Write(collectRequest.Result.RawResponse);




            Console.WriteLine("Hello World!");
        }
    }
}
