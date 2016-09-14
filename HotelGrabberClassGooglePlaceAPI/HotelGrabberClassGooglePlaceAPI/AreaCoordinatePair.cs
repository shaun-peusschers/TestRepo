using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGrabberClassGooglePlaceAPI
{
    class AreaCoordinatePair
    {
       public   String areaName;
       public Location areaCordinate;

        public AreaCoordinatePair(String areaName, Double Lat, Double Lng)
        {
            this.areaName = areaName;
            this.areaCordinate.Latitude = Lat;
            this.areaCordinate.Longitude  = Lng;
        }
        public string toString()
        {
            return areaName;
        }

    }
}
