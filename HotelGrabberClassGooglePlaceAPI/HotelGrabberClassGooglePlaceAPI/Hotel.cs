using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGrabberClassGooglePlaceAPI
{
    class Hotel
    {
        public String Place_Id;
        public String Name;
        public String Address;
        public Location Location;
    }

    struct Location
    {
        public Double Latitude;
        public Double Longitude;
    }

}
