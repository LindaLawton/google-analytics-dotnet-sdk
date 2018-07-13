using System;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core;

namespace QuickStart.ConsoleApp.Core
{
    class Program
    {
        private const string WebPropertyid = "UA-53766825-1";
        private const string Applicationname = "QuickStart core";
        private const string ApplicationVersion = "1.0";
        private const string ApplicationId = "1.0.0";

        public static async Task<int> Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var tracker = TrackerBuilder.BuildMobileTracker(WebPropertyid, Applicationname, ApplicationVersion, ApplicationId);


            if (await ScreenViewHitHelper.SendAsync(tracker, "home"))
            {
                Console.WriteLine("hitSent");
                return 0;
            }

            Console.WriteLine("Send Hit failed");
            return 1;
        }
    }
}
