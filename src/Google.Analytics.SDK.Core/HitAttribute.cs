// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;

namespace Google.Analytics.SDK.Core
{
    [AttributeUsage(AttributeTargets.Property)]
    public class HitAttribute : Attribute
    {
        public string Parm { get; set; }
        public bool Required { get; set; }
    }
}