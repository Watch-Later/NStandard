﻿using Newtonsoft.Json;
using NStandard.Json.Converters;
using System;
using System.Text.Json;
using Xunit;
using NewtonsoftJson = Newtonsoft.Json.JsonConvert;
using SystemJson = System.Text.Json.JsonSerializer;

namespace NStandard.Json.Test
{
    public class DateOnlyTests
    {
        private readonly JsonSerializerOptions _options = Any.Create(() =>
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new DateOnlyConverter());
            return options;
        });
        private readonly JsonSerializerSettings _settings = new()
        {
            Converters = new JsonConverter[] { new Net.Converters.DateOnlyConverter() },
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

        private DateOnly Today = DateOnlyEx.Today;
        private DateOnly? NullableToday = null;

        [Fact]
        public void SerializeTest()
        {
            Assert_Serialize($"\"{Today:O}\"", Today);
            Assert_Serialize("null", NullableToday);
        }

        [Fact]
        public void DeserializeTest()
        {
            Assert_Deserialize(Today, $"\"{Today:O}\"");
            Assert_Deserialize(NullableToday, "null");
        }

    }
}
