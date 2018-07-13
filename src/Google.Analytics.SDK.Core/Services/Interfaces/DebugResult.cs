// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Google.Analytics.SDK.Core.Services.Interfaces
{
    public class DebugResult : IResult
    {
        public string RawResponse { get; }
        public DebugResponse Response { get; }

        public DebugResult(string result)
        {
            RawResponse = result;
            Response = JsonConvert.DeserializeObject<DebugResponse>(result);
        }

        public bool IsValid()
        {
            return Response?.hitParsingResult?.FirstOrDefault() != null && Response.hitParsingResult.FirstOrDefault().valid;
        }
    }


    public class DebugResponse
    {
        public class HitParsingResult
        {
            public bool valid { get; set; }
            public List<object> parserMessage { get; set; }
            public string hit { get; set; }
        }

        public class ParserMessage
        {
            public string messageType { get; set; }
            public string description { get; set; }
        }


        public List<HitParsingResult> hitParsingResult { get; set; }
        public List<ParserMessage> parserMessage { get; set; }
    }


}