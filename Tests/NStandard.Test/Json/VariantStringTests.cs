﻿using Newtonsoft.Json;
using NStandard.Json.Converters;
using System;
using System.Text.Json;
using Xunit;
using NewtonsoftJson = Newtonsoft.Json.JsonConvert;
using SystemJson = System.Text.Json.JsonSerializer;

namespace NStandard.Json.Test
{
    public class VariantStringTests
    {
        private readonly JsonSerializerOptions _options = Any.Create(() =>
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new VariantStringConverter());
            return options;
        });
        private readonly JsonSerializerSettings _settings = new()
        {
            Converters = new JsonConverter[] { new Net.Converters.VariantStringConverter() },
        };

        private void Assert_Serialize<T>(string expected, T actual)
        {
            Assert.Equal(expected, SystemJson.Serialize(actual, _options));
            Assert.Equal(expected, NewtonsoftJson.SerializeObject(actual, _settings));
        }
        private void Assert_Deserialize<T>(T expected, string actual)
        {
            Assert.Equal(expected, SystemJson.Deserialize<T>(actual, _options));
            Assert.Equal(expected, NewtonsoftJson.DeserializeObject<T>(actual, _settings));
        }

        [Fact]
        public void SerializeTest()
        {
            Assert_Serialize("\"\"", new VariantString(null as string));
            Assert_Serialize("\"\"", new VariantString(""));
            Assert_Serialize("\"123\"", new VariantString("123"));
            Assert_Serialize("\"123.456\"", new VariantString("123.456"));
            Assert_Serialize($"\"{new DateTime(2000, 1, 2, 0, 10, 20)}\"", new VariantString(new DateTime(2000, 1, 2, 0, 10, 20)));
        }

        [Fact]
        public void DeserializeTest()
        {
            Assert_Deserialize(new VariantString(""), "\"\"");
            Assert_Deserialize(new VariantString("123"), "\"123\"");
            Assert_Deserialize(new VariantString("123.456"), "\"123.456\"");
            Assert_Deserialize(new VariantString(new DateTime(2000, 1, 2, 0, 10, 20)), $"\"{new DateTime(2000, 1, 2, 0, 10, 20)}\"");
        }

    }
}
