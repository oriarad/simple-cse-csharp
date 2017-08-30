namespace SimpleCSE
{
    public class Location
    {
        private double latitude = 0.0;
        private double longitude = 0.0;

        /**
         * @param latitude
         * @param longitude
         */
        public Location(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        /**
         * @return the latitude
         */
        public double GetLatitude()
        {
            return this.latitude;
        }

        /**
         * @param latitude the latitude to set
         */
        public void SetLatitude(double latitude)
        {
            this.latitude = latitude;
        }

        /**
         * @return the longitude
         */
        public double GetLongitude()
        {
            return this.longitude;
        }

        /**
         * @param longitude the longitude to set
         */
        public void SetLongitude(double longitude)
        {
            this.longitude = longitude;
        }
    }
}