﻿using System.Text.Json;

namespace CoreLayer.Citrix.AppDelivery.Adc.NitroCommon
{
    public static class NitroSerializerOptions
    {
        public static JsonSerializerOptions JsonSerializerOptions =>
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = new NitroJsonNamingPolicy(),
                IgnoreNullValues = true,
            };
    }
}
