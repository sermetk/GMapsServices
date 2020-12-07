using GMapsServices.BusinessEngine;
using GMapsServices.Common.Contracts;
using GMapsServices.Test.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.DataAnnotations;

namespace Test
{
    [TestClass]
    public class MapsBusinessEngineTests
    {
        private IServiceProvider services;
        private MapsBusinessEngine mapsBusinessEngine;
        [TestInitialize]
        public void Init()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMock<IExternalHttpRequestBusinessEngine>(true);
            serviceCollection.AddSingleton<MapsBusinessEngine>();
            services = serviceCollection.BuildServiceProvider();
            mapsBusinessEngine = services.GetService<MapsBusinessEngine>();
        }
        [TestMethod]
        public void GetAutoComplete()
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                mapsBusinessEngine.GetAutoCompleteAsync("41.0055005,28.7319901", null);
            });
            Assert.ThrowsException<ValidationException>(() =>
            {
                mapsBusinessEngine.GetAutoCompleteAsync(null, "house");
            });
            Assert.IsNotNull(mapsBusinessEngine.GetAutoCompleteAsync("41.0055005,28.7319901", "house"));
        }
        [TestMethod]
        public void GetPlaceDetail()
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                mapsBusinessEngine.GetPlaceDetailAsync(null);
            });
            Assert.IsNotNull(mapsBusinessEngine.GetPlaceDetailAsync("ChIJyWEHuEmuEmsRm9hTkapTCrk"));
        }
        [TestMethod]
        public void GetReverseGeocode()
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                mapsBusinessEngine.GetReverseGeocodeAsync(null);
            });
            Assert.IsNotNull(mapsBusinessEngine.GetReverseGeocodeAsync("41.0055005,28.7319901"));
        }
        [TestMethod]
        public void GetRoute()
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                mapsBusinessEngine.GetRouteAsync("41.0055005,28.7319901", null);
            });
            Assert.ThrowsException<ValidationException>(() =>
            {
                mapsBusinessEngine.GetRouteAsync(null, "house");
            });
            Assert.IsNotNull(mapsBusinessEngine.GetRouteAsync("41.0055005,28.7319901", "36.9976069,35.1479813"));
        }
    }
}
