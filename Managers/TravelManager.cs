using System.Collections.Generic;
using TRAVELPAL.Classes;
using TRAVELPAL.Enums;

namespace TRAVELPAL.Managers {
    public class TravelManager {

        public List<Travel> travels = new();

        public Travel AddTravel(string destination, Countries countries, int travelers, TripTypes tripType) {
            return AddTravel(destination, countries, travelers, tripType);
        }

        public Travel CreateTrip(string destination, Countries countries, int travelers, TripTypes tripType) {
            Trip trip = new(travelers, destination, countries, tripType);
            travels.Add(trip);
            return trip;
        }

        public Travel CreateVacation(string destination, Countries countries, int travelers, bool allInclusive) {
            Vacation vacation = new(allInclusive, destination, countries, travelers);
            travels.Add(vacation);
            return vacation;
        }



        //TODO Remove travel method

    }



}
