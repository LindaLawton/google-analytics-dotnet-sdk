using System.Collections.Generic;
using Google.Analytics.SDK.Core.Ga4.Request;

namespace Google.Analytics.SDK.Core.Ga4
{
    public static class Ga4EventBuilder
    {
        private static Ga4Event Init(string name)
        {
            return new Ga4Event()
            {
                Name = name
            };
        }

        private static Ga4Event AddEventParams(this Ga4Event ga4Event, Dictionary<string, string> param)
        {
            ga4Event.Params = param;

            return ga4Event;
        }

        public static Ga4Event EarnVirtualCurrency(string virtualCurrencyName, string value)
        {
            return Init("earn_virtual_currency").AddEventParams(new Dictionary<string, string>
            {
                {"virtual_currency_name", virtualCurrencyName},
                {"value", value}
            });
        }

        public static Ga4Event JoinGroup(string joinGroup)
        {
            return Init("join_group").AddEventParams(new Dictionary<string, string>
            {
                {"join_group", joinGroup}
            });
        }

        public static Ga4Event Login(string method)
        {
            return Init("login").AddEventParams(new Dictionary<string, string>
            {
                {"method", method},
            });
        }
        public static Ga4Event SignUp(string method)
        {
            return Init("sign_up").AddEventParams(new Dictionary<string, string>
            {
                {"method", method},
            });
        }
        
        public static Ga4Event PresentOffer(string itemId, string itemName, string itemCategory )
        {
            return Init("present_offer").AddEventParams(new Dictionary<string, string>
            {
                {"item_id", itemId},
                {"item_name", itemName},
                {"item_category", itemCategory},
            });
        }
        
        public static Ga4Event Purchase(string transactionsId, string value, string currency, string tax, string shipping, string items, string coupon, string affiliation )
        {
            return Init("purchase").AddEventParams(new Dictionary<string, string>
            {
                {"transactions_id", transactionsId},
                {"value", value},
                {"currency", currency},
                {"tax", tax},
                {"shipping", shipping},
                {"items", items},
                {"coupon", coupon},
                {"affiliation", affiliation},
            });
        }
        
        public static Ga4Event Refund(string transactionsId, string value, string currency, string tax, string shipping, Dictionary<string,string> items)
        {
            return Init("refund").AddEventParams(new Dictionary<string, string>
            {
                {"transactions_id", transactionsId},
                {"value", value},
                {"currency", currency},
                {"tax", tax},
                {"shipping", shipping},
                {"items", items.ToJsonString()}
            });
        }
        
        public static Ga4Event Search(string searchTerm)
        {
            return Init("search").AddEventParams(new Dictionary<string, string>
            {
                {"search_term", searchTerm}
            });
        }
        public static Ga4Event SelectContent(string contentType, string itemId)
        {
            return Init("select_content").AddEventParams(new Dictionary<string, string>
            {
                {"content_type", contentType},
                {"item_id", itemId}
            });
        }
        
        public static Ga4Event Share(string contentType, string itemId)
        {
            return Init("share").AddEventParams(new Dictionary<string, string>
            {
                {"content_type", contentType},
                {"item_id", itemId}
            });
        }
        
        public static Ga4Event SpendVirtualCurrency(string virtualCurrencyName, string value, string itemName)
        {
            return Init("spend_virtual_currency").AddEventParams(new Dictionary<string, string>
            {
                {"virtual_currency_name", virtualCurrencyName},
                {"value", value},
                {"item_name", itemName}
            });
        }
        
        public static Ga4Event TutorialBegin()
        {
            return Init("tutorial_begin");
        }
        public static Ga4Event TutorialComplete()
        {
            return Init("tutorial_complete");
        }
    }
}