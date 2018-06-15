// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Services.Interfaces;

namespace Google.Analytics.SDK.Core.Hits
{
    public abstract class HitBase: IHit
    {
        #region  General
        /// <summary>
        /// The Protocol version. The current value is '1'. This will only change when there are changes made that are not backwards compatible.
        /// </summary>
        [Hit(Parm = "v", Required = true)]
        public string ProtocolVersion => "1";
        /// <summary>
        /// The tracking ID / web property ID. The format is UA-XXXX-Y. All collected data is associated by this ID.
        /// </summary>
        [Hit(Parm = "tid", Required = true)]
        public string WebPropertyId { get; set; }

        /// <summary>
        /// When present, the IP address of the sender will be anonymized. For example, the IP will be anonymized if any of the following parameters are present in the payload: &aip=, &aip=0, or &aip=1
        /// </summary>
        [Hit(Parm = "tid", Required = false)]
        public string AnonymizeIp { get; set; }

        /// <summary>
        /// When present, the IP address of the sender will be anonymized. For example, the IP will be anonymized if any of the following parameters are present in the payload: &aip=, &aip=0, or &aip=1
        /// </summary>
        [Hit(Parm = "ds", Required = false)]
        public string DataSource { get; set; } = "app";


        /// <summary>
        /// Used to collect offline / latent hits. The value represents the time delta (in milliseconds) between when the hit being reported occurred and the time the hit was sent. The value must be greater than or equal to 0. Values greater than four hours may lead to hits not being processed.
        /// </summary>
        [Hit(Parm = "qt", Required = false)]
        public int QueueTime { get; set; }

        /// <summary>
        /// Used to send a random number in GET requests to ensure browsers and proxies don't cache hits. It should be sent as the final parameter of the request since we've seen some 3rd party internet filtering software add additional parameters to HTTP requests incorrectly. This value is not used in reporting.
        /// </summary>
        [Hit(Parm = "z", Required = false)]
        public string CacheBuster { get; set; }

        #endregion

        #region User

        /// <summary>
        /// This field is required if User ID (uid) is not specified in the request. This anonymously identifies a particular user, device, or browser instance. For the web, this is generally stored as a first-party cookie with a two-year expiration. For mobile apps, this is randomly generated for each particular instance of an application install. The value of this field should be a random UUID (version 4) as described in http://www.ietf.org/rfc/rfc4122.txt.
        /// </summary>
        [Hit(Parm = "cid", Required = true)]
        public string ClientId { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// This field is required if Client ID (cid) is not specified in the request. This is intended to be a known identifier for a user provided by the site owner/tracking library user. It must not itself be PII (personally identifiable information). The value should never be persisted in GA cookies or other Analytics provided storage.
        /// </summary>
        [Hit(Parm = "uid", Required = true)]
        public string UserId { get; set; }

        #endregion

        #region session
        /// <summary>
        /// Used to control the session duration. A value of 'start' forces a new session to start with this hit and 'end' forces the current session to end with this hit. All other values are ignored.
        /// </summary>
        [Hit(Parm = "sc", Required = true)]
        public string SessionControl { get; set; }

        /// <summary>
        /// The IP address of the user. This should be a valid IP address in IPv4 or IPv6 format. It will always be anonymized just as though &aip (anonymize IP) had been used.
        /// </summary>
        [Hit(Parm = "uip", Required = true)]
        public string IpOverride { get; set; }

        /// <summary>
        /// The User Agent of the browser. Note that Google has libraries to identify real user agents. Hand crafting your own agent could break at any time.
        /// </summary>
        [Hit(Parm = "ua", Required = true)]
        public string UserAgentOverride { get; set; }

        /// <summary>
        /// The geographical location of the user. The geographical ID should be a two letter country code or a criteria ID representing a city or region (see http://developers.google.com/analytics/devguides/collection/protocol/v1/geoid). This parameter takes precedent over any location derived from IP address, including the IP Override parameter. An invalid code will result in geographical dimensions to be set to '(not set)'.
        /// </summary>
        [Hit(Parm = "geoid", Required = true)]
        public string GeographicalOverride { get; set; }

        #endregion

        #region Traffic Sources

        /// <summary>
        /// Specifies which referral source brought traffic to a website. This value is also used to compute the traffic source. The format of this value is a URL.
        /// </summary>
        [Hit(Parm = "dr", Required = true)]
        public string DocumentReferrer { get; set; }

        /// <summary>
        /// Specifies the campaign name.
        /// </summary>
        [Hit(Parm = "cn", Required = true)]
        public string CampaignName { get; set; }

        /// <summary>
        /// Specifies the campaign source.
        /// </summary>
        [Hit(Parm = "cs", Required = true)]
        public string CampaignSource { get; set; }
        /// <summary>
        /// Specifies the campaign Medium.
        /// </summary>
        [Hit(Parm = "cm", Required = false)]
        public string CampaignMedium { get; set; }
        /// <summary>
        /// Specifies the campaign Keyword.
        /// </summary>
        [Hit(Parm = "ck", Required = false)]
        public string CampaignKeyword { get; set; }
        /// <summary>
        /// Specifies the campaign content.
        /// </summary>
        [Hit(Parm = "cc", Required = false)]
        public string CampaignContent { get; set; }
        /// <summary>
        /// Specifies the campaign Id.
        /// </summary>
        [Hit(Parm = "ci", Required = false)]
        public string CampaignID { get; set; }

        /// <summary>
        /// Specifies the Google AdWords Id.
        /// </summary>
        [Hit(Parm = "gclid", Required = false)]
        public string GoogleAdWordsID { get; set; }

        /// <summary>
        /// Specifies the Google Display Ads Id.
        /// </summary>
        [Hit(Parm = "dclid", Required = false)]
        public string GoogleDisplayAdsID { get; set; }

        #endregion

        #region System Info

        /// <summary>
        /// Specifies the screen resolution.
        /// </summary>
        [Hit(Parm = "sr", Required = false)]
        public string ScreenResolution { get; set; }

        /// <summary>
        /// Specifies the viewable area of the browser / device.
        /// </summary>
        [Hit(Parm = "vp", Required = false)]
        public string ViewportSize { get; set; }

        /// <summary>
        /// Specifies the character set used to encode the page / document.
        /// </summary>
        [Hit(Parm = "de", Required = false)]
        public string DocumentEncoding { get; set; }

        /// <summary>
        /// Specifies the screen color depth.
        /// </summary>
        [Hit(Parm = "sd", Required = false)]
        public string ScreenColors { get; set; }


        /// <summary>
        ///Specifies the language.
        /// </summary>
        [Hit(Parm = "ul", Required = false)]
        public string UserLanguage { get; set; }

        /// <summary>
        /// Specifies whether Java was enabled.
        /// </summary>
        [Hit(Parm = "je", Required = false)]
        public string JavaEnabled { get; set; }

        /// <summary>
        /// Specifies the flash version.
        /// </summary>
        [Hit(Parm = "fl", Required = false)]
        public string FlashVersion { get; set; }

        #endregion

        #region  hit

        /// <summary>
        /// The type of hit. Must be one of 'pageview', 'screenview', 'event', 'transaction', 'item', 'social', 'exception', 'timing'.
        /// </summary>
        [Hit(Parm = "t", Required = true)]
        public string HitType { get; set; }

        /// <summary>
        /// Specifies that a hit be considered non-interactive.
        /// </summary>
        [Hit(Parm = "ni", Required = false)]
        public bool NonInteractionHit { get; set; }

        #endregion

        #region Content Information

        /// <summary>
        /// Use this parameter to send the full URL (document location) of the page on which content resides. You can use the &dh and &dp parameters to override the hostname and path + query portions of the document location, accordingly. The JavaScript clients determine this parameter using the concatenation of the document.location.origin + document.location.pathname + document.location.search browser parameters.Be sure to remove any user authentication or other private information from the URL if present.For 'pageview' hits, either &dl or both &dh and &dp have to be specified for the hit to be valid.
        /// </summary>
        [Hit(Parm = "dl", Required = false)]
        public string DocumentLocationURL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Hit(Parm = "dh", Required = false)]
        public string DocumentHostName { get; set; }

        /// <summary>
        /// The path portion of the page URL. Should begin with '/'. For 'pageview' hits, either &dl or both &dh and &dp have to be specified for the hit to be valid.
        /// </summary>
        [Hit(Parm = "dp", Required = false)]
        public string DocumentPath { get; set; }

        /// <summary>
        /// The title of the page / document.
        /// </summary>
        [Hit(Parm = "dt", Required = false)]
        public string DocumentTitle { get; set; }

        /// <summary>
        /// This parameter is optional on web properties, and required on mobile properties for screenview hits, where it is used for the 'Screen Name' of the screenview hit. On web properties this will default to the unique URL of the page by either using the &dl parameter as-is or assembling it from &dh and &dp.
        /// </summary>
        [Hit(Parm = "cd", Required = false)]
        public string ScreenName { get; set; }

        /// <summary>
        /// You can have up to 5 content groupings, each of which has an associated index between 1 and 5, inclusive. Each content grouping can have up to 100 content groups. The value of a content group is hierarchical text delimited by '/". All leading and trailing slashes will be removed and any repeated slashes will be reduced to a single slash. For example, '/a//b/' will be converted to 'a/b'.
        /// </summary>
        [Hit(Parm = "cg<groupIndex>", Required = false)]
        public Dictionary<int, string> ContentGroup { get; set; }

        /// <summary>
        /// The ID of a clicked DOM element, used to disambiguate multiple links to the same URL in In-Page Analytics reports when Enhanced Link Attribution is enabled for the property.
        /// </summary>
        [Hit(Parm = "linkid", Required = false)]
        public string LinkID { get; set; }

        #endregion

        #region App tracking

        /// <summary>
        /// Specifies the application name. This field is required for any hit that has app related data (i.e., app version, app ID, or app installer ID). For hits sent to web properties, this field is optional.
        /// </summary>
        [Hit(Parm = "an", Required = false)]
        public string ApplicationName { get; set; }

        /// <summary>
        /// Application identifier.
        /// </summary>
        [Hit(Parm = "aid", Required = false)]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Specifies the application version.
        /// </summary>
        [Hit(Parm = "av", Required = false)]
        public string ApplicationVersion { get; set; }

        /// <summary>
        /// Application installer identifier.
        /// </summary>
        [Hit(Parm = "aiid", Required = false)]
        public string ApplicationInstallerId { get; set; }


        #endregion

        #region events
        
        /// <summary>
        /// Required for event hit type. Specifies the event category.Must not be empty.
        /// </summary>
        [Hit(Parm = "ec", Required = false)]
        public string EventCategory { get; set; }

        /// <summary>
        /// Required for event hit type. Specifies the event action. Must not be empty.
        /// </summary>
        [Hit(Parm = "ea", Required = false)]
        public string EventAction { get; set; }
       

        /// <summary>
        /// Optional. Specifies the event label.
        /// </summary>
        [Hit(Parm = "el", Required = false)]
        public string EventLabel { get; set; }

        /// <summary>
        /// Specifies the event value. Values must be non-negative.
        /// </summary>
        [Hit(Parm = "ev", Required = false)]
        public string EventValue { get; set; }

        #endregion

        #region E-Commerce

        /// <summary>
        /// Required for transaction hit type. 
        /// Required for item hit type.
        /// A unique identifier for the transaction.This value should be the same for both the Transaction hit and Items hits associated to the particular transaction.
        /// </summary>
        [Hit(Parm = "ti", Required = false)]
        public string TransactionId { get; set; }

        /// <summary>
        /// Specifies the affiliation or store name.
        /// </summary>
        [Hit(Parm = "ta", Required = false)]
        public string TransactionAffiliation { get; set; }

        /// <summary>
        /// Specifies the total revenue associated with the transaction. This value should include any shipping or tax costs.
        /// </summary>
        [Hit(Parm = "tr", Required = false)]
        public string TransactionRevenue { get; set; }

        /// <summary>
        /// Specifies the total shipping cost of the transaction.
        /// </summary>
        [Hit(Parm = "ts", Required = false)]
        public string TransactionShipping { get; set; }

        /// <summary>
        /// Specifies the total tax of the transaction.
        /// </summary>
        [Hit(Parm = "tt", Required = false)]
        public string TransactionTax { get; set; }

        /// <summary>
        /// Required for item hit type.
        /// Specifies the item name.
        /// </summary>
        [Hit(Parm = "in", Required = false)]
        public string ItemName { get; set; }


        /// <summary>
        /// Specifies the price for a single item / unit.
        /// </summary>
        [Hit(Parm = "ip", Required = false)]
        public string ItemPrice { get; set; }

        /// <summary>
        /// Specifies the number of items purchased.
        /// </summary>
        [Hit(Parm = "iq", Required = false)]
        public string ItemQuantity { get; set; }

        /// <summary>
        /// Specifies the SKU or item code.
        /// </summary>
        [Hit(Parm = "ic", Required = false)]
        public string ItemCode { get; set; }

        /// <summary>
        /// Specifies the category that the item belongs to.
        /// </summary>
        [Hit(Parm = "iv", Required = false)]
        public string ItemCategory { get; set; }

        #endregion


        public bool IsValid { get; set; }

        public bool Validate()
        {
            IsValid = false;

            //always
            if (string.IsNullOrWhiteSpace(ClientId))
                return false;


            return InternaValidate();
        }

        protected virtual bool InternaValidate()
        {
            IsValid = true;
            return IsValid;
        }


        public string GetRequest()
        {
            var sb = new StringBuilder();

            var properties = typeof(HitBase).GetProperties();
            foreach (var property in properties)
            {
                var name = property.Name;
                var value = property.GetValue(this);

                if (value == null) continue;
                sb.Append(this.BuildPropertyString(name));
                sb.Append("&");
            }

            return sb.ToString().Substring(0, sb.Length - 1);
        }

    }
}