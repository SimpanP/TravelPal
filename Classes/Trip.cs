using System.Collections.Generic;
using TRAVELPAL.Enums;

namespace TRAVELPAL.Classes {
    public class Trip : Travel {
        public List<Travel> travels = new();
        public TripTypes TripType { get; set; }

        public Trip(int travelers, string destination, Countries country, TripTypes tripType) : base(destination,
            country, travelers) {
            TripType = tripType; //TODO check if this is right
        }

        public override string GetInfo() {
            return $"Country || {base.Country}";
        }

        public override string GetTravelType() {
            return "Trip";
        }

        public override string GetTravelInfo() {
            return $"{TripType}";
        }
    }
}