using System.Collections.Generic;

namespace GMapsServices.Api.Models
{
    public class RouteDirectionDto
    {
        public string status { get; set; }

        public List<Geocoded_Waypoints> geocoded_waypoints { get; set; }

        public List<Route> routes { get; set; }
    }

    public class Geocoded_Waypoints
    {
        public string place_id { get; set; }        

        public string geocoder_status { get; set; }        

        public List<string> types { get; set; }
    }

    public class Route
    {
        public string summary { get; set; }

        public string copyrights { get; set; }

        public List<Leg> legs { get; set; }        

        public Bounds bounds { get; set; }            

        public Overview_Polyline overview_polyline { get; set; }    

        public List<object> warnings { get; set; }        

        public List<object> waypoint_order { get; set; }
    }

    public class Leg
    {
        public string end_address { get; set; }

        public string start_address { get; set; }

        public RouteDirectionDistance distance { get; set; }

        public Duration duration { get; set; }

        public List<Step> steps { get; set; }        

        public Location start_location { get; set; }        

        public Location end_location { get; set; }       

        public List<object> traffic_speed_entry { get; set; }        

        public List<object> via_waypoint { get; set; }
    }

    public class Step
    {
        public string travel_mode { get; set; }

        public string maneuver { get; set; }

        public string html_instructions { get; set; }

        public Location start_location { get; set; }

        public Location end_location { get; set; }        

        public StepDistance distance { get; set; }        

        public Duration duration { get; set; }             

        public Polyline polyline { get; set; }   
    }

    public class Overview_Polyline
    {        
        public string points { get; set; }
    }

    public class RouteDirectionDistance
    {        
        public string text { get; set; }        

        public int value { get; set; }
    }

    public class Duration
    {        
        public string text { get; set; }        

        public int value { get; set; }
    }

    public class StepDistance
    {        
        public string text { get; set; }        

        public int value { get; set; }
    }

    public class Polyline
    {        
        public string points { get; set; }
    }
}
