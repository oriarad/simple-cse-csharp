using System.Text;
using System.Drawing;

namespace SimpleCSE
{
    public class Marker
    {
        public const int TINY = 0;
        public const int MID = 1;
        public const int SMALL = 2;
        private Color color;
        private double latitude = 0.0;
        private double longitude = 0.0;
        private string label = null;
        private int size = -1;
        private static readonly string[] SIZES = {"tiny", "mid", "small"};
	/**
	 * 
	 */
	public Marker()
        {

        }

        /**
         * 
         */
        public Marker(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        /**
         * 
         */
        public Marker(double latitude, double longitude, Color color): this(latitude, longitude)
        {            
            this.color = color;
        }

        /**
         * @return the color
         */
        public Color GetColor()
        {
            return this.color;
        }

        /**
         * @param color the color to set
         */
        public void SetColor(Color color)
        {
            this.color = color;
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

        /**
         * @return the label
         */
        public string GetLabel()
        {
            return this.label;
        }

        /**
         * @param label the label to set
         */
        public void SetLabel(string label)
        {
            this.label = label;
        }

        /**
         * @return the size
         */
        public int GetSize()
        {
            return this.size;
        }

        /**
         * @param size the size to set
         */
        public void SetSize(int size)
        {
            this.size = size;
        }

        /**
         * @return
         */
        public string GenerateUrl()
        {
            StringBuilder sb = new StringBuilder("&markers=");
            if ((this.size >= TINY) && (this.size <= SMALL))
            {
                sb.Append("size:" + SIZES[this.size] + "%7C");
            }
            if (this.color != null)
            {
                sb.Append("color:0x" + this.color.ToArgb().ToString("X").Substring(2) + "%7C");
            }

            if (this.label != null)
            {
                sb.Append("label:" + this.label[0] + "%7C");
            }

            sb.Append(this.latitude + "," + this.longitude);

            return sb.ToString();
        }
    }
}