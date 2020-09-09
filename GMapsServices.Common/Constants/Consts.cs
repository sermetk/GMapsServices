using System;
using System.Collections.Generic;
using System.Text;

namespace GMapsServices.Common.Constants
{
    public class Consts
    {
        #region Google Maps
        public const string GMAPS_BASE_URL = "https://maps.googleapis.com";
        public const string GMAPS_API_KEY = "yourapikey";
        public const string AUTOCOMPLETE_END_POINT = "/maps/api/place/autocomplete/json";
        public const string PLACE_DETAIL_END_POINT = "/maps/api/place/details/json";
        public const string ROUTE_DIRECTION_END_POINT = "/maps/api/directions/json";
        public const string REVERSE_GEOCODE_END_POINT = "/maps/api/geocode/json";
        #endregion
    }
}
