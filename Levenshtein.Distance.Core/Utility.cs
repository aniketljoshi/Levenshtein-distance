using Amazon;
using System;
using System.Globalization;

namespace Levenshtein.Distance.Core
{
    public static class Utility
    {
        public static RegionEndpoint GetRegionEndpoint(string region)
        {
            if (string.IsNullOrEmpty(region))
                return RegionEndpoint.USEast1;

            switch (region.ToLower(CultureInfo.InvariantCulture))
            {
                case "apnortheast1":
                    return RegionEndpoint.APNortheast1;

                case "apnortheast2":
                    return RegionEndpoint.APNortheast2;

                case "apsoutheast1":
                    return RegionEndpoint.APSoutheast1;

                case "apsoutheast2":
                    return RegionEndpoint.APSoutheast2;

                case "cnnorth1":
                    return RegionEndpoint.CNNorth1;

                case "eucentral1":
                    return RegionEndpoint.EUCentral1;

                case "euwest1":
                    return RegionEndpoint.EUWest1;

                case "saeast1":
                    return RegionEndpoint.SAEast1;

                case "useast1":
                case "us-east-1":
                    return RegionEndpoint.USEast1;

                case "useeast2":
                    return RegionEndpoint.USEast2;

                case "uswest1":
                    return RegionEndpoint.USWest1;

                case "uswest2":
                    return RegionEndpoint.USWest2;

                case "apsouth1":
                    return RegionEndpoint.APSouth1;

                default:
                    throw new ArgumentOutOfRangeException($"Invalid region name {region}");
            }
        }
    }
}