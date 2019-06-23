using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Herbarium.Class
{
    static class GpsParser
    {
        public static bool TryParseCoord(string coord, out double value)
        {
            coord.Replace(" ", "");
            Regex r = new Regex("[SWGB]", RegexOptions.IgnoreCase);
            if (r.Match(coord).Success && coord[0]!='-')
            {
                coord= coord.Insert(0, "-");   
            }
            coord= Regex.Replace(coord, "[SWGBDKNE]",string.Empty, RegexOptions.IgnoreCase);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var harf in coord)
            {
                stringBuilder.Append(harf);
                if (harf == '°' || harf == '\''|| harf=='"')
                    stringBuilder.Append(" ");
            }
            coord = stringBuilder.ToString();
            coord = coord.Trim();
            string[] separator = new string[] { " " };
            string[] parts = coord.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                switch (parts.Length)
                {
                    case 1:
                        value = parseDFormat(parts);
                        return true;

                    case 2:
                        value = parseDMFormat(parts);
                        return true;

                    case 3:
                        value = parseDMSFormat(parts);
                        return true;

                    default:
                        value = double.NaN;
                        return false;
                }
            }
            catch (Exception ex)
            {
                value = double.NaN;
                return false;
            }
        }

        private static double parseDFormat(string[] parts)
        {
            string value = parts[0].Replace("°", "");
            return XmlConvert.ToDouble(value);
        }

        private static double parseDMFormat(string[] parts)
        {
            string valueD = parts[0].Replace("°", "");
            string valueM = parts[1].Replace("'", "");


            double retVal = 0;
            bool negative = valueD.Contains('-');

            negative = negative || new Regex("[SWGB]", RegexOptions.IgnoreCase).Match(valueM).Success;

            if (new Regex("[SWNEGDKB]", RegexOptions.IgnoreCase).Match(valueM).Success)
                valueM = valueM.Substring(0, valueM.Length - 1);

            retVal += XmlConvert.ToDouble(valueD);

            double minutes = (XmlConvert.ToDouble(valueM) / 60);
            if (minutes >= 60 || minutes < 0) throw new FormatException();

            retVal += (negative) ? -minutes : minutes;

            return retVal;
        }

        private static double parseDMSFormat(string[] parts)
        {
            string valueD = parts[0].Replace("°", "");
            string valueM = parts[1].Replace("'", "");
            string valueS = parts[2].Replace("\"", "");
            
            double retVal = 0;
            bool negative = valueD.Contains('-');
            negative= negative || new Regex("[SWGB]",RegexOptions.IgnoreCase).Match(valueS).Success;
            
            if(new Regex("[SWNEGDKB]", RegexOptions.IgnoreCase).Match(valueS).Success)
                valueS = valueS.Substring(0, valueS.Length - 1);

            retVal += XmlConvert.ToDouble(valueD);

             double minutes = (XmlConvert.ToDouble(valueM) / 60);
            if (minutes >= 60 || minutes < 0 || valueM.Contains('.')) throw new FormatException();
            retVal += (negative) ? -minutes : minutes;

            double seconds = (XmlConvert.ToDouble(valueS) / 3600);
            if (seconds >= 60 || seconds < 0) throw new FormatException();
            retVal += (negative) ? -seconds : seconds;

            return retVal;
        }

    }
}
