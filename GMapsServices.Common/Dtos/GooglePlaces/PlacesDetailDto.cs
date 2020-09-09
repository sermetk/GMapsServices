﻿using System.Collections.Generic;

namespace GMapsServices.Common.Dtos.GooglePlaces
{
    public class PlacesDetailDto
    {
        public string status { get; set; }
        public Result result { get; set; }
        public List<object> html_attributions { get; set; }
    }
    public class Result
    {
        public string formatted_address { get; set; }
        public string place_id { get; set; }
        public string url { get; set; }
        public int utc_offset { get; set; }
        public string vicinity { get; set; }
        public string adr_address { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string reference { get; set; }
        public string scope { get; set; }
        public List<string> types { get; set; }
        public Geometry geometry { get; set; }
        public List<Address_Components> address_components { get; set; }        
        public List<Photo> photos { get; set; }     
    }
    public class Geometry
    {
        public Location location { get; set; }        
        public Viewport viewport { get; set; }
    }
    public class Viewport
    {        
        public Northeast northeast { get; set; }        
        public Southwest southwest { get; set; }
    }
    public class Northeast
    {        
        public float lat { get; set; }        
        public float lng { get; set; }
    }
    public class Southwest
    {        
        public float lat { get; set; }        
        public float lng { get; set; }
    }
    public class Address_Components
    {
        public string long_name { get; set; }        
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }
    public class Photo
    {
        public string photo_reference { get; set; }
        public int height { get; set; }     
        public int width { get; set; }
        public List<string> html_attributions { get; set; }
    }
}
