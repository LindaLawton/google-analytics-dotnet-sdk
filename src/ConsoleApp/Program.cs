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
            var x = new PageViewHit("location");
            x.WebPropertyId = tracker.TrackingId;
            var xx = new PageViewHit("location","hostname");
            xx.WebPropertyId = tracker.TrackingId;
            var xxx = new PageViewHit("location", "hostname","path");
            xxx.WebPropertyId = tracker.TrackingId;
            var xxxx = new PageViewHit("location", "hostname", "path", "title");
            xxxx.WebPropertyId = tracker.TrackingId;

            var request = (Hitrequest)tracker.CreateHitRequest(xxxx);
            
           
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
