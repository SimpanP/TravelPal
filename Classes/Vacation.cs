using TRAVELPAL.Enums;

namespace TRAVELPAL.Classes
{
    public class Vacation : Travel
    {
        public bool AllInclusive { get; set; }


        public Vacation(bool allInclusive, string destination, Countries country, int travelers) : base(destination,
            country, travelers)
        {
            AllInclusive = allInclusive;
        }


        public string GetInfo()
        {
            return base.GetInfo();
        }
    }
}