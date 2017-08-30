/* COPYRIGHT (C) 2017 Ori Arad. All Rights Reserved. */
/* See LICENSE.txt for more details                  */

using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace SimpleCSE
{

    /**
     * This class provide a simple API to Google-Maps services.
     * It allows the user to generate a Google-Maps image, or a URL
     * to be used in a browser. 
     *<p>
     *Example:
     *<code>
     *SimpleGoogleMaps sgm = new SimpleGoogleMaps();
     *
     *sgm.setLatitude(32.776760);
     *sgm.setLongitude(35.027222);    
     *sgm.setZoom(17);
     *sgm.setWidth(640);
     *sgm.setHeight(640);
     *sgm.setMapType(SimpleGoogleMaps.HYBRID);
     *sgm.refresh(); 
     *</code> 
     * @author Ori Arad
     */
    public class SimpleGoogleMaps
    {
        private const long serialVersionUID = 1L;
        public const int ROADMAP = 0;
        public const int SATELLITE = 1;
        public const int TERRAIN = 2;
        public const int HYBRID = 3;
        private const int DEFAULT_WIDTH = 400;
        private const int DEFAULT_HEIGHT = 400;
        private static readonly string[] MAPTYPE = { "roadmap", "satellite", "terrain", "hybrid" };
        private SimpleGoogleMapsForm form;
        private Size dimension = new Size(DEFAULT_WIDTH, DEFAULT_HEIGHT);
        private int zoom = 12;
        private double latitude = 0.0;
        private double longitude = 0.0;
        private int scale = 1;
        private int mapType = ROADMAP;
        private string windowTitle = "SimpleGoogleMaps";
        private List<Marker> markers = null;
        private List<Path> paths = null;

        public int GetScale()
        {
            return this.scale;
        }

        public void SetScale(int scale)
        {
            this.scale = scale;
        }

        public int GetMapType()
        {
            return this.mapType;
        }

        public void SetMapType(int mapType)
        {
            this.mapType = mapType;
        }

        public Size GetDimension()
        {
            return this.dimension;
        }

        public void SetDimension(Size dimension)
        {
            this.dimension = dimension;
        }


        public int GetWidth()
        {
            return this.dimension.Width;
        }

        public void SetWidth(int width)
        {
            this.dimension.Width = width;
        }


        public int GetHeight()
        {
            return this.dimension.Height;
        }

        public void SetHeight(int height)
        {
            this.dimension.Height = height;
        }

        public int GetZoom()
        {
            return this.zoom;
        }

        public void SetZoom(int zoom)
        {
            this.zoom = zoom;
        }

        public double GetLatitude()
        {
            return this.latitude;
        }

        public void SetLatitude(double latitude)
        {
            this.latitude = latitude;
        }

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
         * @return the windowTitle
         */
        public string GetWindowTitle()
        {
            return this.windowTitle;
        }

        /**
         * @param windowTitle the windowTitle to set
         */
        public void SetWindowTitle(string windowTitle)
        {
            this.windowTitle = windowTitle;
        }

        /**
         * @return
         * TODO Consider rename to toString
         */
        public string GenerateUrl()
        {
            StringBuilder str = new StringBuilder("http://maps.googleapis.com/maps/api/staticmap?center=");
            str.Append(this.latitude);
            str.Append(",");
            str.Append(this.longitude);
            str.Append("&zoom=");
            str.Append(this.zoom);
            str.Append("&size=");
            str.Append((int)this.GetHeight());
            str.Append("x");
            str.Append((int)this.GetWidth());
            str.Append("&maptype=");
            str.Append(MAPTYPE[this.mapType]);
            str.Append("&scale=");
            str.Append(this.scale);
            foreach (Marker marker in this.markers)
            {
                str.Append(marker.GenerateUrl());
            }
            foreach (Path path in this.paths)
            {
                str.Append(path.GenerateUrl());
            }
            str.Append("&language=iw&sensor=false");
            // TODO Add free text
            // TODO Add language option
            // TODO Add markers & style    	

            return str.ToString();
        }

        
        public SimpleGoogleMaps()
        {
            this.form = new SimpleGoogleMapsForm();
            Thread myThread = new Thread((ThreadStart)delegate { Application.Run(form); });
            myThread.Start();

            this.markers = new List<Marker>();
            this.paths = new List<Path>();

            Refresh();
        }

        public void Refresh()
        {
            form.SetImage(GenerateUrl());
        }



        public void AddMarker(Marker marker)
        {
            this.markers.Add(marker);
        }

        public void AddPath(Path path)
        {
            this.paths.Add(path);
        }
    }
}

// @todo Add street-view support:
//       http://maps.googleapis.com/maps/api/streetview?size=600x300&location=(48.856206, 2.2976810000000114)&heading=315.47499999999997&fov=90&pitch=23.275000000000002&sensor=false
//       http://maps.googleapis.com/maps/api/streetview?size=400x400&location=40.720032,%20-73.988354&fov=90&heading=235&pitch=10&sensor=false
//       https://developers.google.com/maps/documentation/streetview/
//       http://gmaps-samples.googlecode.com/svn/trunk/streetview/streetview_lazy.html
//      http://gmaps-samples.googlecode.com/svn/trunk/
//       http://maps.google.com/intl/iw/help/maps/streetview/learn/where-is-street-view.html  
































