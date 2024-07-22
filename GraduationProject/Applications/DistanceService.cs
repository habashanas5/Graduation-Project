namespace GraduationProject.Applications
{
    public class DistanceService
    {
        private const double EarthRadiusKm = 6371.0; // Radius of the Earth in kilometers

        public static double CalculateDistance(decimal lat1, decimal lng1, decimal lat2, decimal lng2)
        {
            double lat1Double = (double)lat1;
            double lng1Double = (double)lng1;
            double lat2Double = (double)lat2;
            double lng2Double = (double)lng2;

            var dLat = DegreesToRadians(lat2Double - lat1Double);
            var dLon = DegreesToRadians(lng2Double - lng1Double);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(DegreesToRadians(lat1Double)) * Math.Cos(DegreesToRadians(lat2Double)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return EarthRadiusKm * c;
        }

        private static double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180.0);
        }
    }
}
