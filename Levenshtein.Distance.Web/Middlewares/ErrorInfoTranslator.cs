﻿using Levenshtein.Distance.Core;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Levenshtein.Distance.Web
{
    public class ErrorInfoTranslator : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var errorInfo = value as ErrorInfo;
            if (errorInfo == null)
            {
                writer.WriteNull();
                return;
            }

            writer.WriteStartObject();
            writer.WritePropertyName("code");
            writer.WriteValue(errorInfo.Code);

            writer.WritePropertyName("message");
            writer.WriteValue(errorInfo.Message);

            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var json = JToken.ReadFrom(reader) as JObject;
            if (json == null)
                return null;
            JToken value;
            string code = string.Empty, message = string.Empty;
            if (json.TryGetValue("code", out value) == true)
                code = value.ToString();
            if (json.TryGetValue("message", out value) == true)
                message = value.ToString();
            var errorInfo = new ErrorInfo(code, message);
            return errorInfo;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ErrorInfo) == objectType;
        }
    }
}