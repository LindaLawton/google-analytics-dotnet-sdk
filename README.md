![alt text](https://github.com/LindaLawton/google-analytics-dotnet-sdk/blob/master/images/analyticsicon.png "Google analytics .Net Tracker")

[![Build Status](https://travis-ci.org/LindaLawton/google-analytics-dotnet-sdk.svg?branch=master, "Build Status")](https://travis-ci.org/LindaLawton/google-analytics-dotnet-sdk)

[![NuGet](https://img.shields.io/nuget/dt/Daimto.Google.Analytics.Tracker.SDK.svg)](https://www.nuget.org/packages/Daimto.Google.Analytics.Tracker.SDK)

# Google Analytics SDK for .Net 

The Google Analytics SDK is designed makes it easy to connect .net Applications to Google Analytics.  

The Google Analytics SDK uses the Google Analytics [measurement protocol](https://developers.google.com/analytics/devguides/collection/protocol/) to record Hits via HTTP POST or GET requests directly to  Google Analytics. The Google Analytics SDK also supports the [debug](https://developers.google.com/analytics/devguides/collection/protocol/v1/validating-hits) endpoint which will allows developers to test and validate their hits before releasing their applicaitons to production.

The Google Analytics SDK supports tracking for the following interaction ([Hit](https://developers.google.com/analytics/devguides/collection/protocol/v1/parameters#t)) types: 
'pageview', 'screenview', 'event', 'transaction', 'item', 'social', 'exception', 'timing'.

## Example 

    // Create Web tracker
    var tracker = Tracker.BuildWebTracker("UA-9183475-1");
    // Create new Page view hit.
    var hit = new PageViewHit(tracker, "location", "hostname", "path", "title");
    
    // Build hit request.
    var request = (Hitrequest)tracker.CreateHitRequest(hit);
    
    // Debug hit request.
    var debugRequest = Task.Run(() => request.ExecuteDebugAsync());
    debugRequest.Wait();
    Console.Write(debugRequest.Result.RawResponse);
            
    // Execute hit request.        
    var collectRequest = Task.Run(() => request.ExecuteCollectAsync());
    collectRequest.Wait();
    Console.Write(collectRequest.Result.RawResponse);
	
Additional samples can be found in the Quick start project - [Tutorials](https://github.com/LindaLawton/google-analytics-dotnet-sdk/tree/master/tutorials)	
	
## Batching

I have not added support for [batching](https://developers.google.com/analytics/devguides/collection/protocol/v1/devguide#batch) yet.  If your interested in it please let me know.


# Alpah support for Ga4

This is an alpha brach which supports [Google Analytics Ga4 measurment protocol](https://developers.google.com/analytics/devguides/collection/protocol/ga4) it is very early days with Ga4, Expect to see changes in this often.  Basic example of how to set up the Ga4Tracker can be found in the host project.  I will update the read me when things stables.

Current support for 

-  [Events](https://developers.google.com/analytics/devguides/collection/protocol/ga4/sending-events?client_type=gtag#required_parameters)  as there is currently very little documentation on the paramaters which are valid for this protocol I have added all of the ones found in the [Event builder](https://ga-dev-tools.appspot.com/ga4-event-builder/)
	
	
## About this SDK
This Google Analytics SDK is not an offical Google SDK It was created by me to help the Google Analytics community as there is no active development on any other SDKs currently.   I intend to support .Net Standard, .net core, and .net classic application types to begin with.   I hope to support Xamarin and Universal windows Applications soon.   




### Contributing 
I accept contributions to code, samples, and docs. Please submit pull requests.
 

