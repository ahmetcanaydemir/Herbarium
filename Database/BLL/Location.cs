using System;
using System.Text.RegularExpressions;

namespace Herbarium.Class.BLL
{
    class Location
    {
        public enum Mode
        {
            Decimal,
            Degree
        }
        enum CoordType
        {
            Latitude=1,
            Longitude=5
        }
        const string REGEX = @"^(\-?\d+(?:\.\d+)?)(?:\D+(\d+)\D+(\d+)([NS]?))?[^\d\-]+(\-?\d+(?:\.\d+)?)(?:\D+(\d+)\D+(\d+)([EW]?))?$";

        public decimal DecLongitude;
        public decimal DecLatitude;

        public string DegLongitude;
        public string DegLatitude;
        public bool Valid;
        public Mode mode;

        GroupCollection Collection;
        public Location(string text)
        {
            if (text == string.Empty) return;
            var match = Regex.Match(text, REGEX, RegexOptions.IgnoreCase);
            Collection = match.Groups;
            Valid = match.Success;
            if(Valid)
                ConvertAll();
        }
        private void ConvertAll()
        {
            if(Collection[2].Value == "")
            {
                mode = Mode.Decimal;
                DecLatitude = InvariantConvert((int)CoordType.Latitude);
                DecLongitude = InvariantConvert((int)CoordType.Longitude);
                ConvertFromDecimal();
            }
            else
            { 
                mode = Mode.Degree;

                int startIndex = (int)CoordType.Latitude;
                decimal degrees = InvariantConvert(startIndex + 0);
                decimal minutes = InvariantConvert(startIndex + 1);
                decimal seconds = InvariantConvert(startIndex + 2);
                DegLatitude= degrees.ToString() + "° " + minutes.ToString() + "' " + seconds.ToString() + (degrees < 0 ? "S" : "N") ;

                startIndex = (int)CoordType.Longitude;
                degrees = InvariantConvert(startIndex + 0);
                minutes = InvariantConvert(startIndex + 1);
                seconds = InvariantConvert(startIndex + 2);
                DegLongitude = degrees.ToString() + "° " + minutes.ToString() + "' " + seconds.ToString() + (degrees < 0 ? "W" : "E");

                ConvertFromDegree();
            }
        }

        private void ConvertFromDegree()
        {

            DecLatitude = GetDegreeMinuteSecond(CoordType.Latitude);
            DecLongitude = GetDegreeMinuteSecond(CoordType.Longitude);
        }
        private void ConvertFromDecimal()
        {
            DegLatitude = DecimalToDegMinSec(InvariantConvert((int)CoordType.Latitude), CoordType.Latitude);
            DegLongitude = DecimalToDegMinSec(InvariantConvert((int)CoordType.Longitude), CoordType.Longitude);
        }
        private decimal GetDegreeMinuteSecond(CoordType type)
        {
            int startIndex = (int)type;
            decimal degrees = InvariantConvert(startIndex + 0);
            decimal minutes = InvariantConvert(startIndex + 1);
            decimal seconds = InvariantConvert(startIndex + 2);
            return DegMinSecToDecimal(degrees, minutes, seconds);
        }
        private decimal InvariantConvert(int collectionIndex)
        {
            return Convert.ToDecimal(Collection[collectionIndex].Value, System.Globalization.CultureInfo.InvariantCulture);
        }
        private string DecimalToDegMinSec(decimal decimalNumber, CoordType type)
        {
            decimal degrees = Convert.ToInt32(Math.Truncate(decimalNumber));
            decimal minutes = Convert.ToInt32(Math.Truncate((decimalNumber - degrees) * 60));
            decimal seconds = Convert.ToInt32((((decimalNumber - degrees) * 60) - minutes) * 60);
            return degrees.ToString() + "° " + minutes.ToString() + "' " + ((decimal)seconds).ToString() + (type == CoordType.Latitude ? (degrees < 0 ? "S" : "N") : (degrees < 0 ? "W" : "E"));
        }
        private decimal DegMinSecToDecimal(decimal degrees, decimal minutes, decimal seconds)
        {
            return degrees + (minutes * (1M / 60M)) + (seconds * (1M / 60M) * (1M / 60M));
        }
    }
}
