using System;
using System.Collections.Generic;
using Deserializer.Converters;
using Deserializer.Interfaces;
using Deserializer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace UnitTests
{
    [TestClass]
    public class DeserializerTests
    {
        public string MovieJson { get; set; }
        public string TvShowJson { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            MovieJson = @"{
                'Id': '1',
                'Name': 'Recent Movies',
                'Group': 'Action Movies',
                'ResultData': [{
                    'Id': '1',
                    'Name': 'Godzilla',
                    'Studio': 'Warner',
                    'Screenings': 'Tues,Sun'
                }, {
                    'Id': '2',
                    'Name': 'Source Code',
                    'Studio': 'Warner',
                    'Screenings': 'Mon,Sun'
                }]
            }";

            TvShowJson = @"{
                'Id': '2',
                'Name': 'Recent TV Shows',
                'Group': 'Drama',
                'ResultData': [{
                    'Id': '1',
                    'Name': 'Orange is the new black',
                    'Network': 'Netflix',
                    'Series': '6',
                    'Episodes': '66'
                }, {
                    'Id': '2',
                    'Name': 'Breaking Bad',
                    'Network': 'Netflix',
                    'Series': '2',
                    'Episodes': '36'
                }]
            }";
        }

        [TestMethod]
        public void DeseralizeAnonymousTypeToIResultData()
        {
            try
            {
                JsonConvert.DeserializeObject<ResultWrapper>(MovieJson);
            }
            catch (JsonSerializationException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(JsonSerializationException));
                Assert.AreEqual(ex.Message, "Could not create an instance of type Deserializer.Interfaces.IResultData. Type is an interface or abstract class and cannot be instantiated. Path 'ResultData[0].Id', line 6, position 26.");
            }

            try
            {
                JsonConvert.DeserializeObject<ResultWrapper>(TvShowJson);
            }
            catch (JsonSerializationException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(JsonSerializationException));
                Assert.AreEqual(ex.Message, "Could not create an instance of type Deserializer.Interfaces.IResultData. Type is an interface or abstract class and cannot be instantiated. Path 'ResultData[0].Id', line 6, position 26.");
            }
        }

        [TestMethod]
        public void DeserializeJsonIResultDataToMovieResultData()
        {
            var converter = new ResultDataConverter(typeof (MovieResultData));

            var deseralizeSettings = new JsonSerializerSettings();
            deseralizeSettings.Converters.Add(converter);

            var results = JsonConvert.DeserializeObject<ResultWrapper>(MovieJson, deseralizeSettings);

            Assert.AreEqual(results.ResultData.Count, 2);

            Assert.IsInstanceOfType(results.ResultData[0], typeof(IResultData));
            Assert.IsInstanceOfType(results.ResultData[1], typeof(IResultData));

            Assert.IsInstanceOfType(results.ResultData[0], typeof(MovieResultData));
            Assert.IsInstanceOfType(results.ResultData[1], typeof(MovieResultData));

            Assert.IsNotInstanceOfType(results.ResultData[0], typeof(TvShowResultData));
            Assert.IsNotInstanceOfType(results.ResultData[1], typeof(TvShowResultData));
        }


        [TestMethod]
        public void DeserializeJsonIResultDataToTvShowResultData()
        {
            var converter = new ResultDataConverter(typeof(TvShowResultData));

            var deseralizeSettings = new JsonSerializerSettings();
            deseralizeSettings.Converters.Add(converter);

            var results = JsonConvert.DeserializeObject<ResultWrapper>(TvShowJson, deseralizeSettings);

            Assert.AreEqual(results.ResultData.Count, 2);

            Assert.IsInstanceOfType(results.ResultData[0], typeof(IResultData));
            Assert.IsInstanceOfType(results.ResultData[1], typeof(IResultData));

            Assert.IsInstanceOfType(results.ResultData[0], typeof(TvShowResultData));
            Assert.IsInstanceOfType(results.ResultData[1], typeof(TvShowResultData));

            Assert.IsNotInstanceOfType(results.ResultData[0], typeof(MovieResultData));
            Assert.IsNotInstanceOfType(results.ResultData[1], typeof(MovieResultData));
        }
    }
}
