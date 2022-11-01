using System.Collections.Generic;
using TRAVELPAL.Classes;
using TRAVELPAL.Enums;

namespace TRAVELPAL.Managers {
    public class TravelManager {

        //TODO Add travel

        public List<Travel> Travels = new();

        public Travel AddTravel(string destination, Countries countries, int travelers, TripTypes tripType) {
            return AddTravel(destination, countries, travelers, tripType);
        }

        public Travel CreateTrip(string destination, Countries countries, int travelers, TripTypes tripType) {
            Trip trip = new(travelers, destination, countries, tripType);
            Travels.Add(trip);
            return trip;
        }

        public Travel CreateVacation(string destination, Countries countries, int travelers, bool allInclusive) {
            Vacation vacation = new(allInclusive, destination, countries, travelers);
            Travels.Add(vacation);
            return vacation;
        }



        //TODO Remove travel method

    }



}
