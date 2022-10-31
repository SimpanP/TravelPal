﻿using TRAVELPAL.Enums;

namespace TRAVELPAL.Classes
{
    public class Travel
    {
        public string Destination { get; set; }
        public Countries Country { get; set; }
        public int Travelers { get; set; }


        public Travel(string destination, Countries country, int travelers)
        {
            Destination = destination;
            Country = country;
            Travelers = travelers;
        }

        public virtual string GetInfo()
        {
            return $"{Destination} || {Country}";
        }
    }
}