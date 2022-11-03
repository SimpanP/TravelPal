using System.Collections.Generic;
using TRAVELPAL.Enums;
using TRAVELPAL.Interface;

namespace TRAVELPAL.Classes {
    public class Travel {
        public List<Travel> travels = new();
        public List<IUser> users = new();
        public string Destination { get; set; }
        public Countries Country { get; set; }
        public int Travelers { get; set; }



        public Travel(string destination, Countries country, int travelers) {
            Destination = destination;
            Country = country;
            Travelers = travelers;
        }

        public virtual string GetInfo() {
            return $"Country || {Country}";
        }

        public virtual string GetTravelType() {
            return "TravelType";
        }

        public virtual string GetTravelInfo() {
            return "TravelType";
        }
    }
}