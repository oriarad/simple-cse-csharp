using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace SimpleCSE
{
    public class Path
    {
        private Color color;
        private Color fillColor;
        private int weight = 0;
        List<Location> points = null;
        private Boolean geodesic = false;


        /**
         *  
         */
        public Path(double latitude, double longitude)
        {
            this.points = new List<Location>();
            AddPoint(latitude, longitude);

        }

        /**
         * @param color
         */
        public void SetColor(Color color)
        {
            this.color = color;
        }

        /**
         * @param latitude
         * @param longitude
         */
        public void AddPoint(double latitude, double longitude)
        {
            this.points.Add(new Location(latitude, longitude));

        }

        /**
         * @return
         */
        public String GenerateUrl()
        {
            StringBuilder sb = new StringBuilder("&path=");
            if (this.weight > 0)
            {
                sb.Append("weight:" + this.weight + "%7C");
            }
            if (this.color != null)
            {
                sb.Append("color:0x" + this.color.ToArgb().ToString("X").Substring(2) + "%7C");
            }

            foreach (Location point in this.points)
            {
                sb.Append(point.GetLatitude() + "," + point.GetLongitude() + '|');
            }

            // Remove unnecessary last '|' if needed
            if (sb[sb.Length - 1] == '|')
            {
                sb.Remove(sb.Length - 1,1);
            }

            return sb.ToString();
        }

        /**
         * @return the fillColor
         */
        public Color GetFillColor()
        {
            return this.fillColor;
        }

        /**
         * @param fillColor the fillColor to set
         */
        public void SetFillColor(Color fillColor)
        {
            this.fillColor = fillColor;
        }

        /**
         * @return the weight
         */
        public int GetWeight()
        {
            return this.weight;
        }

        /**
         * @param weight the weight to set
         */
        public void SetWeight(int weight)
        {
            this.weight = weight;
        }

        /**
         * @return the geodesic
         */
        public Boolean IsGeodesic()
        {
            return this.geodesic;
        }

        /**
         * @param geodesic the geodesic to set
         */
        public void SetGeodesic(Boolean geodesic)
        {
            this.geodesic = geodesic;
        }

        /**
         * @return the color
         */
        public Color GetColor()
        {
            return this.color;
        }

        /**
         * @return the points
         */
        public List<Location> GetPoints()
        {
            return this.points;
        }

    }
}
