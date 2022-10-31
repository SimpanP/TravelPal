using TRAVELPAL.Enums;

namespace TRAVELPAL.Classes
{
    public class Trip : Travel
    {
        public TripTypes TripType { get; set; }

        public Trip(TripTypes tripType, string destination, Countries country, int travelers) : base(destination,
            country, travelers)
        {
            TripType = tripType;
        }


        public string GetInfo()
        {
            return base.GetInfo();
        }
    }
}