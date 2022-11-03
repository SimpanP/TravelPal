using TRAVELPAL.Enums;

namespace TRAVELPAL.Classes {
    public class Vacation : Travel {
        public bool AllInclusive { get; set; }


        public Vacation(bool allInclusive, string destination, Countries country, int travelers) : base(destination,
            country, travelers) {
            AllInclusive = allInclusive;
        }

        public override string GetInfo() {
            return $"Country || {Country}";
        }

        public override string GetTravelType() {
            return "Vacation";
        }

        public override string GetTravelInfo() {
            if (AllInclusive) {
                return "All Inclusive";
            } else {
                return "Not all inclusive";
            }
        }
    }
}