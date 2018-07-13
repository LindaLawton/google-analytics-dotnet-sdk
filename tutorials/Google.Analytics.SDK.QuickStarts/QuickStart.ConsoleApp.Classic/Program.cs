using Google.Analytics.SDK.Core;
using QuickStart.ConsoleApp.Classic.HitHelpers;
using System;
using System.Threading.Tasks;

namespace QuickStart.ConsoleApp.Classic
{
    class Program
    {
        private const string DemoDataApplicationWebProplerty = "UA-53766825-1";
        private const string Applicationname = "QuickStart core";
        private const string ApplicationVersion = "1.0";
        private const string ApplicationId = "1.0.0";

        public static async Task<int> Main(string[] args)
        {
            var start = DateTime.Now;
            Console.WriteLine("Hello Google Analatics SDK!");
            var tracker = TrackerBuilder.BuildMobileTracker(DemoDataApplicationWebProplerty, Applicationname, ApplicationVersion, ApplicationId);

            if (!await ScreenViewHitHelper.SendAsync(tracker, "QuickStartMain"))
            {
                Console.WriteLine("Send Screen View Failed");
                return 0;
            }

            if (!await EventHitHelper.SendAsync(tracker, Applicationname, "Start", "Main"))
            {
                Console.WriteLine("Send Event Hit Failed");
                return 0;
            }

            if (!await ExceptionHitHelper.SendAsync(tracker, "Something Failed", true))
            {
                Console.WriteLine("Send exception Hit Failed");
                return 0;
            }

            if (!await SocialHitHelper.SendAsync(tracker, "Facebook", "like", "https://www.nuget.org/packages/Daimto.Google.Analytics.Tracker.SDK/"))
            {
                Console.WriteLine("Send social Hit Failed");
                return 0;
            }

            var diff = DateTime.Now.Subtract(start).Milliseconds;
            if (!await TimingHitHelper.SendAsync(tracker, "TestSend", "lookup", diff))
            {
                Console.WriteLine("Send social Hit Failed");
                return 0;
            }

            Console.WriteLine("Hits Sent");
            return 1;
        }
    }
}
